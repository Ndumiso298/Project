using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Utilities;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Dashboard");
            //}
            return View();
        }

        //public async Task<IActionResult> Dashboard()
        //{
        //    if (User.IsInRole(SD.AdminRole))
        //    {
        //        ViewBag.TotalFridges = await _context.Fridges.CountAsync(f => f.IsActive);
        //        ViewBag.ActiveCustomers = await _context.Customers.CountAsync(c => c.IsActive);
        //        ViewBag.PendingRequests = await _context.AllocationRequestHeaders.CountAsync(r => r.Status == "Pending");
        //        ViewBag.OpenFaults = await _context.FaultRecords.CountAsync(f => !f.IsDeleted);

        //        return View("AdminDashboard");
        //    }
        //    else if (User.IsInRole(SD.CustomerRole))
        //    {
        //        return View("CustomerDashboard");
        //    }
        //    // Add other role-specific dashboards

        //    return View("Index");
        //}

        public IActionResult OurServices()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
