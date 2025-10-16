
//using Microsoft.AspNetCore.Mvc;
//using Project.Data;
//using Project.Models;
//using System.Collections.Generic;
//using System.Linq;


//public class ProcessFaultController : Controller
//{
//    private readonly ApplicationDbContext _db;

//    public ProcessFaultController(ApplicationDbContext db)
//    {
//        _db = db;
//    }

//    // GET: ProcessFault
//    public IActionResult Index()
//    {
//        List<ProcessFault> faults = _db.tblProcessFaults.ToList();
//        return View(faults);
//    }

//    // GET: ProcessFault/Create
//    public IActionResult Create()
//    {
//        return View();
//    }

//    // POST: ProcessFault/Create
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public IActionResult Create(ProcessFault fault)
//    {
//        if (ModelState.IsValid)
//        {
//            _db.tblProcessFaults.Add(fault);
//            _db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        return View(fault);
//    }

//    // GET: ProcessFault/Details/5
//    public IActionResult Details(int id)
//    {
//        var fault = _db.tblProcessFaults.FirstOrDefault(f => f.Id == id);
//        if (fault == null)
//        {
//            return NotFound();
//        }
//        return View(fault);
//    }

//    // GET: ProcessFault/Edit/5
//    public IActionResult Edit(int id)
//    {
//        var fault = _db.tblProcessFaults.FirstOrDefault(f => f.Id == id);
//        if (fault == null)
//        {
//            return NotFound();
//        }
//        return View(fault);
//    }

//    // POST: ProcessFault/Edit/5
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public IActionResult Edit(ProcessFault fault)
//    {
//        if (ModelState.IsValid)
//        {
//            _db.tblProcessFaults.Update(fault);
//            _db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        return View(fault);
//    }

//    // GET: ProcessFault/Delete/5
//    public IActionResult Delete(int id)
//    {
//        var fault = _db.tblProcessFaults.FirstOrDefault(f => f.Id == id);
//        if (fault == null)
//        {
//            return NotFound();
//        }
//        return View(fault);
//    }

//    // POST: ProcessFault/Delete/5
//    [HttpPost, ActionName("Delete")]
//    [ValidateAntiForgeryToken]
//    public IActionResult DeleteConfirmed(int id)
//    {
//        var fault = _db.tblProcessFaults.FirstOrDefault(f => f.Id == id);
//        if (fault == null)
//        {
//            return NotFound();
//        }

//        _db.tblProcessFaults.Remove(fault);
//        _db.SaveChanges();
//        return RedirectToAction("Index");
//    }
//}
