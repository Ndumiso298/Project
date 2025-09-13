
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using System.Collections.Generic;
using System.Linq;


public class FaultTechnicianController : Controller
{
    private readonly ApplicationDbContext _db;

    public FaultTechnicianController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET: FaultTechnician
    public IActionResult Index()
    {
        List<FaultTechnician> technicians = _db.tblFaultTechnicians.ToList();
        return View(technicians);
    }

    // GET: FaultTechnician/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: FaultTechnician/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(FaultTechnician technician)
    {
        if (ModelState.IsValid)
        {
            _db.tblFaultTechnicians.Add(technician);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(technician);
    }

    // GET: FaultTechnician/Details/5
    public IActionResult Details(int id)
    {
        var technician = _db.tblFaultTechnicians.FirstOrDefault(t => t.TechnicianId == id);
        if (technician == null)
        {
            return NotFound();
        }
        return View(technician);
    }

    // GET: FaultTechnician/Edit/5
    public IActionResult Edit(int id)
    {
        var technician = _db.tblFaultTechnicians.FirstOrDefault(t => t.TechnicianId == id);
        if (technician == null)
        {
            return NotFound();
        }
        return View(technician);
    }

    // POST: FaultTechnician/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(FaultTechnician technician)
    {
        if (ModelState.IsValid)
        {
            _db.tblFaultTechnicians.Update(technician);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(technician);
    }

    // GET: FaultTechnician/Delete/5
    public IActionResult Delete(int id)
    {
        var technician = _db.tblFaultTechnicians.FirstOrDefault(t => t.TechnicianId == id);
        if (technician == null)
        {
            return NotFound();
        }
        return View(technician);
    }

    // POST: FaultTechnician/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var technician = _db.tblFaultTechnicians.FirstOrDefault(t => t.TechnicianId == id);
        if (technician == null)
        {
            return NotFound();
        }

        _db.tblFaultTechnicians.Remove(technician);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}