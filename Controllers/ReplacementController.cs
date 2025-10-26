using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Utility;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize]
    public class ReplacementController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ReplacementController(ApplicationDbContext db)
        {
            _db = db;
        }

        // ---------------- CUSTOMER SIDE ----------------

        /// <summary>
        /// GET: Load the replacement request form for a customer's allocated fridge
        /// </summary>
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> Create(int fridgeId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Verify the logged-in customer owns this fridge
            var allocation = await _db.tblCustomerFridge
                .Include(cf => cf.Customer)
                .Include(cf => cf.FridgeInStock)
                .Include(cf => cf.Fridge)
                .FirstOrDefaultAsync(cf => cf.FridgeId == fridgeId &&
                                           cf.Customer.ApplicationUserId == userId);

            if (allocation == null)
            {
                TempData[SD.Error] = "You can only request replacements for fridges allocated to you.";
                return RedirectToAction("Index", "Request");
            }

            var model = new ReplacementRequest
            {
                FridgeInStockId = allocation.FridgeInStockId,
                CustomerId = allocation.Customer.CustomerID,
                RequestDate = DateTime.Now,
                Status = SD.Pending
            };

            // Pass fridge info for display in the view
            ViewBag.FridgeModel = allocation.Fridge.Model;
            ViewBag.SerialNumber = allocation.FridgeInStock.FridgeNo;

            return View(model);
        }

        /// <summary>
        /// POST: Save a customer's replacement request
        /// </summary>
        [Authorize(Roles = SD.CustomerRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReplacementRequest model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Verify again that the customer owns this fridge
            var allocation = await _db.tblCustomerFridge
                .Include(cf => cf.Customer)
                .FirstOrDefaultAsync(cf => cf.FridgeInStockId == model.FridgeInStockId &&
                                           cf.Customer.ApplicationUserId == userId);

            if (allocation == null)
            {
                TempData[SD.Error] = "You can only request replacements for fridges allocated to you.";
                return View(model);
            }

            model.CustomerId = allocation.Customer.CustomerID;
            model.RequestDate = DateTime.Now;
            model.Status = SD.Pending;

            await _db.tblReplacementRequests.AddAsync(model);
            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Replacement request submitted successfully.";
            return RedirectToAction(nameof(MyReplacements));
        }

        /// <summary>
        /// GET: View all replacement requests made by the logged-in customer
        /// </summary>
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> MyReplacements()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var replacements = await _db.tblReplacementRequests
                .Include(r => r.FridgeInStock)
                .Include(r => r.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Where(r => r.Customer.ApplicationUserId == userId)
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();

            return View(replacements);
        }

        // ---------------- SUPPORT SIDE ----------------

        /// <summary>
        /// GET: View all replacement requests for support staff
        /// </summary>
        [Authorize(Roles = SD.CustomerSupport + "," + SD.AdminRole)]
        public async Task<IActionResult> Manage()
        {
            var list = await _db.tblReplacementRequests
                .Include(r => r.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(r => r.FridgeInStock)
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();

            return View(list);
        }

        /// <summary>
        /// POST: Approve a replacement request
        /// </summary>
        [Authorize(Roles = SD.CustomerSupport + "," + SD.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var req = await _db.tblReplacementRequests.FindAsync(id);
            if (req == null)
                return NotFound();

            req.Status = SD.Approved;
            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Replacement approved successfully.";
            return RedirectToAction(nameof(Manage));
        }

        /// <summary>
        /// POST: Decline a replacement request with a reason
        /// </summary>
        [Authorize(Roles = SD.CustomerSupport + "," + SD.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decline(int id, string declineReason)
        {
            var req = await _db.tblReplacementRequests.FindAsync(id);
            if (req == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(declineReason))
            {
                TempData[SD.Error] = "Please provide a reason for decline.";
                return RedirectToAction(nameof(Manage));
            }

            req.Status = SD.Rejected;
            req.Reason = declineReason;
            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Replacement request declined.";
            return RedirectToAction(nameof(Manage));
        }
    }
}
