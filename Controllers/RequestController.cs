using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RequestController(ApplicationDbContext db)
        {
            _db = db;
        }

        // ====================== CUSTOMER & SUPPORT ======================

        // LIST REQUESTS
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IQueryable<RequestHeader> query = _db.tblRequestHeaders
                .Include(r => r.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges)
                    .ThenInclude(d => d.Fridge);

            if (User.IsInRole(SD.CustomerRole))
            {
                query = query.Where(r => r.Customer.ApplicationUserId == userId);
            }

            var requests = await query.OrderByDescending(r => r.RequestDate).ToListAsync();
            return View(requests);
        }

        // VIEW DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var request = await _db.tblRequestHeaders
                .Include(r => r.Customer).ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges).ThenInclude(d => d.Fridge)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == id);

            if (request == null)
                return NotFound();

            var notes = await _db.tblRequestNotes
                .Where(n => n.RequestHeaderId == id)
                .ToListAsync();

            var vm = new RequestVM
            {
                RequstHeader = request,
                RequstDetail = request.RequestFridges,
            };

            ViewBag.DeclineReason = notes.FirstOrDefault(n => n.NoteType == "DeclineReason")?.NoteContent;
            return View(vm);
        }


        // ====================== CUSTOMER SUPPORT ======================

        [Authorize(Roles = SD.CustomerSupport + "," + SD.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var header = await _db.tblRequestHeaders.FindAsync(id);
            if (header == null) return NotFound();

            header.Status = SD.Approved;
            header.RequestDate = DateTime.Now;
            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Request approved successfully.";
            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Roles = SD.CustomerSupport + "," + SD.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decline(int id, string declineReason)
        {
            if (string.IsNullOrWhiteSpace(declineReason))
            {
                TempData[SD.Error] = "Decline reason is required.";
                return RedirectToAction(nameof(Details), new { id });
            }

            var header = await _db.tblRequestHeaders.FindAsync(id);
            if (header == null) return NotFound();

            header.Status = SD.Rejected;
            header.RequestDate = DateTime.Now;

            // Store decline reason in a lightweight log table or header extension
            var declineNote = new RequestNote
            {
                RequestHeaderId = id,
                NoteType = "DeclineReason",
                NoteContent = declineReason,
                CreatedDate = DateTime.Now
            };
            _db.Add(declineNote);

            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Request declined successfully.";
            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Roles = SD.CustomerSupport + "," + SD.AdminRole)]
        public async Task<IActionResult> Dashboard(string statusFilter)
        {
            var query = _db.tblRequestHeaders
                .Include(r => r.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges)
                    .ThenInclude(d => d.Fridge)
                .AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter))
            {
                query = query.Where(r => r.Status == statusFilter);
            }

            var allRequests = await query.OrderByDescending(r => r.RequestDate).ToListAsync();

            // Summary counts for cards
            ViewBag.TotalPending = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Pending);
            ViewBag.TotalApproved = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Approved);
            ViewBag.TotalDeclined = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Rejected);
            ViewBag.TotalRelaunched = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Relaunched);

            ViewBag.SelectedStatus = statusFilter;

            return View("SupportDashboard", allRequests);
        }


        // ====================== CUSTOMER ======================

        [Authorize(Roles = SD.CustomerRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Relaunch(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var request = await _db.tblRequestHeaders
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == id && r.Customer.ApplicationUserId == userId);

            if (request == null)
            {
                TempData[SD.Error] = "Request not found.";
                return RedirectToAction(nameof(Index));
            }

            if (request.Status != SD.Rejected)
            {
                TempData[SD.Error] = "Only declined requests can be relaunched.";
                return RedirectToAction(nameof(Index));
            }

            request.Status = SD.Relaunched;
            request.RequestDate = DateTime.Now;
            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Request relaunched successfully.";
            return RedirectToAction(nameof(Index));
        }

        // ====================== REPLACEMENT / FAULTS CONTROL ======================

        [Authorize(Roles = SD.CustomerRole)]
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> CreateReplacement(int fridgeId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Verify that fridge belongs to this customer
            var allocated = await _db.tblCustomerFridge
                .Include(cf => cf.FridgeInStock)
                .FirstOrDefaultAsync(cf => cf.FridgeInStockId == fridgeId &&
                                           cf.Customer.ApplicationUserId == userId);

            if (allocated == null)
            {
                TempData[SD.Error] = "You can only request replacements for your allocated fridges.";
                return RedirectToAction(nameof(Index));
            }

            var model = new ReplacementRequest
            {
                FridgeInStockId = fridgeId,
                RequestDate = DateTime.Now,
                Status = SD.Pending
            };

            return View(model);
        }

        [Authorize(Roles = SD.CustomerRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReplacement(ReplacementRequest model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer.FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Index));
            }

            model.CustomerId = customer.CustomerID;
            model.RequestDate = DateTime.Now;
            model.Status = SD.Pending;

            _db.Add(model);
            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Replacement request submitted successfully.";
            return RedirectToAction(nameof(Index));
        }

        // ====================== UTILITIES ======================

        private bool RequestExists(int id)
        {
            return _db.tblRequestHeaders.Any(e => e.RequestHeaderId == id);
        }
    }

    // Optional: simple note entity for tracking decline reasons etc.
    public class RequestNote
    {
        public int RequestNoteId { get; set; }
        public int RequestHeaderId { get; set; }
        public string NoteType { get; set; } = string.Empty;
        public string NoteContent { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
