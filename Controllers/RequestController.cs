using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;

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

        // ====================== SHARED ACTIONS ======================

        // LIST REQUESTS (Customer sees own, Support sees all)
        public async Task<IActionResult> Index(string statusFilter = null)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isSupport = User.IsInRole(SD.CustomerSupport) || User.IsInRole(SD.AdminRole);

            IQueryable<RequestHeader> query = _db.tblRequestHeaders
                .Include(r => r.Customer).ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges).ThenInclude(d => d.Fridge)
                .Include(r => r.Employee);

            if (!isSupport)
            {
                query = query.Where(r => r.Customer.ApplicationUserId == userId);
            }

            if (!string.IsNullOrEmpty(statusFilter))
            {
                query = query.Where(r => r.Status == statusFilter);
            }

            var requests = await query.OrderByDescending(r => r.RequestDate).ToListAsync();

            ViewBag.IsSupport = isSupport;
            ViewBag.SelectedStatus = statusFilter;

            // For support dashboard summary
            if (isSupport)
            {
                ViewBag.TotalPending = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Pending);
                ViewBag.TotalApproved = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Approved);
                ViewBag.TotalRejected = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Rejected);
                ViewBag.TotalRelaunched = await _db.tblRequestHeaders.CountAsync(r => r.IsRelaunched);
            }

            return View(requests);
        }
        // VIEW REQUEST DETAILS (With decline reason if applicable)
        public async Task<IActionResult> Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isSupport = User.IsInRole(SD.CustomerSupport) || User.IsInRole(SD.AdminRole);

            var request = await _db.tblRequestHeaders
                .Include(r => r.Customer).ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges).ThenInclude(d => d.Fridge)
                .Include(r => r.RelaunchedRequests) // Include relaunched requests
                .Include(r => r.OriginalRequest)    // Include original request if this is a relaunch
                .FirstOrDefaultAsync(r => r.RequestHeaderId == id);

            if (request == null)
            {
                return NotFound();
            }

            // Security check for customers
            if (!isSupport && request.Customer.ApplicationUserId != userId)
            {
                TempData[SD.Error] = "You are not authorized to view this request.";
                return RedirectToAction(nameof(Index));
            }

            // Load decline reason if rejected
            var declineNote = await _db.tblRequestNotes
                .FirstOrDefaultAsync(n => n.RequestHeaderId == id && n.NoteType == "DeclineReason");

            // Check if customer has allocated fridges for replacement requests
            var hasAllocatedFridges = await _db.tblCustomerFridge
                .AnyAsync(cf => cf.CustomerID == request.CustomerID);

            ViewBag.DeclineReason = declineNote?.NoteContent;
            ViewBag.IsSupport = isSupport;
            ViewBag.CanRelaunch = !isSupport && request.Status == SD.Rejected;
            ViewBag.HasAllocatedFridges = hasAllocatedFridges;

            var vm = new RequestVM
            {
                RequstHeader = request,
                RequstDetail = request.RequestFridges
            };

            return View(vm);
        }

        // ====================== CUSTOMER ACTIONS ======================

        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> CreateFridgeRequest()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Index));
            }

            // Pre-populate with customer data
            var model = new RequestHeader
            {
                FirstName = customer.ApplicationUser.FirstName,
                LastName = customer.ApplicationUser.LastName,
                CellNumber = customer.ApplicationUser.CellNumber ?? "",
                StreetAddress = customer.ApplicationUser.StreetAddress ?? "",
                City = customer.ApplicationUser.City ?? "",
                State = customer.ApplicationUser.State ?? "",
                PostalCode = customer.ApplicationUser.PostalCode ?? ""
            };

            return View(model);
        }

        [Authorize(Roles = SD.CustomerRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFridgeRequest(RequestHeader model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer.FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                model.CustomerID = customer.CustomerID;
                model.RequestDate = DateTime.Now;
                model.Status = SD.Pending;
                model.RequestTotal = 0; // Update if needed

                _db.tblRequestHeaders.Add(model);
                await _db.SaveChangesAsync();

                TempData[SD.Success] = "Fridge request submitted successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Authorize(Roles = SD.CustomerRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Relaunch(int id, string additionalInfo = null)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var originalRequest = await _db.tblRequestHeaders
                .Include(r => r.Customer)
                .Include(r => r.RequestFridges)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == id && r.Customer.ApplicationUserId == userId);

            if (originalRequest == null)
            {
                TempData[SD.Error] = "Request not found.";
                return RedirectToAction(nameof(Index));
            }

            if (originalRequest.Status != SD.Rejected)
            {
                TempData[SD.Error] = "Only declined requests can be relaunched.";
                return RedirectToAction(nameof(Index));
            }

            // Create a new request based on the original
            var newRequest = new RequestHeader
            {
                CustomerID = originalRequest.CustomerID,
                RequestDate = DateTime.Now,
                RequestTotal = originalRequest.RequestTotal,
                FirstName = originalRequest.FirstName,
                LastName = originalRequest.LastName,
                StreetAddress = originalRequest.StreetAddress,
                City = originalRequest.City,
                State = originalRequest.State,
                PostalCode = originalRequest.PostalCode,
                CellNumber = originalRequest.CellNumber,
                Status = SD.Pending,
                PaymentDueDate = DateTime.Now.AddDays(7),
                IsRelaunched = true,
                OriginalRequestHeaderId = id
            };

            _db.tblRequestHeaders.Add(newRequest);
            await _db.SaveChangesAsync();

            // Copy request details
            foreach (var detail in originalRequest.RequestFridges)
            {
                var newDetail = new RequestDetails
                {
                    RequestHeaderId = newRequest.RequestHeaderId,
                    FridgeId = detail.FridgeId,
                    Count = detail.Count,
                    Price = detail.Price
                };
                _db.tblRequestDetais.Add(newDetail);
            }

            // Add additional info as a note if provided
            if (!string.IsNullOrEmpty(additionalInfo))
            {
                var note = new RequestNote
                {
                    RequestHeaderId = newRequest.RequestHeaderId,
                    NoteType = "RelaunchInfo",
                    NoteContent = additionalInfo,
                    CreatedDate = DateTime.Now
                };
                _db.tblRequestNotes.Add(note);
            }

            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Request relaunched successfully.";
            return RedirectToAction(nameof(Index));
        }

        // ====================== SUPPORT ACTIONS ======================

        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var request = await _db.tblRequestHeaders
                .Include(r => r.RequestFridges)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == id);

            if (request == null)
            {
                return NotFound();
            }

            request.Status = SD.Approved;
            request.RequestDate = DateTime.Now;

            _db.tblRequestHeaders.Update(request);
            await _db.SaveChangesAsync();

            // Allocate fridges
            await ReserveApprovedFridges(request);

            TempData[SD.Success] = "Request approved and fridges allocated successfully.";
            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id, string rejectReason)
        {
            if (string.IsNullOrWhiteSpace(rejectReason))
            {
                TempData[SD.Error] = "Reject reason is required.";
                return RedirectToAction(nameof(Details), new { id });
            }

            var request = await _db.tblRequestHeaders.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            request.Status = SD.Rejected;
            request.RequestDate = DateTime.Now;

            var note = new RequestNote
            {
                RequestHeaderId = id,
                NoteType = "DeclineReason",
                NoteContent = rejectReason,
                CreatedDate = DateTime.Now
            };

            _db.tblRequestNotes.Add(note);
            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Request rejected successfully.";
            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<IActionResult> Dashboard(string statusFilter)
        {
            var query = _db.tblRequestHeaders
                .Include(r => r.Customer).ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges).ThenInclude(d => d.Fridge)
                .AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter))
            {
                query = query.Where(r => r.Status == statusFilter);
            }

            var allRequests = await query.OrderByDescending(r => r.RequestDate).ToListAsync();

            // Summary counts for cards
            ViewBag.TotalPending = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Pending);
            ViewBag.TotalApproved = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Approved);
            ViewBag.TotalRejected = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Rejected);
            ViewBag.TotalRelaunched = await _db.tblRequestHeaders.CountAsync(r => r.IsRelaunched);

            ViewBag.SelectedStatus = statusFilter;

            return View("SupportDashboard", allRequests);
        }

        // ====================== PRIVATE METHODS ======================

        private async Task ReserveApprovedFridges(RequestHeader requestHeader)
        {
            foreach (var detail in requestHeader.RequestFridges)
            {
                // Find available stock instances for this fridge model
                var availableStocks = await _db.tblFridgeInStocks
                    .Where(s => s.FridgeId == detail.FridgeId && s.IsAvailable)
                    .Take(detail.Count)
                    .ToListAsync();

                if (availableStocks.Count < detail.Count)
                {
                    // Handle insufficient stock
                    throw new Exception($"Insufficient stock for fridge ID {detail.FridgeId}");
                }

                foreach (var stock in availableStocks)
                {
                    stock.IsAvailable = false;
                    _db.tblFridgeInStocks.Update(stock);

                    // Allocate to customer
                    var allocation = new CustomerFridge
                    {
                        CustomerID = requestHeader.CustomerID,
                        FridgeId = detail.FridgeId,
                        FridgeInStockId = stock.FridgeInStockId,
                        ReservedDate = DateTime.Now,
                        AllocatedDate = DateTime.Now
                    };
                    _db.tblCustomerFridge.Add(allocation);
                }
            }

            await _db.SaveChangesAsync();
        }
    }
}