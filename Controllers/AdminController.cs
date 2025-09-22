using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Utilities;

namespace Project.Controllers
{
    [Authorize(Roles =SD.AdminRole)]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Customers()
        {
            return View();
        }
        public IActionResult Employees()
        {
            return View();
        }
        public IActionResult Locations()
        {
            return View();
        }
        public IActionResult Suppliers()
        {
            return View();
        }
    }
}
