using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Utilities;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole)]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var employees = _db.Employees.Include(e => e.UserAccount).ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            // Create employee logic
            return RedirectToAction("Index");
        }

        public IActionResult AssignRole(int id)
        {
            // Role assignment logic
            return View();
        }
    }
}
