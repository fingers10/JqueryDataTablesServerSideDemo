using Microsoft.AspNetCore.Mvc;

namespace ServerSideMultiColumnSortingAndSearching.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}