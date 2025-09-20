
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Utilities.Enums;
using System.Collections.Generic;
using System.Linq;


namespace Project.Controllers
{
    public class FaultController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FaultController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string customerName, string location, string status)
        {
            var faults = _db.FaultRecords
                .Include(f => f.ReportedBy)
                .Include(f => f.AssignedTechnician)
                .Include(f => f.Fridge)
                .AsQueryable();

            if (!string.IsNullOrEmpty(customerName))
                faults = faults.Where(f => f.ReportedBy.Customer.UserAccount.FirstName.Contains(customerName));

            if (!string.IsNullOrEmpty(location))
                faults = faults.Where(f => f.ReportedBy.Customer.TradingName.Contains(location));

            if (!string.IsNullOrEmpty(status))
                faults = faults.Where(f => f.Status == Utilities.Enums.FaultStatus.Reported);

            ViewBag.CustomerName = customerName;
            ViewBag.Location = location;
            ViewBag.Status = status;

            return View(faults);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var fault = _db.FaultRecords
                .Include(f => f.ReportedBy)
                .Include(f => f.AssignedTechnician)
                .Include(f => f.Fridge)
                .FirstOrDefault(f => f.Id == id);

            if (fault == null)
            {
                return NotFound();
            }

            return View(fault);
        }

        [HttpGet]
        public IActionResult Process(int id)
        {
            var fault = _db.FaultRecords
                .Include(f => f.ReportedBy)
                .Include(f => f.Fridge)
                .FirstOrDefault(f => f.Id == id);

            if (fault == null) return NotFound();

            ViewBag.Technicians = _db.Employees
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.UserAccount.FirstName,
                }).ToList();

            return View(fault);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Process(FridgeFault input)
        {
            var fault = _db.FaultRecords.FirstOrDefault(f => f.Id == input.Id);
            if (fault == null) return NotFound();

            fault.Status = input.Status;
            fault.ResolutionNotes = input.ResolutionNotes;
            fault.AssignedTechnician = input.AssignedTechnician;
            if (fault.Status == FaultStatus.Resolved)
                fault.ResolvedDate = DateTime.Now;
            else
                fault.ResolvedDate = null;


            _db.SaveChanges();
            TempData["SuccessMessage"] = "FridgeFault processed successfully.";

            return RedirectToAction("Index");
        }
        public IActionResult Print(int id)
        {
            var fault = _db.FaultRecords
                .Include(f => f.ReportedBy)
                .Include(f => f.Fridge)
                .Include(f => f.AssignedTechnician)
                .FirstOrDefault(f => f.Id == id);

            if (fault == null)
            {
                return NotFound();
            }

            return View("Print", fault);
        }

    }

}
