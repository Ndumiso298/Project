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
                    .Include(a => a.Customer) // Add this include
                        .ThenInclude(c => c.ApplicationUser) // Add this include
                    .ToList();
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                objRequestHeaders = _db.tblRequestHeaders
                    .Include(u => u.Customer) // Add this include
                        .ThenInclude(c => c.ApplicationUser) // Add this include
                    .Where(r => r.Customer.ApplicationUserId == userId)
                    .ToList();
            }

            return View(objRequestHeaders);
        }

        public IActionResult Details(int id)
        {
            // Fetch full request data with all related entities
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
        [HttpGet]
        [Authorize(Roles = SD.CustomerRole)]
        public IActionResult RelaunchRequest(int id)
        {
            // Get the original rejected request with ALL required includes
            var originalRequest = _db.tblRequestHeaders
                .Include(r => r.Customer)
                    .ThenInclude(c => c.ApplicationUser) // Include ApplicationUser
                .Include(r => r.RequestFridges)
                    .ThenInclude(d => d.Fridge)
                .FirstOrDefault(r => r.RequestHeaderId == id && r.Status == SD.Rejected);

            if (originalRequest == null)
            {
                TempData[SD.Error] = "Original request not found or not rejected.";
                return RedirectToAction(nameof(Index));
            }

            // Check if Customer and ApplicationUser are not null
            if (originalRequest.Customer == null || originalRequest.Customer.ApplicationUser == null)
            {
                TempData[SD.Error] = "Customer information not found for this request.";
                return RedirectToAction(nameof(Index));
            }

            // Check if the current user owns this request
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (originalRequest.Customer.ApplicationUserId != userId)
            {
                TempData[SD.Error] = "You can only relaunch your own requests.";
                return RedirectToAction(nameof(Index));
            }

            // Create view model for relaunch with null checks
            var relaunchVM = new RelaunchRequestVM
            {
                OriginalRequestId = originalRequest.RequestHeaderId,
                RejectionReason = originalRequest.RejectionReason ?? "No reason provided",
                CustomerName = $"{originalRequest.Customer.ApplicationUser.FirstName} {originalRequest.Customer.ApplicationUser.LastName}",
                OriginalRequestDate = originalRequest.RequestDate,
                RejectionDate = originalRequest.RejectionDate,
                OriginalFridges = originalRequest.RequestFridges?.ToList() ?? new List<RequestDetails>()
            };

            return View(relaunchVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> RelaunchRequest(RelaunchRequestVM relaunchVM)
        {
            if (!ModelState.IsValid)
            {
                // Reload the original data if validation fails
                await ReloadRelaunchVMData(relaunchVM);
                return View(relaunchVM);
            }

            try
            {
                // Get original request with all required includes
                var originalRequest = await _db.tblRequestHeaders
                    .Include(r => r.RequestFridges)
                    .Include(r => r.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .FirstOrDefaultAsync(r => r.RequestHeaderId == relaunchVM.OriginalRequestId);

                if (originalRequest == null)
                {
                    TempData[SD.Error] = "Original request not found.";
                    return RedirectToAction(nameof(Index));
                }

                // Verify the current user owns this request
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                if (originalRequest.Customer?.ApplicationUserId != userId)
                {
                    TempData[SD.Error] = "You can only relaunch your own requests.";
                    return RedirectToAction(nameof(Index));
                }

                // Create new request based on original
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
                    AdditionalDescription = relaunchVM.AdditionalDescription,
                    IsRelaunched = true,
                    OriginalRequestId = originalRequest.RequestHeaderId
                };

                // Handle file upload
                if (relaunchVM.AdditionalDocument != null && relaunchVM.AdditionalDocument.Length > 0)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(relaunchVM.AdditionalDocument.FileName);
                    string requestPath = Path.Combine("uploads", "additional-documents");

                    string finalPath = Path.Combine(wwwRootPath, requestPath);

                    if (!Directory.Exists(finalPath))
                    {
                        Directory.CreateDirectory(finalPath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                    {
                        await relaunchVM.AdditionalDocument.CopyToAsync(fileStream);
                    }

                    newRequest.AdditionalDocumentPath = Path.Combine(requestPath, fileName).Replace("\\", "/");
                }

                // Add to database
                _db.tblRequestHeaders.Add(newRequest);
                await _db.SaveChangesAsync();

                // Copy request details (fridges) from original request
                if (originalRequest.RequestFridges != null)
                {
                    foreach (var originalDetail in originalRequest.RequestFridges)
                    {
                        var newDetail = new RequestDetails
                        {
                            RequestHeaderId = newRequest.RequestHeaderId,
                            FridgeId = originalDetail.FridgeId,
                            Count = originalDetail.Count,
                            Price = originalDetail.Price
                        };
                        _db.tblRequestDetais.Add(newDetail);
                    }
                }

                await _db.SaveChangesAsync();

                TempData[SD.Success] = "Request relaunched successfully with additional information. It will be reviewed again.";
                return RedirectToAction(nameof(Details), new { id = newRequest.RequestHeaderId });
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error relaunching request: {ex.Message}";

                // Reload original data for the view
                await ReloadRelaunchVMData(relaunchVM);
                return View(relaunchVM);
            }
        }

        // Helper method to reload data for the view model
        private async Task ReloadRelaunchVMData(RelaunchRequestVM relaunchVM)
        {
            var originalRequest = await _db.tblRequestHeaders
                .Include(r => r.RequestFridges)
                    .ThenInclude(d => d.Fridge)
                .Include(r => r.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == relaunchVM.OriginalRequestId);

            if (originalRequest != null)
            {
                relaunchVM.OriginalFridges = originalRequest.RequestFridges?.ToList() ?? new List<RequestDetails>();
                relaunchVM.RejectionReason = originalRequest.RejectionReason ?? "No reason provided";

                if (originalRequest.Customer?.ApplicationUser != null)
                {
                    relaunchVM.CustomerName = $"{originalRequest.Customer.ApplicationUser.FirstName} {originalRequest.Customer.ApplicationUser.LastName}";
                }
                else
                {
                    relaunchVM.CustomerName = "Customer information not available";
                }

                relaunchVM.OriginalRequestDate = originalRequest.RequestDate;
                relaunchVM.RejectionDate = originalRequest.RejectionDate;
            }
        }
    }
}