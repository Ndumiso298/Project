
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Project.Data;
//using Project.Models;
//using System.Collections.Generic;
//using System.Linq;


//namespace Project.Controllers
//{
//    public class FaultController : Controller
//    {
//        private readonly ApplicationDbContext _db;
//        public FaultController(ApplicationDbContext db)
//        {
//            _db = db;
//        }
//        public IActionResult Index(string customerName, string location, string status)
//        {
//            var faults = _db.tblFaults
//                .Include(f => f.ReportedByCustomer)
//                .Include(f => f.ResolvedByTechnician)
//                .Include(f => f.Fridge)
//                .AsQueryable();

            //if (!string.IsNullOrEmpty(customerName))
            //    faults = faults.Where(f => f.ReportedByCustomer.Name.Contains(customerName));

            //if (!string.IsNullOrEmpty(location))
            //    faults = faults.Where(f => f.ReportedByCustomer.Address.Contains(location));

            //if (!string.IsNullOrEmpty(status))
            //    faults = faults.Where(f => f.Status == status);

//            ViewBag.CustomerName = customerName;
//            ViewBag.Location = location;
//            ViewBag.Status = status;

//            return View(faults);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }
//        public IActionResult Details(int id)
//        {
//            var fault = _db.tblFaults
//                .Include(f => f.ReportedByCustomer)
//                .Include(f => f.ResolvedByTechnician)
//                .Include(f => f.Fridge)
//                .FirstOrDefault(f => f.FaultId == id);

//            if (fault == null)
//            {
//                return NotFound();
//            }

//            return View(fault);
//        }

//        [HttpGet]
//        public IActionResult Process(int id)
//        {
//            var fault = _db.tblFaults
//                .Include(f => f.ReportedByCustomer)
//                .Include(f => f.Fridge)
//                .FirstOrDefault(f => f.FaultId == id);

//            if (fault == null) return NotFound();

//            ViewBag.Technicians = _db.tblFaultTechnicians
//                .Select(t => new SelectListItem
//                {
//                    Value = t.TechnicianId.ToString(),
//                    Text = t.Name
//                }).ToList();

//            return View(fault);
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Process(Fault input)
//        {
//            var fault = _db.tblFaults.FirstOrDefault(f => f.FaultId == input.FaultId);
//            if (fault == null) return NotFound();

//            fault.Status = input.Status;
//            fault.Notes = input.Notes;
//            fault.ResolvedByTechnicianId = input.ResolvedByTechnicianId;
//            if (fault.Status == "Resolved")
//                fault.ResolvedAt = DateTime.Now;
//            else
//                fault.ResolvedAt = null;


//            _db.SaveChanges();
//            TempData["SuccessMessage"] = "Fault processed successfully.";

//            return RedirectToAction("Index");
//        }
//        public IActionResult Print(int id)
//        {
//            var fault = _db.tblFaults
//                .Include(f => f.ReportedByCustomer)
//                .Include(f => f.Fridge)
//                .Include(f => f.ResolvedByTechnician)
//                .FirstOrDefault(f => f.FaultId == id);

//            if (fault == null)
//            {
//                return NotFound();
//            }

//            return View("Print", fault);
//        }

//    }

//}
