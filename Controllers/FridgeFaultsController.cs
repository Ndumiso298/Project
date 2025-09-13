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
    [Authorize(Roles = StaticDetails.AdminRole + "," + StaticDetails.FaultTechnicianRole + "," + StaticDetails.MaintenanceTechnicianRole)]
    public class FridgeFaultsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FridgeFaultsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: FridgeFaults
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.FaultRecords.Include(f => f.FaultTechnician).Include(f => f.FaultyFridge).Include(f => f.ReportedBy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FridgeFaults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeFault = await _db.FaultRecords
                .Include(f => f.FaultTechnician)
                .Include(f => f.FaultyFridge)
                .Include(f => f.ReportedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fridgeFault == null)
            {
                return NotFound();
            }

            return View(fridgeFault);
        }

        // GET: FridgeFaults/Create
        public IActionResult Create()
        {
            ViewData["FaultTechnicianId"] = new SelectList(_db.FaultTechnicians, "Id", "Discriminator");
            ViewData["FridgeAllocationId"] = new SelectList(_db.FridgeAllocations, "Id", "Id");
            ViewData["ReportedById"] = new SelectList(_db.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: FridgeFaults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FridgeAllocationId,FaultTechnicianId,ReportedById,Status,Description,Diagnosis,Priority,ReportedDate,AssignedDate,ResolvedDate,ResolutionNotes,CreatedAt,UpdatedAt,IsDeleted")] FridgeFault fridgeFault)
        {
            if (ModelState.IsValid)
            {
                _db.Add(fridgeFault);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FaultTechnicianId"] = new SelectList(_db.FaultTechnicians, "Id", "Discriminator", fridgeFault.FaultTechnicianId);
            ViewData["FridgeAllocationId"] = new SelectList(_db.FridgeAllocations, "Id", "Id", fridgeFault.FridgeAllocationId);
            ViewData["ReportedById"] = new SelectList(_db.ApplicationUsers, "Id", "Id", fridgeFault.ReportedById);
            return View(fridgeFault);
        }

        // GET: FridgeFaults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeFault = await _db.FaultRecords.FindAsync(id);
            if (fridgeFault == null)
            {
                return NotFound();
            }
            ViewData["FaultTechnicianId"] = new SelectList(_db.FaultTechnicians, "Id", "Discriminator", fridgeFault.FaultTechnicianId);
            ViewData["FridgeAllocationId"] = new SelectList(_db.FridgeAllocations, "Id", "Id", fridgeFault.FridgeAllocationId);
            ViewData["ReportedById"] = new SelectList(_db.ApplicationUsers, "Id", "Id", fridgeFault.ReportedById);
            return View(fridgeFault);
        }

        // POST: FridgeFaults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FridgeAllocationId,FaultTechnicianId,ReportedById,Status,Description,Diagnosis,Priority,ReportedDate,AssignedDate,ResolvedDate,ResolutionNotes,CreatedAt,UpdatedAt,IsDeleted")] FridgeFault fridgeFault)
        {
            if (id != fridgeFault.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(fridgeFault);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FridgeFaultExists(fridgeFault.Id))
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
            ViewData["FaultTechnicianId"] = new SelectList(_db.FaultTechnicians, "Id", "Discriminator", fridgeFault.FaultTechnicianId);
            ViewData["FridgeAllocationId"] = new SelectList(_db.FridgeAllocations, "Id", "Id", fridgeFault.FridgeAllocationId);
            ViewData["ReportedById"] = new SelectList(_db.ApplicationUsers, "Id", "Id", fridgeFault.ReportedById);
            return View(fridgeFault);
        }

        // GET: FridgeFaults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeFault = await _db.FaultRecords
                .Include(f => f.FaultTechnician)
                .Include(f => f.FaultyFridge)
                .Include(f => f.ReportedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fridgeFault == null)
            {
                return NotFound();
            }

            return View(fridgeFault);
        }

        // POST: FridgeFaults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fridgeFault = await _db.FaultRecords.FindAsync(id);
            if (fridgeFault != null)
            {
                _db.FaultRecords.Remove(fridgeFault);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FridgeFaultExists(int id)
        {
            return _db.FaultRecords.Any(e => e.Id == id);
        }
    }
}
