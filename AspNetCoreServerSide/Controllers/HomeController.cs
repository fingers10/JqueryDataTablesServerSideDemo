using AspNetCoreServerSide.Contracts;
using AspNetCoreServerSide.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.ActionResults;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AspNetCoreServerSide.Controllers
{
    public class HomeController:Controller
    {
		private const string _dataTableSessionKey = "DataTableSessionKey";

        private readonly IDemoService _demoService;

        public HomeController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        public IActionResult Index()
        {
            return View(new Demo());
        }

        //public async Task<IActionResult> LoadTable(JqueryDataTablesParameters param)
        //{
        //    try
        //    {
        //        var results = await _demoService.GetDataAsync(param);

        //        return new JsonResult(new JqueryDataTablesResult<Demo> {
        //            Draw = param.Draw,
        //            Data = results.Items,
        //            RecordsFiltered = results.TotalSize,
        //            RecordsTotal = results.TotalSize
        //        });
        //    } catch(Exception e)
        //    {
        //        Console.Write(e.Message);
        //        return new JsonResult(new { error = "Internal Server Error" });
        //    }
        //}

        //public async Task<IActionResult> GetExcel(JqueryDataTablesParameters param)
        //{
        //    var results = await _demoService.GetDataAsync(param);
        //    return new JqueryDataTablesExcelResult<Demo>(results.Items,"Demo Sheet Name","Fingers10");
        //}

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody]JqueryDataTablesParameters param)
        {
            try
            {
                HttpContext.Session.SetString(_dataTableSessionKey,JsonConvert.SerializeObject(param));
                return Json(await _demoService.GetDataAsync(param));
            } catch(Exception e)
            {
                Console.Write(e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        public async Task<IActionResult> GetExcel(bool convertAllData = false)
        {
            var param = HttpContext.Session.GetString(_dataTableSessionKey);
            return await _demoService.GetExcelDataAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param), convertAllData);
        }
    }
}
