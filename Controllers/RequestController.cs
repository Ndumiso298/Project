using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public RequestVM RequestVM { get; set; }

        public RequestController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }





        public IActionResult Index(string status)
        {
            IEnumerable<RequestHeader> objRequestHeaders;

            if (User.IsInRole(SD.AdminRole) || User.IsInRole(SD.CustomerSupport))
            {
                objRequestHeaders = _db.tblRequestHeaders
                    .Include(a => a.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .ToList();
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                objRequestHeaders = _db.tblRequestHeaders
                    .Include(u => u.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .Where(r => r.Customer.ApplicationUserId == userId)
                    .ToList();
            }

            return View(objRequestHeaders);
        }

        public IActionResult Details(int id)
        {
            var requestHeader = _db.tblRequestHeaders
                .Include(r => r.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges)
                .ThenInclude(d => d.Fridge)
                .Include(r => r.RequestFridges)
                .ThenInclude(d => d.CustomerFridges)
                .ThenInclude(cf => cf.FridgeInStock)
                .FirstOrDefault(r => r.RequestHeaderId == id);

            if (requestHeader == null)
            {
                return NotFound();
            }

            RequestVM = new RequestVM
            {
                RequstHeader = requestHeader,
                RequstDetail = requestHeader.RequestFridges.ToList()
            };

            return View(RequestVM);
        }

        [HttpPost]
        public IActionResult UpdateRequestDetail(RequestVM RequestVM)
        {
            if (RequestVM == null || RequestVM.RequstHeader == null)
            {
                return BadRequest("Invalid request data.");
            }

            var RequestHeaderFromDb = _db.tblRequestHeaders
                .FirstOrDefault(u => u.RequestHeaderId == RequestVM.RequstHeader.RequestHeaderId);

            if (RequestHeaderFromDb == null)
            {
                return NotFound("Request not found.");
            }

            RequestHeaderFromDb.FirstName = RequestVM.RequstHeader.FirstName;
            RequestHeaderFromDb.LastName = RequestVM.RequstHeader.LastName;
            RequestHeaderFromDb.CellNumber = RequestVM.RequstHeader.CellNumber;
            RequestHeaderFromDb.StreetAddress = RequestVM.RequstHeader.StreetAddress;
            RequestHeaderFromDb.City = RequestVM.RequstHeader.City;
            RequestHeaderFromDb.State = RequestVM.RequstHeader.State;
            RequestHeaderFromDb.PostalCode = RequestVM.RequstHeader.PostalCode;

            _db.tblRequestHeaders.Update(RequestHeaderFromDb);
            _db.SaveChanges();

            TempData[SD.Success] = "Order Details Updated Successfully.";

            return RedirectToAction(nameof(Details), new { id = RequestHeaderFromDb.RequestHeaderId });
        }

        [HttpPost]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupport)]
        public async Task<IActionResult> Approve(RequestVM RequestVM)
        {
            if (RequestVM == null || RequestVM.RequstHeader == null)
            {
                return BadRequest("Invalid request data.");
            }

            var requestHeaderFromDb = await _db.tblRequestHeaders
                .Include(r => r.RequestFridges)
                    .ThenInclude(d => d.Fridge)
                .Include(r => r.RequestFridges)
                    .ThenInclude(d => d.CustomerFridges)
                        .ThenInclude(cf => cf.FridgeInStock)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == RequestVM.RequstHeader.RequestHeaderId);

            if (requestHeaderFromDb == null)
            {
                return NotFound("Request not found.");
            }

            requestHeaderFromDb.Status = SD.Approved;
            requestHeaderFromDb.RequestDate = DateTime.Now;

            _db.tblRequestHeaders.Update(requestHeaderFromDb);
            await _db.SaveChangesAsync();

            await ReserveApprovedFridges(requestHeaderFromDb);

            TempData[SD.Success] = "Request approved successfully.";

            return RedirectToAction(nameof(Details), new { id = requestHeaderFromDb.RequestHeaderId });
        }

        private async Task ReserveApprovedFridges(RequestHeader requestHeader)
        {
            var fridgesInStock = await _db.tblFridgeInStocks.Where(x => x.IsAvailable).ToListAsync();

            foreach (var detail in requestHeader.RequestFridges)
            {
                if (detail == null) continue;

                var availableFridges = fridgesInStock
                    .Where(x => x.FridgeId == detail.FridgeId)
                    .Take(detail.Count)
                    .ToList();

                foreach (var f in availableFridges)
                {
                    var customerFridge = new CustomerFridge
                    {
                        CustomerID = requestHeader.CustomerID,
                        FridgeId = detail.FridgeId,
                        FridgeInStockId = f.FridgeInStockId,
                        RequestDetailId = detail.RequestDetailId,
                        ReservedDate = DateTime.Now
                    };
                    _db.tblCustomerFridge.Add(customerFridge);

                    f.IsAvailable = false;
                    _db.tblFridgeInStocks.Update(f);
                }
            }

            await _db.SaveChangesAsync();
        }

        [HttpPost]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupport)]
        public IActionResult Reject(RequestVM RequestVM)
        {
            if (RequestVM == null || RequestVM.RequstHeader == null)
            {
                return BadRequest("Invalid request data.");
            }

            var requestHeaderFromDb = _db.tblRequestHeaders
                .FirstOrDefault(u => u.RequestHeaderId == RequestVM.RequstHeader.RequestHeaderId);

            if (requestHeaderFromDb == null)
            {
                return NotFound("Request not found.");
            }

            requestHeaderFromDb.Status = SD.Rejected;
            requestHeaderFromDb.RejectionReason = RequestVM.RequstHeader.RejectionReason;
            requestHeaderFromDb.RejectionDate = DateTime.Now;

            _db.tblRequestHeaders.Update(requestHeaderFromDb);
            _db.SaveChanges();

            TempData[SD.Success] = "Request rejected successfully.";

            return RedirectToAction(nameof(Details), new { id = requestHeaderFromDb.RequestHeaderId });
        }

        [HttpPost]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupport)]
        public IActionResult Feedback(RequestVM RequestVM)
        {
            if (RequestVM == null || RequestVM.RequstHeader == null)
            {
                return BadRequest("Invalid request data.");
            }

            var requestHeaderFromDb = _db.tblRequestHeaders
                .FirstOrDefault(u => u.RequestHeaderId == RequestVM.RequstHeader.RequestHeaderId);

            if (requestHeaderFromDb == null)
            {
                return NotFound("Request not found.");
            }

            requestHeaderFromDb.RequestDate = DateTime.Now;

            _db.tblRequestHeaders.Update(requestHeaderFromDb);
            _db.SaveChanges();

            TempData[SD.Success] = "Request marked as needing feedback.";

            return RedirectToAction(nameof(Details), new { id = requestHeaderFromDb.RequestHeaderId });
        }

        [HttpPost]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupport)]
        public IActionResult ShipOrder()
        {
            var RequestHeader = _db.tblRequestHeaders.
                FirstOrDefault(u => u.RequestHeaderId == RequestVM.RequstHeader.RequestHeaderId);

            RequestHeader.Carrier = RequestVM.RequstHeader.Carrier;
            RequestHeader.ShippingDate = DateTime.Now;

            _db.tblRequestHeaders.Update(RequestHeader);
            _db.SaveChanges();

            TempData[SD.Success] = "Order Shipped Successfully.";
            return RedirectToAction(nameof(Details), new { requesId = RequestVM.RequstHeader.RequestHeaderId });
        }

        // RELAUNCH REQUEST FUNCTIONALITY - CUSTOMER ONLY
        // Inside Project/Controllers/RequestController.cs
        // ... existing code ...

        // GET: Relaunch Request
        [HttpGet]
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> RelaunchRequest(int id)
        {
            try
            {
                var originalRequest = await _db.tblRequestHeaders
                    .Include(r => r.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .Include(r => r.RequestFridges)
                        .ThenInclude(d => d.Fridge)
                    .FirstOrDefaultAsync(r => r.RequestHeaderId == id && r.Status == SD.Rejected);

                if (originalRequest == null)
                {
                    TempData[SD.Error] = "Request not found or not in rejected state.";
                    return RedirectToAction(nameof(Index));
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (originalRequest.Customer?.ApplicationUserId != userId)
                {
                    TempData[SD.Error] = "You can only relaunch your own requests.";
                    return RedirectToAction(nameof(Index));
                }

                var vm = new RelaunchRequestVM
                {
                    OriginalRequestId = originalRequest.RequestHeaderId,
                    RejectionReason = originalRequest.RejectionReason ?? "No reason provided.",
                    CustomerName = $"{originalRequest.Customer.ApplicationUser.FirstName} {originalRequest.Customer.ApplicationUser.LastName}",
                    OriginalRequestDate = originalRequest.RequestDate,
                    RejectionDate = originalRequest.RejectionDate,
                    OriginalFridges = originalRequest.RequestFridges?.ToList() ?? new List<RequestDetails>()
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = "Error loading request: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Relaunch Request
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> RelaunchRequest(RelaunchRequestVM vm, IFormFile? AdditionalDocument)
        {
            if (!ModelState.IsValid)
            {
                await ReloadRelaunchVMData(vm);
                return View(vm);
            }

            var originalRequest = await _db.tblRequestHeaders
                .Include(r => r.RequestFridges)
                .Include(r => r.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == vm.OriginalRequestId);

            if (originalRequest == null)
            {
                TempData[SD.Error] = "Original request not found.";
                return RedirectToAction(nameof(Index));
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (originalRequest.Customer?.ApplicationUserId != userId)
            {
                TempData[SD.Error] = "Unauthorized access.";
                return RedirectToAction(nameof(Index));
            }

            // File validation
            string? documentPath = null;
            if (AdditionalDocument != null && AdditionalDocument.Length > 0)
            {
                if (AdditionalDocument.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("AdditionalDocument", "File size must be ≤ 5MB.");
                    await ReloadRelaunchVMData(vm);
                    return View(vm);
                }

                var allowed = new[] { ".pdf", ".jpg", ".jpeg", ".png", ".doc", ".docx" };
                var ext = Path.GetExtension(AdditionalDocument.FileName).ToLowerInvariant();
                if (!allowed.Contains(ext))
                {
                    ModelState.AddModelError("AdditionalDocument", "Invalid file type.");
                    await ReloadRelaunchVMData(vm);
                    return View(vm);
                }

                var fileName = Guid.NewGuid() + ext;
                var uploadDir = Path.Combine("uploads", "additional-documents");
                var fullDir = Path.Combine(_webHostEnvironment.WebRootPath, uploadDir);

                if (!Directory.Exists(fullDir))
                    Directory.CreateDirectory(fullDir);

                var filePath = Path.Combine(fullDir, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await AdditionalDocument.CopyToAsync(stream);
                }

                documentPath = Path.Combine(uploadDir, fileName).Replace("\\", "/");
            }

            // Create new request
            var newRequest = new RequestHeader
            {
                CustomerID = originalRequest.CustomerID,
                FirstName = originalRequest.FirstName,
                LastName = originalRequest.LastName,
                CellNumber = originalRequest.CellNumber,
                StreetAddress = originalRequest.StreetAddress,
                City = originalRequest.City,
                State = originalRequest.State,
                PostalCode = originalRequest.PostalCode,
                RequestDate = DateTime.Now,
                Status = SD.Pending,
                AdditionalDescription = vm.AdditionalDescription,
                AdditionalDocumentPath = documentPath,
                IsRelaunched = true,
                OriginalRequestId = originalRequest.RequestHeaderId
            };

            _db.tblRequestHeaders.Add(newRequest);
            await _db.SaveChangesAsync();

            // Copy fridge details
            foreach (var detail in originalRequest.RequestFridges)
            {
                _db.tblRequestDetais.Add(new RequestDetails
                {
                    RequestHeaderId = newRequest.RequestHeaderId,
                    FridgeId = detail.FridgeId,
                    Count = detail.Count,
                    Price = detail.Price
                });
            }
            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Request relaunched successfully!";
            return RedirectToAction(nameof(Details), new { id = newRequest.RequestHeaderId });
        }

        // Helper to reload data on validation fail
        private async Task ReloadRelaunchVMData(RelaunchRequestVM vm)
        {
            var req = await _db.tblRequestHeaders
                .Include(r => r.RequestFridges).ThenInclude(d => d.Fridge)
                .Include(r => r.Customer).ThenInclude(c => c.ApplicationUser)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == vm.OriginalRequestId);

            if (req != null)
            {
                vm.RejectionReason = req.RejectionReason ?? "No reason provided.";
                vm.CustomerName = $"{req.Customer.ApplicationUser.FirstName} {req.Customer.ApplicationUser.LastName}";
                vm.OriginalRequestDate = req.RequestDate;
                vm.RejectionDate = req.RejectionDate;
                vm.OriginalFridges = req.RequestFridges?.ToList() ?? new();
            }
        }
    }
}