
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System.Collections.Generic;
using System.Linq;




public class MaintenanceVisitController : Controller
{
    private readonly ApplicationDbContext _db;

    public MaintenanceVisitController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Dashboard()
    {
        return View();
    }

    // GET: MaintenanceVisit
    public IActionResult Index(string search, string status, DateTime? fromDate, DateTime? toDate)
    {
        var visits = _db.tblMaintenanceVisits
            .Include(v => v.Customer)
            .Include(v => v.Technician)
            .Include(v => v.Fridge)
            .AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            visits = visits.Where(v =>
                v.Customer.Name.Contains(search) ||
                v.Technician.Name.Contains(search) ||
                v.Fridge.FridgeNo.Contains(search) ||
                v.Fridge.Model.Contains(search));
        }

        if (!string.IsNullOrEmpty(status))
        {
            visits = visits.Where(v => v.Status == status);
        }

        if (fromDate.HasValue)
        {
            visits = visits.Where(v => v.ScheduledDate >= fromDate.Value);
        }

        if (toDate.HasValue)
        {
            visits = visits.Where(v => v.ScheduledDate <= toDate.Value);
        }

        // Pass filters back to View
        ViewBag.Search = search;
        ViewBag.Status = status;
        ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
        ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");

        return View(visits);
    }

    // GET: MaintenanceVisit/Create
    public IActionResult Create(int maintenanceVisitId)
    {
        var visit = _db.tblMaintenanceVisits
            .Include(v => v.Fridge)
            .Include(v => v.Customer)
            .Include(v => v.Technician)
            .FirstOrDefault(v => v.MaintenanceVisitId == maintenanceVisitId);

        if (visit == null)
        {
            return NotFound();
        }

        var fault = new Fault
        {
            MaintenanceVisitId = maintenanceVisitId,
            FridgeId = visit.Fridge.FridgeId,              
            ReportedByCustomerId = visit.Customer.Id, 
            ReportedByCustomer = visit.Customer,
            Fridge = visit.Fridge,
            Location = visit.Fridge?.Location,
            ReportedAt = DateTime.Now
        };


        ViewBag.Technicians = new SelectList(_db.tblFaultTechnicians, "TechnicianId", "Name");

        return View(visit);
    }


    // POST: MaintenanceVisit/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Fault fault)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Technicians = new SelectList(_db.tblFaultTechnicians, "TechnicianId", "Name", fault.ResolvedByTechnicianId);
            return View(fault);
        }

        fault.ReportedAt = DateTime.Now;

        _db.tblFaults.Add(fault);
        _db.SaveChanges();

        return RedirectToAction("Details", "MaintenanceVisit", new { id = fault.MaintenanceVisitId });
    }


    // GET: MaintenanceVisit/Details/5
    public IActionResult Details(int id)
    {
        var visit = _db.tblMaintenanceVisits.FirstOrDefault(v => v.MaintenanceVisitId == id);
        if (visit == null)
        {
            return NotFound();
        }
        return View(visit);
    }

    // GET: MaintenanceVisit/Edit/5
    public IActionResult Edit(int id)
    {
        var visit = _db.tblMaintenanceVisits
            .Include(v => v.Fridge)
            .Include(v => v.Technician)
            .FirstOrDefault(v => v.MaintenanceVisitId == id);

        if (visit == null)
        {
            return NotFound();
        }

        ViewBag.TechnicianList = new SelectList(_db.tblFaultTechnicians, "TechnicianId", "Name", visit.TechnicianId);

        return View(visit);
    }




    // POST: MaintenanceVisit/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
   
    public IActionResult Edit(MaintenanceVisit visit)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.TechnicianList = new SelectList(_db.tblFaultTechnicians, "TechnicianId", "Name", visit.TechnicianId);
            return View(visit);
        }

        var existingVisit = _db.tblMaintenanceVisits
            .FirstOrDefault(v => v.MaintenanceVisitId == visit.MaintenanceVisitId);

        if (existingVisit == null)
        {
            return NotFound();
        }

        existingVisit.ScheduledDate = visit.ScheduledDate;
        existingVisit.Status = visit.Status;
        existingVisit.TechnicianNotes = visit.TechnicianNotes;
        existingVisit.TechnicianId = visit.TechnicianId; 

        _db.SaveChanges();

        return RedirectToAction("Index");
    }



    // GET: MaintenanceVisit/Delete/5
    public IActionResult Delete(int id)
    {
        var visit = _db.tblMaintenanceVisits
            .Include(v => v.Customer)
            .FirstOrDefault(v => v.MaintenanceVisitId == id);

        if (visit == null)
        {
            return NotFound();
        }

        return View(visit); 
    }


    // POST: MaintenanceVisit/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var visit = _db.tblMaintenanceVisits
            .FirstOrDefault(v => v.MaintenanceVisitId == id);

        if (visit == null)
        {
            return NotFound();
        }

       
        _db.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Print(int id)
    {
        var visit = _db.tblMaintenanceVisits
            .Include(v => v.Technician)
            .Include(v => v.Fridge)
            .FirstOrDefault(v => v.MaintenanceVisitId == id);

        if (visit == null) return NotFound();

        return View("Print", visit);
    }



}
