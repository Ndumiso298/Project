using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Helpers;
using Project.Models;
using Project.Models.ViewModels;
using Project.Utilities;
using Project.Utilities.Enums;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole + "," + SD.CustomerRole)]
    public class AllocationRequestsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<AllocationRequestsController> _logger;

        public AllocationRequestsController(ApplicationDbContext db, ILogger<AllocationRequestsController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET: AllocationRequests
        public async Task<IActionResult> Index(AllocationRequestStatus? status, string searchString, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _db.AllocationRequestHeaders
                    .Include(r => r.Customer)
                    .Include(r => r.DeliveryLocation)
                    .Include(r => r.RequestDetails)
                        .ThenInclude(rd => rd.FridgeModel)
                    .Where(r => r.Status != AllocationRequestStatus.Cancelled);

                // Apply filters
                if (status.HasValue)
                {
                    query = query.Where(r => r.Status == status.Value);
                }

                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    query = query.Where(r =>
                        r.Customer.TradingName.ToLower().Contains(searchString) ||
                        r.ContactPerson.ToLower().Contains(searchString) ||
                        r.ContactPhoneNumber.Contains(searchString) ||
                        r.Id.ToString().Contains(searchString));
                }

                // Role-based filtering
                if (User.IsInRole(SD.CustomerRole))
                {
                    var customer = await GetCurrentCustomerAsync();
                    if (customer != null)
                    {
                        query = query.Where(r => r.CustomerId == customer.Id);
                    }
                    else
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }

                // Pagination
                var totalItems = await query.CountAsync();
                var requests = await query
                    .OrderByDescending(r => r.RequestDate)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(r => new AllocationRequestSummaryVM
                    {
                        Id = r.Id,
                        RequestDate = r.RequestDate,
                        Status = r.Status,
                        CustomerName = r.Customer.TradingName,
                        ContactPerson = r.ContactPerson,
                        BusinessType = r.Customer.BusinessType,
                        TotalItems = r.TotalQuantity,
                        TotalMonthlyRental = r.TotalMonthlyRental,
                        TotalValue = r.TotalContractValue,
                        Priority = r.Priority,
                        RequestType = r.RequestType
                    })
                    .ToListAsync();

                ViewBag.StatusList = await GetStatusSelectListAsync();
                ViewBag.CurrentStatus = status;
                ViewBag.SearchString = searchString;
                ViewBag.CurrentPage = page;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalItems = totalItems;
                ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

                return View(requests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading allocation requests index");
                TempData["error"] = "An error occurred while loading allocation requests.";
                return View(new List<AllocationRequestSummaryVM>());
            }
        }

        // GET: AllocationRequests/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var request = await _db.AllocationRequestHeaders
                    .Include(r => r.Customer)
                    .Include(r => r.DeliveryLocation)
                    .Include(r => r.RequestDetails)
                        .ThenInclude(rd => rd.FridgeModel)
                    .Include(r => r.Allocations)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (request == null)
                {
                    TempData["error"] = "Allocation request not found.";
                    return RedirectToAction(nameof(Index));
                }

                // Authorization check for customers
                if (User.IsInRole(SD.CustomerRole))
                {
                    var customer = await GetCurrentCustomerAsync();
                    if (customer == null || request.CustomerId != customer.Id)
                    {
                        TempData["error"] = "Access denied to this allocation request.";
                        return RedirectToAction(nameof(Index));
                    }
                }

                var vm = AllocationRequestHeaderVM.FromEntity(request);
                await PopulateRequestDetailsStock(vm);
                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading allocation request details for ID: {RequestId}", id);
                TempData["error"] = "An error occurred while loading request details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: AllocationRequests/Upsert
        public async Task<IActionResult> Upsert(int? id)
        {
            try
            {
                AllocationRequestHeaderVM vm;

                if (id == null || id == 0)
                {
                    // Create new request
                    vm = new AllocationRequestHeaderVM
                    {
                        RequestDate = DateTime.Now,
                        Status = AllocationRequestStatus.Draft,
                        RequestType = CustomerRequestType.NewAllocation,
                        Priority = CustomerRequestPriority.Medium
                    };

                    // Pre-populate customer data if user is a customer
                    if (User.IsInRole(SD.CustomerRole))
                    {
                        var customer = await GetCurrentCustomerAsync();
                        if (customer != null)
                        {
                            await PopulateCustomerDataAsync(vm, customer);
                        }
                    }
                }
                else
                {
                    // Edit existing request
                    var request = await _db.AllocationRequestHeaders
                        .Include(r => r.Customer)
                        .Include(r => r.RequestDetails)
                            .ThenInclude(rd => rd.FridgeModel)
                        .FirstOrDefaultAsync(r => r.Id == id);

                    if (request == null)
                    {
                        TempData["error"] = "Allocation request not found.";
                        return RedirectToAction(nameof(Index));
                    }

                    // Authorization and business rule checks
                    if (!request.CanBeEdited)
                    {
                        TempData["error"] = "This request can no longer be edited.";
                        return RedirectToAction(nameof(Details), new { id });
                    }

                    if (User.IsInRole(SD.CustomerRole))
                    {
                        var customer = await GetCurrentCustomerAsync();
                        if (customer == null || request.CustomerId != customer.Id)
                        {
                            TempData["error"] = "Access denied to edit this request.";
                            return RedirectToAction(nameof(Index));
                        }
                    }

                    vm = AllocationRequestHeaderVM.FromEntity(request);
                    await PopulateRequestDetailsStock(vm);
                }

                await PopulateDropdownsAsync(vm);
                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading allocation request upsert page for ID: {RequestId}", id);
                TempData["error"] = "An error occurred while loading the request form.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: AllocationRequests/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(AllocationRequestHeaderVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropdownsAsync(vm);
                    TempData["error"] = "Please correct the validation errors.";
                    return View(vm);
                }

                // Validate business rules
                var validationErrors = vm.GetValidationErrors().ToList();
                if (validationErrors.Any())
                {
                    foreach (var error in validationErrors)
                    {
                        ModelState.AddModelError("", error);
                    }
                    await PopulateDropdownsAsync(vm);
                    return View(vm);
                }

                if (vm.Id == 0)
                {
                    // Create new request
                    var requestId = await CreateAllocationRequestAsync(vm);
                    TempData["success"] = "Allocation request created successfully.";
                    return RedirectToAction(nameof(Details), new { id = requestId });
                }
                else
                {
                    // Update existing request
                    await UpdateAllocationRequestAsync(vm);
                    TempData["success"] = "Allocation request updated successfully.";
                    return RedirectToAction(nameof(Details), new { id = vm.Id });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving allocation request {RequestId}", vm.Id);
                ModelState.AddModelError("", $"An error occurred while saving the request: {ex.Message}");
                await PopulateDropdownsAsync(vm);
                return View(vm);
            }
        }

        // POST: AllocationRequests/Submit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(int id)
        {
            try
            {
                var request = await _db.AllocationRequestHeaders
                    .Include(r => r.RequestDetails)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (request == null)
                {
                    TempData["error"] = "Allocation request not found.";
                    return RedirectToAction(nameof(Index));
                }

                // Authorization check
                if (User.IsInRole(SD.CustomerRole))
                {
                    var customer = await GetCurrentCustomerAsync();
                    if (customer == null || request.CustomerId != customer.Id)
                    {
                        TempData["error"] = "Access denied to submit this request.";
                        return RedirectToAction(nameof(Index));
                    }
                }

                if (request.Status != AllocationRequestStatus.Draft)
                {
                    TempData["error"] = "Only draft requests can be submitted.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                // Validate stock availability
                var stockIssues = new List<string>();
                foreach (var detail in request.RequestDetails)
                {
                    var availableStock = await _db.Fridges
                        .CountAsync(f => f.FridgeModelId == detail.FridgeModelId &&
                                       f.Status == FridgeStatus.Available &&
                                       f.IsActive);

                    if (detail.Quantity > availableStock)
                    {
                        stockIssues.Add($"{detail.FridgeModel.DisplayName}: Requested {detail.Quantity}, available {availableStock}");
                    }
                }

                if (stockIssues.Any())
                {
                    TempData["error"] = $"Stock issues prevent submission: {string.Join("; ", stockIssues)}";
                    return RedirectToAction(nameof(Details), new { id });
                }

                // Update status and submit
                request.UpdateStatus(AllocationRequestStatus.Submitted, User.Identity.Name, "Request submitted by customer");
                await _db.SaveChangesAsync();

                _logger.LogInformation("Allocation request {RequestId} submitted by {User}", id, User.Identity?.Name);
                TempData["success"] = "Allocation request submitted successfully. It will be processed shortly.";

                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting allocation request {RequestId}", id);
                TempData["error"] = "An error occurred while submitting the request.";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        // POST: AllocationRequests/Approve/5
        [HttpPost]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id, string approvalNotes)
        {
            try
            {
                var request = await _db.AllocationRequestHeaders
                    .Include(r => r.RequestDetails)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (request == null)
                {
                    TempData["error"] = "Allocation request not found.";
                    return RedirectToAction(nameof(Index));
                }

                if (!request.CanTransitionTo(AllocationRequestStatus.Approved))
                {
                    TempData["error"] = "Request cannot be approved in its current status.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                request.UpdateStatus(AllocationRequestStatus.Approved, User.Identity?.Name, approvalNotes);
                await _db.SaveChangesAsync();

                // Create allocations for approved request
                await CreateAllocationsFromRequest(request);

                _logger.LogInformation("Allocation request {RequestId} approved by {User}", id, User.Identity?.Name);
                TempData["success"] = "Allocation request approved and fridges allocated successfully.";

                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error approving allocation request {RequestId}", id);
                TempData["error"] = "An error occurred while approving the request.";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        // POST: AllocationRequests/Reject/5
        [HttpPost]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id, string rejectionReason)
        {
            try
            {
                var request = await _db.AllocationRequestHeaders
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (request == null)
                {
                    TempData["error"] = "Allocation request not found.";
                    return RedirectToAction(nameof(Index));
                }

                if (string.IsNullOrWhiteSpace(rejectionReason))
                {
                    TempData["error"] = "Rejection reason is required.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                if (!request.CanTransitionTo(AllocationRequestStatus.Rejected))
                {
                    TempData["error"] = "Request cannot be rejected in its current status.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                request.UpdateStatus(AllocationRequestStatus.Rejected, User.Identity?.Name, $"Rejected: {rejectionReason}");
                await _db.SaveChangesAsync();

                _logger.LogInformation("Allocation request {RequestId} rejected by {User}", id, User.Identity?.Name);
                TempData["success"] = "Allocation request rejected.";

                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error rejecting allocation request {RequestId}", id);
                TempData["error"] = "An error occurred while rejecting the request.";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        // POST: AllocationRequests/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id, string cancellationReason)
        {
            try
            {
                var request = await _db.AllocationRequestHeaders
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (request == null)
                {
                    TempData["error"] = "Allocation request not found.";
                    return RedirectToAction(nameof(Index));
                }

                // Authorization check for customers
                if (User.IsInRole(SD.CustomerRole))
                {
                    var customer = await GetCurrentCustomerAsync();
                    if (customer == null || request.CustomerId != customer.Id)
                    {
                        TempData["error"] = "Access denied to cancel this request.";
                        return RedirectToAction(nameof(Index));
                    }

                    // Customers can only cancel draft or submitted requests
                    if (request.Status != AllocationRequestStatus.Draft &&
                        request.Status != AllocationRequestStatus.Submitted)
                    {
                        TempData["error"] = "You can only cancel draft or submitted requests.";
                        return RedirectToAction(nameof(Details), new { id });
                    }
                }

                if (!request.CanTransitionTo(AllocationRequestStatus.Cancelled))
                {
                    TempData["error"] = "Request cannot be cancelled in its current status.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                request.UpdateStatus(AllocationRequestStatus.Cancelled, User.Identity?.Name, $"Cancelled: {cancellationReason}");
                await _db.SaveChangesAsync();

                _logger.LogInformation("Allocation request {RequestId} cancelled by {User}", id, User.Identity?.Name);
                TempData["success"] = "Allocation request cancelled successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling allocation request {RequestId}", id);
                TempData["error"] = "An error occurred while cancelling the request.";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        // AJAX: Get available stock for fridge model
        [HttpGet]
        public async Task<JsonResult> GetAvailableStock(int fridgeModelId)
        {
            try
            {
                var availableStock = await _db.Fridges
                    .CountAsync(f => f.FridgeModelId == fridgeModelId &&
                                   f.Status == FridgeStatus.Available &&
                                   f.IsActive);

                return Json(new { availableStock });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting available stock for fridge model {ModelId}", fridgeModelId);
                return Json(new { availableStock = 0 });
            }
        }

        // AJAX: Add item to request details
        [HttpPost]
        public async Task<JsonResult> AddRequestDetail([FromBody] AllocationRequestDetailVM detailVm)
        {
            try
            {
                if (detailVm.FridgeModelId <= 0 || detailVm.Quantity <= 0)
                {
                    return Json(new { success = false, message = "Invalid fridge model or quantity" });
                }

                // Get fridge model details
                var fridgeModel = await _db.FridgeModels
                    .FirstOrDefaultAsync(fm => fm.Id == detailVm.FridgeModelId);

                if (fridgeModel == null)
                {
                    return Json(new { success = false, message = "Fridge model not found" });
                }

                // Get available stock
                var availableStock = await _db.Fridges
                    .CountAsync(f => f.FridgeModelId == detailVm.FridgeModelId &&
                                   f.Status == FridgeStatus.Available &&
                                   f.IsActive);

                detailVm.AvailableStock = availableStock;
                detailVm.FridgeModel = new FridgeModelVM
                {
                    Id = fridgeModel.Id,
                    Manufacturer = fridgeModel.Manufacturer,
                    ModelName = fridgeModel.ModelName,
                    ModelCode = fridgeModel.ModelCode,
                    MonthlyRentalPrice = fridgeModel.MonthlyRentalPrice,
                    CapacityLiters = fridgeModel.CapacityLiters
                };

                return Json(new { success = true, detail = detailVm });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding request detail for model {ModelId}", detailVm.FridgeModelId);
                return Json(new { success = false, message = "Error adding item to request" });
            }
        }

        #region Private Methods

        private async Task PopulateRequestDetailsStock(AllocationRequestHeaderVM vm)
        {
            foreach (var detail in vm.RequestDetails)
            {
                detail.AvailableStock = await _db.Fridges
                    .CountAsync(f => f.FridgeModelId == detail.FridgeModelId &&
                                   f.Status == FridgeStatus.Available &&
                                   f.IsActive);
            }
        }

        private async Task PopulateDropdownsAsync(AllocationRequestHeaderVM vm)
        {
            vm.CustomerList = await _db.Customers
                .Where(c => c.IsActive)
                .OrderBy(c => c.TradingName)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.TradingName} ({c.BusinessType})"
                })
                .ToListAsync();

            vm.LocationList = await _db.Locations
                .Where(l => l.IsActive)
                .OrderBy(l => l.City)
                .ThenBy(l => l.Suburb)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.ToString()
                })
                .ToListAsync();

            vm.RequestTypeList = Enum.GetValues<CustomerRequestType>()
                .Select(rt => new SelectListItem
                {
                    Value = rt.ToString(),
                    Text = rt.ToString()
                })
                .ToList();

            vm.PriorityList = Enum.GetValues<CustomerRequestPriority>()
                .Select(p => new SelectListItem
                {
                    Value = p.ToString(),
                    Text = p.ToString()
                })
                .ToList();

            vm.StatusList = await GetStatusSelectListAsync();
        }

        private async Task PopulateCustomerDataAsync(AllocationRequestHeaderVM vm, Customer customer)
        {
            vm.CustomerId = customer.Id;
            vm.ContactPerson = customer.FullName;
            vm.PhoneNumber = customer.BusinessPhoneNumber;
            vm.Email = customer.BusinessEmail;
            vm.DeliveryLocationId = customer.LocationId;
            vm.CustomerName = customer.TradingName;
            vm.CustomerBusinessType = customer.BusinessType;
        }

        private async Task<int> CreateAllocationRequestAsync(AllocationRequestHeaderVM vm)
        {
            var request = vm.ToEntity();
            request.CreatedAt = DateTime.UtcNow;
            request.CreatedBy = User.Identity?.Name;

            _db.AllocationRequestHeaders.Add(request);
            await _db.SaveChangesAsync();

            // Add request details
            foreach (var detailVm in vm.RequestDetails)
            {
                var detail = detailVm.ToEntity();
                detail.AllocationRequestHeaderId = request.Id;
                _db.AllocationRequestDetails.Add(detail);
            }

            await _db.SaveChangesAsync();
            return request.Id;
        }

        private async Task UpdateAllocationRequestAsync(AllocationRequestHeaderVM vm)
        {
            var request = await _db.AllocationRequestHeaders
                .Include(r => r.RequestDetails)
                .FirstOrDefaultAsync(r => r.Id == vm.Id);

            if (request == null) throw new Exception("Allocation request not found");

            // Update header properties
            request.RequestDate = vm.RequestDate;
            request.RequestType = vm.RequestType;
            request.Priority = vm.Priority;
            request.ContactPerson = vm.ContactPerson;
            request.ContactPhoneNumber = vm.PhoneNumber;
            request.ContactEmail = vm.Email;
            request.DeliveryLocationId = vm.DeliveryLocationId;
            request.DeliveryInstructions = vm.DeliveryInstructions;
            request.PreferredDeliveryDate = vm.PreferredDeliveryDate;
            request.DiscountPercentage = vm.DiscountPercentage;
            request.UpdatedAt = DateTime.UtcNow;
            request.UpdatedBy = User.Identity?.Name;

            // Update details (remove all and add new)
            _db.AllocationRequestDetails.RemoveRange(request.RequestDetails);

            foreach (var detailVm in vm.RequestDetails)
            {
                var detail = detailVm.ToEntity();
                detail.AllocationRequestHeaderId = request.Id;
                _db.AllocationRequestDetails.Add(detail);
            }

            await _db.SaveChangesAsync();
        }

        private async Task CreateAllocationsFromRequest(AllocationRequestHeader request)
        {
            var currentEmployeeId = await GetCurrentEmployeeIdAsync();

            foreach (var detail in request.RequestDetails)
            {
                // Find available fridges for this model
                var availableFridges = await _db.Fridges
                    .Where(f => f.FridgeModelId == detail.FridgeModelId &&
                              f.Status == FridgeStatus.Available &&
                              f.IsActive)
                    .Take(detail.Quantity)
                    .ToListAsync();

                foreach (var fridge in availableFridges)
                {
                    var allocation = new FridgeAllocation
                    {
                        FridgeId = fridge.Id,
                        CustomerId = request.CustomerId,
                        DeliveryLocationId = request.DeliveryLocationId,
                        AllocationRequestHeaderId = request.Id,
                        AllocatedByEmployeeId = currentEmployeeId,
                        Status = AllocationStatus.Active,
                        Quantity = 1,
                        AllocationDate = DateTime.UtcNow,
                        MonthlyRentalPrice = detail.FridgeModel.MonthlyRentalPrice,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = User.Identity?.Name
                    };

                    _db.FridgeAllocations.Add(allocation);

                    // Update fridge status
                    fridge.Status = FridgeStatus.Allocated;
                    fridge.ModifiedAt = DateTime.UtcNow;
                }
            }

            await _db.SaveChangesAsync();
        }

        private async Task<List<SelectListItem>> GetStatusSelectListAsync()
        {
            var items = Enum.GetValues<AllocationRequestStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString()
                })
                .ToList();

            // Filter based on user role
            if (User.IsInRole(SD.CustomerRole))
            {
                items = items.Where(s => s.Value == AllocationRequestStatus.Draft.ToString() ||
                                       s.Value == AllocationRequestStatus.Submitted.ToString() ||
                                       s.Value == AllocationRequestStatus.Cancelled.ToString())
                             .ToList();
            }

            return items;
        }

        private async Task<Customer?> GetCurrentCustomerAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _db.Customers
                .FirstOrDefaultAsync(c => c.UserId == userId && c.IsActive);
        }

        private async Task<int> GetCurrentEmployeeIdAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _db.Employees
                .FirstOrDefaultAsync(e => e.UserId == userId && e.IsActive);
            return employee?.Id ?? 1; // Default to admin if not found
        }

        #endregion
    }

    //public class AllocationRequestsController : Controller
    //{
    //    private readonly ApplicationDbContext _db;
    //    [BindProperty]
    //    public FridgeAllocationVM RequestVM { get; set; }
    //    public AllocationRequestsController(ApplicationDbContext db)
    //    {
    //        _db = db;
    //    }


    //    public IActionResult Index(string status)
    //    {

    //        IEnumerable<AllocationRequestHeader> objRequestHeaders;


    //        if (User.IsInRole(SD.AdminRole) || User.IsInRole(SD.CustomerSupportRole))
    //        {
    //            objRequestHeaders = _db.AllocationRequestHeaders.Include(a=>a.Customer).ToList();
    //        }
    //        else
    //        {

    //            var claimsIdentity = (ClaimsIdentity)User.Identity;
    //            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

    //            objRequestHeaders = _db.AllocationRequestHeaders
    //                .Include(u => u.Customer)
    //                .Where(r => r.Customer.UserAccount.Id == userId)
    //                .ToList();

    //        }

    //        return View(objRequestHeaders);
    //    }

    //    public IActionResult Details(int id)
    //    {
    //        RequestVM = new()
    //        {
    //            RequestHeader = _db.AllocationRequestHeaders
    //                           .Include(a => a.Customer)
    //                           .FirstOrDefault(o => o.Id == id),

    //            AllocationRequestDetails = _db.AllocationRequestDetails
    //                           .Include(d => d.Fridge)
    //                           .Where(d => d.RequestHeaderId == id)
    //                           .ToList()
    //        };

    //        return View(RequestVM);
    //    }

    //    [HttpPost]
    //    [HttpPost]
    //    public IActionResult UpdateRequestDetail(FridgeAllocationVM RequestVM)
    //    {
    //        if (RequestVM == null || RequestVM.RequestHeader == null)
    //        {
    //            return BadRequest("Invalid request data.");
    //        }

    //        var RequestHeaderFromDb = _db.AllocationRequestHeaders
    //            .FirstOrDefault(u => u.Id == RequestVM.RequestHeader.Id);

    //        if (RequestHeaderFromDb == null)
    //        {
    //            return NotFound("Request not found.");
    //        }

    //        // Update properties safely
    //        RequestHeaderFromDb.FirstName = RequestVM.RequestHeader.FirstName;
    //        RequestHeaderFromDb.LastName = RequestVM.RequestHeader.LastName;
    //        RequestHeaderFromDb.PhoneNumber = RequestVM.RequestHeader.PhoneNumber;
    //        RequestHeaderFromDb.AddressLine1 = RequestVM.RequestHeader.AddressLine1;
    //        RequestHeaderFromDb.AddressLine2 = RequestVM.RequestHeader.AddressLine2;
    //        RequestHeaderFromDb.City = RequestVM.RequestHeader.City;
    //        RequestHeaderFromDb.Province = RequestVM.RequestHeader.Province;
    //        RequestHeaderFromDb.PostalCode = RequestVM.RequestHeader.PostalCode;
    //        RequestHeaderFromDb.Status = "Allocated";

    //        if (!string.IsNullOrEmpty(RequestVM.RequestHeader.Carrier))
    //        {
    //            RequestHeaderFromDb.Carrier = RequestVM.RequestHeader.Carrier;
    //        }

    //        if (RequestVM.RequestFridgeNo?.Fridge != null &&
    //            !string.IsNullOrEmpty(RequestVM.RequestFridgeNo.Fridge.SerialNumber))
    //        {
    //            RequestHeaderFromDb.Carrier = RequestVM.RequestFridgeNo.Fridge.SerialNumber;
    //        }

    //        _db.AllocationRequestHeaders.Update(RequestHeaderFromDb);
    //        _db.SaveChanges();

    //        TempData["Success"] = "Order Details Updated Successfully.";

    //        return RedirectToAction(nameof(Details), new { id = RequestHeaderFromDb.Id });
    //    }

    //    [HttpPost]

    //    public IActionResult StartProcessing()
    //    {
    //        var requestHeader = _db.AllocationRequestHeaders
    //        .FirstOrDefault(r => r.Id == RequestVM.RequestHeader.Id);



    //        TempData["Success"] = "Request Details Updated Successfully.";
    //        return RedirectToAction(nameof(Details), new { orderId = RequestVM.RequestHeader.Id });

    //    }

    //    [HttpPost]
    //    public IActionResult ShipOrder()
    //    {

    //        var RequestHeader = _db.AllocationRequestHeaders.FirstOrDefault(u => u.Id == RequestVM.RequestHeader.Id);
    //        //AllocationRequestHeader.TrackingNumber = OrderVM.OrderHeader.TrackingNumber;
    //        RequestHeader.Carrier = RequestVM.RequestHeader.Carrier;
    //        RequestHeader.ShippingDate = DateTime.Now;
    //        if (RequestHeader.Status == SD.PaymentStatusDelayedPayment)
    //        {
    //            RequestHeader.PaymentDueDate = DateTime.Now.AddDays(30);
    //        }

    //        _db.AllocationRequestHeaders.Update(RequestHeader);
    //        _db.SaveChanges();
    //        TempData["Success"] = "Order Shipped Successfully.";
    //        return RedirectToAction(nameof(Details), new { requesId = RequestVM.RequestHeader.Id });
    //    }
    //}
}

