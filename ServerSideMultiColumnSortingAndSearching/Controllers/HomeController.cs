using AspNetCoreServerSide.Contracts;
using AspNetCoreServerSide.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AspNetCoreServerSide.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDemoService _demoService;

        public HomeController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> LoadTable([FromBody]DTParameters param)
        {
            try
            {
                var data = await _demoService.GetDataAsync(param);

                return new JsonResult(new DTResult<Demo>
                {
                    draw = param.Draw,
                    data = data,
                    recordsFiltered = data.Length,
                    recordsTotal = data.Length
                });
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }
    }
}
