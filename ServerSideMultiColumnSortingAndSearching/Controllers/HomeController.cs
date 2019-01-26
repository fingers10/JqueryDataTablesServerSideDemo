using Microsoft.AspNetCore.Mvc;
using ServerSideMultiColumnSortingAndSearching.Models;
using System;

namespace ServerSideMultiColumnSortingAndSearching.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult LoadTable([FromBody]DTParameters<DemoModel> param)
        {
            try
            {
                //var memberInfos = await _databaseService.GetMemberInfoAsync(Environment, param.StringValue1);
                //param.DataSource = new MemberClaimInfoDAO().GetMemberClaimInfo(Environment, await GetWarehouseIdStringAsync(memberInfos), param.StringValue2);
                //param.ApplySearchAndSort<MemberClaimInfoDataModel>();

                return new JsonResult(new DTResult<DemoModel>
                {
                    draw = param.Draw,
                    data = param.DataSource,
                    recordsFiltered = param.DataSource.Count,
                    recordsTotal = param.DataSource.Count
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
