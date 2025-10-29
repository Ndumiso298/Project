using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
