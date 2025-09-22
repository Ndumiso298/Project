using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class CustomerSupportController : Controller
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
