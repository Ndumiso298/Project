using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class StockControllerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
