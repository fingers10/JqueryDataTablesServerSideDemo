using AspNetCoreServerSide.ActionResults;
using AspNetCoreServerSide.Contracts;
using AspNetCoreServerSide.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AspNetCoreServerSide.Controllers
{
    public class HomeController:Controller
    {
        private readonly IDemoService _demoService;
        //private ISession Session => HttpContext.Session;

        public HomeController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        public IActionResult Index()
        {
            return View(new Demo());
        }

        public async Task<IActionResult> LoadTable(DTParameters param)
        {
            try
            {
                var results = await _demoService.GetDataAsync(param);

                return new JsonResult(new DTResult<Demo> {
                    draw = param.Draw,
                    data = results.Items,
                    recordsFiltered = results.TotalSize,
                    recordsTotal = results.TotalSize
                });
            } catch(Exception e)
            {
                Console.Write(e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> LoadTable([FromBody]DTParameters param)
        //{
        //    try
        //    {
        //        var results = await _demoService.GetDataAsync(param);

        //        return new JsonResult(new DTResult<Demo> {
        //            draw = param.Draw,
        //            data = results.Items,
        //            recordsFiltered = results.TotalSize,
        //            recordsTotal = results.TotalSize
        //        });
        //    } catch(Exception e)
        //    {
        //        Console.Write(e.Message);
        //        return new JsonResult(new { error = "Internal Server Error" });
        //    }
        //}

        //[HttpPost]
        //public async Task<JsonResult> ExportTable([FromBody]DTParameters param)
        //{
        //    try
        //    {
        //        var results = await _demoService.GetDataAsync(param);
        //        Session.SetString("DemoKey",JsonConvert.SerializeObject(results.Items));
        //        return new JsonResult(true);

        //    } catch(Exception e)
        //    {
        //        Console.Write(e.Message);
        //        return new JsonResult(false);
        //    }
        //}

        //public IActionResult GetExcel()
        //{
        //    return new DataTablesExcelResult<Demo>(Session,"DemoKey","Demo Sheet Name","Fingers10");
        //}

        public async Task<IActionResult> GetExcel(DTParameters param)
        {
            var results = await _demoService.GetDataAsync(param);
            //Session.SetString("DemoKey",JsonConvert.SerializeObject(results.Items));
            return new DataTablesExcelResult<Demo>(results.Items,"Demo Sheet Name","Fingers10");
        }
    }
}
