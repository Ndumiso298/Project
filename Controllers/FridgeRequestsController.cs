using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Utility;

namespace Project.Controllers
{
    [Authorize]
    public class FridgeRequestsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FridgeRequestsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: FridgeRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.FridgeRequests.Include(f => f.AssignedEmployee).Include(f => f.FaultRecord).Include(f => f.FridgeAllocation).Include(f => f.MaintenanceRecord);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FridgeRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeRequest = await _db.FridgeRequests
                .Include(f => f.AssignedEmployee)
                .Include(f => f.FaultRecord)
                .Include(f => f.FridgeAllocation)
                .Include(f => f.MaintenanceRecord)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fridgeRequest == null)
            {
                return NotFound();
            }

            return View(fridgeRequest);
        }

        // GET: FridgeRequests/Create
        public IActionResult Create()
        {
            ViewData["AssignedEmployeeId"] = new SelectList(_db.Employees, "Id", "Discriminator");
            ViewData["FaultRecordId"] = new SelectList(_db.FaultRecords, "Id", "Description");
            ViewData["FridgeAllocationId"] = new SelectList(_db.FridgeAllocations, "Id", "Id");
            ViewData["MaintenanceRecordId"] = new SelectList(_db.MaintenanceRecords, "Id", "Description");
            return View();
        }

        // POST: FridgeRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FridgeAllocationId,FaultRecordId,MaintenanceRecordId,AssignedEmployeeId,RequestType,Reason,Quantity,Status,Priority,RequestedDate,AssignedDate,ResponseDate,ResponseNotes,CreatedAt,UpdatedAt,IsDeleted")] FridgeRequest fridgeRequest)
        {
            if (ModelState.IsValid)
            {
                _db.Add(fridgeRequest);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignedEmployeeId"] = new SelectList(_db.Employees, "Id", "Discriminator", fridgeRequest.AssignedEmployeeId);
            ViewData["FaultRecordId"] = new SelectList(_db.FaultRecords, "Id", "Description", fridgeRequest.FaultRecordId);
            ViewData["FridgeAllocationId"] = new SelectList(_db.FridgeAllocations, "Id", "Id", fridgeRequest.FridgeAllocationId);
            ViewData["MaintenanceRecordId"] = new SelectList(_db.MaintenanceRecords, "Id", "Description", fridgeRequest.MaintenanceRecordId);
            return View(fridgeRequest);
        }

        // GET: FridgeRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeRequest = await _db.FridgeRequests.FindAsync(id);
            if (fridgeRequest == null)
            {
                return NotFound();
            }
            ViewData["AssignedEmployeeId"] = new SelectList(_db.Employees, "Id", "Discriminator", fridgeRequest.AssignedEmployeeId);
            ViewData["FaultRecordId"] = new SelectList(_db.FaultRecords, "Id", "Description", fridgeRequest.FaultRecordId);
            ViewData["FridgeAllocationId"] = new SelectList(_db.FridgeAllocations, "Id", "Id", fridgeRequest.FridgeAllocationId);
            ViewData["MaintenanceRecordId"] = new SelectList(_db.MaintenanceRecords, "Id", "Description", fridgeRequest.MaintenanceRecordId);
            return View(fridgeRequest);
        }

        // POST: FridgeRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FridgeAllocationId,FaultRecordId,MaintenanceRecordId,AssignedEmployeeId,RequestType,Reason,Quantity,Status,Priority,RequestedDate,AssignedDate,ResponseDate,ResponseNotes,CreatedAt,UpdatedAt,IsDeleted")] FridgeRequest fridgeRequest)
        {
            if (id != fridgeRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(fridgeRequest);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FridgeRequestExists(fridgeRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignedEmployeeId"] = new SelectList(_db.Employees, "Id", "Discriminator", fridgeRequest.AssignedEmployeeId);
            ViewData["FaultRecordId"] = new SelectList(_db.FaultRecords, "Id", "Description", fridgeRequest.FaultRecordId);
            ViewData["FridgeAllocationId"] = new SelectList(_db.FridgeAllocations, "Id", "Id", fridgeRequest.FridgeAllocationId);
            ViewData["MaintenanceRecordId"] = new SelectList(_db.MaintenanceRecords, "Id", "Description", fridgeRequest.MaintenanceRecordId);
            return View(fridgeRequest);
        }

        // GET: FridgeRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeRequest = await _db.FridgeRequests
                .Include(f => f.AssignedEmployee)
                .Include(f => f.FaultRecord)
                .Include(f => f.FridgeAllocation)
                .Include(f => f.MaintenanceRecord)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fridgeRequest == null)
            {
                return NotFound();
            }

            return View(fridgeRequest);
        }

        // POST: FridgeRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fridgeRequest = await _db.FridgeRequests.FindAsync(id);
            if (fridgeRequest != null)
            {
                _db.FridgeRequests.Remove(fridgeRequest);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FridgeRequestExists(int id)
        {
            return _db.FridgeRequests.Any(e => e.Id == id);
        }
    }
}
