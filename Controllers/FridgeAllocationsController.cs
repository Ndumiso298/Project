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
    [Authorize(Roles = StaticDetails.AdminRole + "," + StaticDetails.CustomerSupportRole)]
    public class FridgeAllocationsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FridgeAllocationsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: FridgeAllocations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.FridgeAllocations.Include(f => f.Customer).Include(f => f.CustomerLiaison).Include(f => f.Fridge);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FridgeAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeAllocation = await _db.FridgeAllocations
                .Include(f => f.Customer)
                .Include(f => f.CustomerLiaison)
                .Include(f => f.Fridge)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fridgeAllocation == null)
            {
                return NotFound();
            }

            return View(fridgeAllocation);
        }

        // GET: FridgeAllocations/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "BusinessEmail");
            ViewData["CustomerLiaisonId"] = new SelectList(_db.CustomerLiaisons, "Id", "Discriminator");
            ViewData["FridgeId"] = new SelectList(_db.Fridges, "Id", "Condition");
            return View();
        }

        // POST: FridgeAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FridgeId,CustomerId,CustomerLiaisonId,Status,AllocationDate,ExpectedReturnDate,ActualReturnDate,ServiceIntervalMonths,LastServiceDate,NextServiceDue,Notes,CreatedAt,UpdatedAt,IsDeleted")] FridgeAllocation fridgeAllocation)
        {
            if (ModelState.IsValid)
            {
                _db.Add(fridgeAllocation);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "BusinessEmail", fridgeAllocation.CustomerId);
            ViewData["CustomerLiaisonId"] = new SelectList(_db.CustomerLiaisons, "Id", "Discriminator", fridgeAllocation.CustomerLiaisonId);
            ViewData["FridgeId"] = new SelectList(_db.Fridges, "Id", "Condition", fridgeAllocation.FridgeId);
            return View(fridgeAllocation);
        }

        // GET: FridgeAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeAllocation = await _db.FridgeAllocations.FindAsync(id);
            if (fridgeAllocation == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "BusinessEmail", fridgeAllocation.CustomerId);
            ViewData["CustomerLiaisonId"] = new SelectList(_db.CustomerLiaisons, "Id", "Discriminator", fridgeAllocation.CustomerLiaisonId);
            ViewData["FridgeId"] = new SelectList(_db.Fridges, "Id", "Condition", fridgeAllocation.FridgeId);
            return View(fridgeAllocation);
        }

        // POST: FridgeAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FridgeId,CustomerId,CustomerLiaisonId,Status,AllocationDate,ExpectedReturnDate,ActualReturnDate,ServiceIntervalMonths,LastServiceDate,NextServiceDue,Notes,CreatedAt,UpdatedAt,IsDeleted")] FridgeAllocation fridgeAllocation)
        {
            if (id != fridgeAllocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(fridgeAllocation);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FridgeAllocationExists(fridgeAllocation.Id))
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
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "BusinessEmail", fridgeAllocation.CustomerId);
            ViewData["CustomerLiaisonId"] = new SelectList(_db.CustomerLiaisons, "Id", "Discriminator", fridgeAllocation.CustomerLiaisonId);
            ViewData["FridgeId"] = new SelectList(_db.Fridges, "Id", "Condition", fridgeAllocation.FridgeId);
            return View(fridgeAllocation);
        }

        // GET: FridgeAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeAllocation = await _db.FridgeAllocations
                .Include(f => f.Customer)
                .Include(f => f.CustomerLiaison)
                .Include(f => f.Fridge)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fridgeAllocation == null)
            {
                return NotFound();
            }

            return View(fridgeAllocation);
        }

        // POST: FridgeAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fridgeAllocation = await _db.FridgeAllocations.FindAsync(id);
            if (fridgeAllocation != null)
            {
                _db.FridgeAllocations.Remove(fridgeAllocation);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FridgeAllocationExists(int id)
        {
            return _db.FridgeAllocations.Any(e => e.Id == id);
        }
    }
}
