
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using System.Collections.Generic;
using System.Linq;


public class FridgeRequestController : Controller
{
    private readonly ApplicationDbContext _db;

    public FridgeRequestController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET: FridgeRequest
    public IActionResult Index()
    {
        List<FridgeRequest> requests = _db.ReplacementRequests.ToList();
        return View(requests);
    }

    // GET: FridgeRequest/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: FridgeRequest/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(FridgeRequest request)
    {
        if (ModelState.IsValid)
        {
            _db.ReplacementRequests.Add(request);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(request);
    }

    // GET: FridgeRequest/Details/5
    public IActionResult Details(int id)
    {
        var request = _db.ReplacementRequests.FirstOrDefault(r => r.Id == id);
        if (request == null)
        {
            return NotFound();
        }
        return View(request);
    }

    // GET: FridgeRequest/Edit/5
    public IActionResult Edit(int id)
    {
        var request = _db.ReplacementRequests.FirstOrDefault(r => r.Id == id);
        if (request == null)
        {
            return NotFound();
        }
        return View(request);
    }

    // POST: FridgeRequest/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(FridgeRequest request)
    {
        if (ModelState.IsValid)
        {
            _db.ReplacementRequests.Update(request);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(request);
    }

    // GET: FridgeRequest/Delete/5
    public IActionResult Delete(int id)
    {
        var request = _db.ReplacementRequests.FirstOrDefault(r => r.Id == id);
        if (request == null)
        {
            return NotFound();
        }
        return View(request);
    }

    // POST: FridgeRequest/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var request = _db.ReplacementRequests.FirstOrDefault(r => r.Id == id);
        if (request == null)
        {
            return NotFound();
        }

        _db.ReplacementRequests.Remove(request);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
