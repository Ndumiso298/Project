using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class MaintenanceTechController : Controller
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
