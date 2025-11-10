using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Project.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RequestController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(string status)
        {
            IQueryable<RequestHeader> query;

            if (User.IsInRole(SD.AdminRole) || User.IsInRole(SD.CustomerSupport))
            {
                query = _db.tblRequestHeaders
                    .Include(a => a.Customer)
                        .ThenInclude(c => c.ApplicationUser);
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Challenge();
                }

                query = _db.tblRequestHeaders
                    .Include(u => u.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .Where(r => r.Customer.ApplicationUserId == userId);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(r => r.Status == status);
            }

            var objRequestHeaders = query.ToList();
            ViewBag.StatusFilter = status;
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
                TempData[SD.Error] = "Request not found.";
                return RedirectToAction(nameof(Index));
            }

            if (!User.IsInRole(SD.AdminRole) && !User.IsInRole(SD.CustomerSupport))
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (requestHeader.Customer?.ApplicationUserId != userId)
                {
                    TempData[SD.Error] = "You don't have permission to view this request.";
                    return RedirectToAction(nameof(Index));
                }
            }

            var requestVM = new RequestVM
            {
                RequstHeader = requestHeader,
                RequstDetail = requestHeader.RequestFridges != null ? requestHeader.RequestFridges.ToList() : new List<RequestDetails>()
            };

            // Add carriers and cancellation reasons for admin/support users
            if (User.IsInRole(SD.AdminRole) || User.IsInRole(SD.CustomerSupport))
            {
                ViewBag.Carriers = GetAvailableCarriers();
            }

            // Add cancellation reasons for customers
            if (User.IsInRole(SD.CustomerRole))
            {
                ViewBag.CancellationReasons = GetCancellationReasons();
            }

            return View(requestVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateRequestDetail(RequestVM requestVM)
        {
            if (requestVM?.RequstHeader == null)
            {
                TempData[SD.Error] = "Invalid request data.";
                return RedirectToAction(nameof(Index));
            }

            var requestHeaderFromDb = _db.tblRequestHeaders
                .FirstOrDefault(u => u.RequestHeaderId == requestVM.RequstHeader.RequestHeaderId);

            if (requestHeaderFromDb == null)
            {
                TempData[SD.Error] = "Request not found.";
                return RedirectToAction(nameof(Index));
            }

            if (!User.IsInRole(SD.AdminRole) && !User.IsInRole(SD.CustomerSupport))
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (requestHeaderFromDb.Customer?.ApplicationUserId != userId)
                {
                    TempData[SD.Error] = "You don't have permission to update this request.";
                    return RedirectToAction(nameof(Details), new { id = requestVM.RequstHeader.RequestHeaderId });
                }
            }

            requestHeaderFromDb.FirstName = requestVM.RequstHeader.FirstName;
            requestHeaderFromDb.LastName = requestVM.RequstHeader.LastName;
            requestHeaderFromDb.CellNumber = requestVM.RequstHeader.CellNumber;
            requestHeaderFromDb.StreetAddress = requestVM.RequstHeader.StreetAddress;
            requestHeaderFromDb.City = requestVM.RequstHeader.City;
            requestHeaderFromDb.State = requestVM.RequstHeader.State;
            requestHeaderFromDb.PostalCode = requestVM.RequstHeader.PostalCode;

            _db.tblRequestHeaders.Update(requestHeaderFromDb);
            _db.SaveChanges();

            TempData[SD.Success] = "Order details updated successfully.";
            return RedirectToAction(nameof(Details), new { id = requestHeaderFromDb.RequestHeaderId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupport)]
        public async Task<IActionResult> Approve(RequestVM requestVM)
        {
            if (requestVM?.RequstHeader == null)
            {
                TempData[SD.Error] = "Invalid request data.";
                return RedirectToAction(nameof(Index));
            }

            var requestHeaderFromDb = await _db.tblRequestHeaders
                .Include(r => r.RequestFridges)
                    .ThenInclude(d => d.Fridge)
                .Include(r => r.RequestFridges)
                    .ThenInclude(d => d.CustomerFridges)
                        .ThenInclude(cf => cf.FridgeInStock)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == requestVM.RequstHeader.RequestHeaderId);

            if (requestHeaderFromDb == null)
            {
                TempData[SD.Error] = "Request not found.";
                return RedirectToAction(nameof(Index));
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

            if (requestHeader.RequestFridges != null)
            {
                foreach (var detail in requestHeader.RequestFridges)
                {
                    var availableFridges = fridgesInStock
                        .Where(x => x.FridgeId == detail.FridgeId)
                        .Take(detail.Count)
                        .ToList();

                    foreach (var fridge in availableFridges)
                    {
                        var customerFridge = new CustomerFridge
                        {
                            CustomerID = requestHeader.CustomerID,
                            FridgeId = detail.FridgeId,
                            FridgeInStockId = fridge.FridgeInStockId,
                            RequestDetailId = detail.RequestDetailId,
                            ReservedDate = DateTime.Now
                        };
                        _db.tblCustomerFridge.Add(customerFridge);

                        fridge.IsAvailable = false;
                        _db.tblFridgeInStocks.Update(fridge);
                    }
                }

                await _db.SaveChangesAsync();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupport)]
        public IActionResult Reject(RequestVM requestVM)
        {
            if (requestVM?.RequstHeader == null)
            {
                TempData[SD.Error] = "Invalid request data.";
                return RedirectToAction(nameof(Index));
            }

            var requestHeaderFromDb = _db.tblRequestHeaders
                .FirstOrDefault(u => u.RequestHeaderId == requestVM.RequstHeader.RequestHeaderId);

            if (requestHeaderFromDb == null)
            {
                TempData[SD.Error] = "Request not found.";
                return RedirectToAction(nameof(Index));
            }

            // Validate rejection reason
            if (string.IsNullOrEmpty(requestVM.RequstHeader.RejectionReason) || string.IsNullOrWhiteSpace(requestVM.RequstHeader.RejectionReason))
            {
                TempData[SD.Error] = "Rejection reason is required.";
                return RedirectToAction(nameof(Details), new { id = requestVM.RequstHeader.RequestHeaderId });
            }

            if (requestVM.RequstHeader.RejectionReason.Trim().Length < 10)
            {
                TempData[SD.Error] = "Please provide a more detailed rejection reason (at least 10 characters).";
                return RedirectToAction(nameof(Details), new { id = requestVM.RequstHeader.RequestHeaderId });
            }

            requestHeaderFromDb.Status = SD.Rejected;
            requestHeaderFromDb.RejectionReason = requestVM.RequstHeader.RejectionReason.Trim();
            requestHeaderFromDb.RejectionDate = DateTime.Now;

            _db.tblRequestHeaders.Update(requestHeaderFromDb);
            _db.SaveChanges();

            TempData[SD.Success] = "Request rejected successfully. The customer can see the rejection reason when they relaunch.";
            return RedirectToAction(nameof(Details), new { id = requestHeaderFromDb.RequestHeaderId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupport)]
        public IActionResult ShipOrder(int RequestHeaderId, string Carrier, DateTime DeliveryDate)
        {
            var requestHeader = _db.tblRequestHeaders
                .FirstOrDefault(u => u.RequestHeaderId == RequestHeaderId);

            if (requestHeader == null)
            {
                TempData[SD.Error] = "Request not found.";
                return RedirectToAction(nameof(Index));
            }

            if (string.IsNullOrEmpty(Carrier))
            {
                TempData[SD.Error] = "Carrier is required.";
                return RedirectToAction(nameof(Details), new { id = RequestHeaderId });
            }

            if (DeliveryDate == default)
            {
                TempData[SD.Error] = "Shipping date is required.";
                return RedirectToAction(nameof(Details), new { id = RequestHeaderId });
            }

            // Calculate next payment date (30 days from delivery date)
            var nextPaymentDate = DeliveryDate.AddDays(30);

            requestHeader.Carrier = Carrier;
            requestHeader.DeliveryDate = DeliveryDate;
            requestHeader.PaymentDueDate = nextPaymentDate;
            requestHeader.Status = SD.Shipped;

            _db.tblRequestHeaders.Update(requestHeader);
            _db.SaveChanges();

            TempData[SD.Success] = "Order shipped successfully. Waiting for customer delivery confirmation.";
            return RedirectToAction(nameof(Details), new { id = RequestHeaderId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> CloseOrder(int id)
        {
            try
            {
                var requestHeader = await _db.tblRequestHeaders
                    .Include(r => r.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .FirstOrDefaultAsync(r => r.RequestHeaderId == id);

                if (requestHeader == null)
                {
                    TempData[SD.Error] = "Request not found.";
                    return RedirectToAction(nameof(Index));
                }

                // Verify the current user owns this request
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var currentUserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (requestHeader.Customer?.ApplicationUserId != currentUserId)
                {
                    TempData[SD.Error] = "You can only close your own orders.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                // Only allow closing if status is Shipped
                if (requestHeader.Status != SD.Shipped)
                {
                    TempData[SD.Error] = "Only shipped orders can be closed by confirming delivery.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                // Update status to Closed and set actual delivery date to now
                requestHeader.Status = SD.Closed;
                requestHeader.DeliveryDate = DateTime.Now; // Set actual delivery date

                _db.tblRequestHeaders.Update(requestHeader);
                await _db.SaveChangesAsync();

                TempData[SD.Success] = "Delivery confirmed successfully! Order has been closed.";
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error confirming delivery: {ex.Message}";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        [HttpGet]
        [Authorize(Roles = SD.CustomerRole)]
        public IActionResult RelaunchRequest(int id)
        {
            var originalRequest = _db.tblRequestHeaders
                .Include(r => r.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges)
                    .ThenInclude(d => d.Fridge)
                .FirstOrDefault(r => r.RequestHeaderId == id && r.Status == SD.Rejected);

            if (originalRequest == null)
            {
                TempData[SD.Error] = "Original request not found or not rejected.";
                return RedirectToAction(nameof(Index));
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (originalRequest.Customer?.ApplicationUserId != userId)
            {
                TempData[SD.Error] = "You can only relaunch your own requests.";
                return RedirectToAction(nameof(Index));
            }

            var relaunchVM = new RelaunchRequestVM
            {
                OriginalRequestId = originalRequest.RequestHeaderId,
                RejectionReason = originalRequest.RejectionReason ?? "No reason provided",
                CustomerName = $"{originalRequest.Customer.ApplicationUser.FirstName} {originalRequest.Customer.ApplicationUser.LastName}",
                OriginalRequestDate = originalRequest.RequestDate,
                RejectionDate = originalRequest.RejectionDate,
                OriginalFridges = originalRequest.RequestFridges != null ? originalRequest.RequestFridges.ToList() : new List<RequestDetails>()
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
                await ReloadRelaunchVMData(relaunchVM);
                return View(relaunchVM);
            }

            try
            {
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

                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (originalRequest.Customer?.ApplicationUserId != userId)
                {
                    TempData[SD.Error] = "You can only relaunch your own requests.";
                    return RedirectToAction(nameof(Index));
                }

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
                    OriginalRequestId = originalRequest.RequestHeaderId,
                    RequestTotal = originalRequest.RequestTotal
                };

                if (relaunchVM.AdditionalDocument != null && relaunchVM.AdditionalDocument.Length > 0)
                {
                    var uploadResult = await UploadAdditionalDocument(relaunchVM.AdditionalDocument);
                    if (uploadResult.Success)
                    {
                        newRequest.AdditionalDocumentPath = uploadResult.FilePath;
                    }
                    else
                    {
                        ModelState.AddModelError("AdditionalDocument", uploadResult.ErrorMessage);
                        await ReloadRelaunchVMData(relaunchVM);
                        return View(relaunchVM);
                    }
                }

                _db.tblRequestHeaders.Add(newRequest);
                await _db.SaveChangesAsync();

                if (originalRequest.RequestFridges != null && originalRequest.RequestFridges.Any())
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
                    await _db.SaveChangesAsync();
                }

                TempData[SD.Success] = "Request relaunched successfully with additional information. It will be reviewed again.";
                return RedirectToAction(nameof(Details), new { id = newRequest.RequestHeaderId });
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error relaunching request: {ex.Message}";
                await ReloadRelaunchVMData(relaunchVM);
                return View(relaunchVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.CustomerRole)]
        public IActionResult CancelRequest(CancelRequestVM cancelVM)
        {
            if (cancelVM?.RequestHeaderId == null)
            {
                TempData[SD.Error] = "Invalid request data.";
                return RedirectToAction(nameof(Index));
            }

            var requestHeaderFromDb = _db.tblRequestHeaders
                .Include(r => r.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                .FirstOrDefault(u => u.RequestHeaderId == cancelVM.RequestHeaderId);

            if (requestHeaderFromDb == null)
            {
                TempData[SD.Error] = "Request not found.";
                return RedirectToAction(nameof(Index));
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (requestHeaderFromDb.Customer?.ApplicationUserId != userId)
            {
                TempData[SD.Error] = "You can only cancel your own requests.";
                return RedirectToAction(nameof(Index));
            }

            if (requestHeaderFromDb.Status != SD.Pending)
            {
                TempData[SD.Error] = "Only pending requests can be cancelled.";
                return RedirectToAction(nameof(Details), new { id = cancelVM.RequestHeaderId });
            }

            // Validate cancellation reason
            if (string.IsNullOrEmpty(cancelVM.CancellationReason))
            {
                TempData[SD.Error] = "Cancellation reason is required.";
                return RedirectToAction(nameof(Details), new { id = cancelVM.RequestHeaderId });
            }

            // If "Other" is selected, require additional details
            if (cancelVM.CancellationReason == "Other" && string.IsNullOrEmpty(cancelVM.AdditionalDetails))
            {
                TempData[SD.Error] = "Please provide additional details for your cancellation reason.";
                return RedirectToAction(nameof(Details), new { id = cancelVM.RequestHeaderId });
            }

            requestHeaderFromDb.Status = SD.Cancelled;
            requestHeaderFromDb.RejectionReason = cancelVM.CancellationReason == "Other"
                ? $"Customer Cancellation - Other: {cancelVM.AdditionalDetails}"
                : $"Customer Cancellation - {cancelVM.CancellationReason}";
            requestHeaderFromDb.RejectionDate = DateTime.Now;

            _db.tblRequestHeaders.Update(requestHeaderFromDb);
            _db.SaveChanges();

            TempData[SD.Success] = "Your request has been cancelled successfully.";
            return RedirectToAction(nameof(Details), new { id = cancelVM.RequestHeaderId });
        }

        // Helper Methods
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
                relaunchVM.OriginalFridges = originalRequest.RequestFridges != null ? originalRequest.RequestFridges.ToList() : new List<RequestDetails>();
                relaunchVM.RejectionReason = originalRequest.RejectionReason ?? "No reason provided";
                relaunchVM.CustomerName = originalRequest.Customer?.ApplicationUser != null
                    ? $"{originalRequest.Customer.ApplicationUser.FirstName} {originalRequest.Customer.ApplicationUser.LastName}"
                    : "Customer information not available";
                relaunchVM.OriginalRequestDate = originalRequest.RequestDate;
                relaunchVM.RejectionDate = originalRequest.RejectionDate;
            }
        }

        private async Task<(bool Success, string FilePath, string ErrorMessage)> UploadAdditionalDocument(IFormFile file)
        {
            try
            {
                var allowedExtensions = new[] { ".pdf", ".jpg", ".jpeg", ".png", ".doc", ".docx" };
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                if (string.IsNullOrEmpty(extension) || !allowedExtensions.Contains(extension))
                {
                    return (false, "", "Only PDF, JPG, PNG, DOC, and DOCX files are allowed.");
                }

                if (file.Length > 5 * 1024 * 1024)
                {
                    return (false, "", "Maximum file size is 5MB.");
                }

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = $"{Guid.NewGuid()}{extension}";
                string requestPath = Path.Combine("uploads", "additional-documents");
                string finalPath = Path.Combine(wwwRootPath, requestPath);

                if (!Directory.Exists(finalPath))
                {
                    Directory.CreateDirectory(finalPath);
                }

                using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return (true, Path.Combine(requestPath, fileName).Replace("\\", "/"), "");
            }
            catch (Exception ex)
            {
                return (false, "", $"Error uploading file: {ex.Message}");
            }
        }

        private List<string> GetAvailableCarriers()
        {
            return new List<string>
            {
                "DHL",
                "Local Delivery",
                "Amazon Logistics"
            };
        }

        private List<string> GetCancellationReasons()
        {
            return new List<string>
            {
                "Changed my mind",
                "Financial reasons",
                "No longer needed",
                "Moving to a different location",
                "Delivery timeframe too long",
                "Other"
            };
        }
    }
}