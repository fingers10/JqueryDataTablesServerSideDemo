using AspNetCoreServerSide.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreServerSide.ActionResults
{
    public class DataTablesExcelResult<T>:IActionResult
    {
        private readonly IEnumerable<T> _data;

        //private readonly ISession _session;

        public DataTablesExcelResult(
            //ISession session,string key,
            IEnumerable<T> data,
            string sheetName,string fileName)
        {
            _data = data;
            //_session = session;
            //Key = key;
            SheetName = sheetName;
            FileName = fileName;
        }

        //public string Key { get; }
        public string SheetName { get; }
        public string FileName { get; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            try
            {
                //var value = _session.GetString(Key);
                //_session.Remove(Key);
                //var data = value == null ? default : JsonConvert.DeserializeObject<IEnumerable<T>>(value);

                var excelBytes = await _data.GenerateExcelForDataTableAsync(SheetName);
                WriteExcelFileAsync(context.HttpContext,excelBytes);

            } catch(Exception e)
            {
                Console.WriteLine(e);

                var errorBytes = await new List<T>().GenerateExcelForDataTableAsync(SheetName);
                WriteExcelFileAsync(context.HttpContext,errorBytes);
            }
        }

        private async void WriteExcelFileAsync(HttpContext context,byte[] bytes)
        {
            context.Response.Headers["content-disposition"] = $"attachment; filename={FileName}.xlsx";
            await context.Response.Body.WriteAsync(bytes,0,bytes.Length);
        }
    }
}
