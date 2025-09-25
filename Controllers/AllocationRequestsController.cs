using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
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

        public AllocationRequestsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: AllocationRequests
        public async Task<IActionResult> Index(string status, string searchString)
        {
            IQueryable<AllocationRequestHeader> query = _db.AllocationRequestHeaders
                .Include(r => r.Customer)
                .Include(r => r.RequestedFridges)
                .ThenInclude(rd => rd.Fridge)
                .Where(r => r.Status != "Deleted");

            // Apply filters
            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                query = query.Where(r => r.Status == status);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(r =>
                    r.Customer.TradingName.Contains(searchString) ||
                    r.FirstName.Contains(searchString) ||
                    r.LastName.Contains(searchString) ||
                    r.PhoneNumber.Contains(searchString));
            }

            // Role-based filtering
            if (User.IsInRole(SD.CustomerRole))
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer != null)
                {
                    query = query.Where(r => r.CustomerId == customer.Id);
                }
            }

            var requests = await query.OrderByDescending(r => r.RequestDate).ToListAsync();

            ViewBag.StatusList = await GetStatusListAsync();
            ViewBag.CurrentStatus = status;
            ViewBag.SearchString = searchString;

            return View(requests);
        }

        // GET: AllocationRequests/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var request = await _db.AllocationRequestHeaders
                    .Include(r => r.Customer)
                    .Include(r => r.RequestedFridges)
                        .ThenInclude(d => d.Fridge)
                    .FirstOrDefaultAsync(r => r.Id == id);

            if (request == null || request.Status == "Deleted")
            {
                return NotFound();
            }

            // Authorization check for customers
            if (User.IsInRole(SD.CustomerRole))
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer == null || request.CustomerId != customer.Id)
                {
                    return Forbid();
                }
            }

            return View(request);
        }

        // GET: AllocationRequests/Upsert
        public async Task<IActionResult> Upsert(int? id)
        {
            var vm = new AllocationRequestVM();

            await PopulateDropdowns(vm);

            if (id == null || id == 0)
            {
                // Create new request
                vm.RequestDate = DateTime.Now;

                // Pre-populate customer data if user is a customer
                if (User.IsInRole(SD.CustomerRole))
                {
                    var customer = await GetCurrentCustomerAsync();
                    if (customer != null)
                    {
                        vm.CustomerId = customer.Id;
                        vm.FirstName = customer.UserAccount?.FirstName ?? "";
                        vm.LastName = customer.UserAccount?.LastName ?? "";
                        vm.PhoneNumber = customer.BusinessPhoneNumber;
                        vm.AddressLine1 = customer.AddressLine1;
                        vm.AddressLine2 = customer.AddressLine2;
                        vm.City = customer.City;
                        vm.Province = customer.Province;
                        vm.PostalCode = customer.PostalCode;
                    }
                }

                return View(vm);
            }

            // Edit existing request
            var request = await _db.AllocationRequestHeaders
                .Include(r => r.RequestedFridges)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (request == null || request.Status == "Deleted")
            {
                return NotFound();
            }

            // Authorization check
            if (User.IsInRole(SD.CustomerRole))
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer == null || request.CustomerId != customer.Id)
                {
                    return Forbid();
                }
            }

            vm.Id = request.Id;
            vm.CustomerId = request.CustomerId;
            vm.RequestDate = request.RequestDate;
            vm.FirstName = request.FirstName;
            vm.LastName = request.LastName;
            vm.PhoneNumber = request.PhoneNumber;
            vm.AddressLine1 = request.AddressLine1;
            vm.AddressLine2 = request.AddressLine2;
            vm.City = request.City;
            vm.Province = request.Province;
            vm.PostalCode = request.PostalCode;
            vm.Carrier = request.Carrier;
            vm.Status = request.Status;
            vm.ShippingDate = request.ShippingDate;
            vm.PaymentDueDate = request.PaymentDueDate;

            // Load request details
            vm.RequestDetails = await _db.AllocationRequestDetails
                .Where(rd => rd.RequestHeaderId == id)
                .Select(rd => new AllocationRequestDetailVM
                {
                    Id = rd.Id,
                    FridgeId = rd.FridgeId,
                    Quantity = rd.Quantity,
                    Price = rd.Price,
                    FridgeModel = rd.Fridge.Model
                })
                .ToListAsync();

            return View(vm);
        }

        // POST: AllocationRequests/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(AllocationRequestVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.Id == 0)
                    {
                        // Create new request
                        var request = new AllocationRequestHeader
                        {
                            CustomerId = vm.CustomerId,
                            RequestDate = vm.RequestDate,
                            FirstName = vm.FirstName,
                            LastName = vm.LastName,
                            PhoneNumber = vm.PhoneNumber,
                            AddressLine1 = vm.AddressLine1,
                            AddressLine2 = vm.AddressLine2,
                            City = vm.City,
                            Province = vm.Province,
                            PostalCode = vm.PostalCode,
                            Carrier = vm.Carrier,
                            Status = "Pending",
                            RequestTotal = vm.RequestDetails?.Sum(d => d.Quantity * d.Price) ?? 0
                        };

                        _db.AllocationRequestHeaders.Add(request);
                        await _db.SaveChangesAsync();

                        // Add request details
                        if (vm.RequestDetails != null)
                        {
                            foreach (var detail in vm.RequestDetails)
                            {
                                var requestDetail = new AllocationRequestDetail
                                {
                                    RequestHeaderId = request.Id,
                                    FridgeId = detail.FridgeId,
                                    Quantity = detail.Quantity,
                                    Price = detail.Price
                                };
                                _db.AllocationRequestDetails.Add(requestDetail);
                            }
                            await _db.SaveChangesAsync();
                        }

                        TempData["success"] = "Allocation request created successfully";
                    }
                    else
                    {
                        // Update existing request
                        var request = await _db.AllocationRequestHeaders
                            .Include(r => r.RequestedFridges)
                            .FirstOrDefaultAsync(r => r.Id == vm.Id);

                        if (request == null)
                        {
                            return NotFound();
                        }

                        // Authorization check for customers
                        if (User.IsInRole(SD.CustomerRole)  && request.Status != "Pending")
                        {
                            TempData["error"] = "Cannot edit request after it has been processed";
                            return RedirectToAction(nameof(Details), new { id = vm.Id });
                        }

                        request.FirstName = vm.FirstName;
                        request.LastName = vm.LastName;
                        request.PhoneNumber = vm.PhoneNumber;
                        request.AddressLine1 = vm.AddressLine1;
                        request.AddressLine2 = vm.AddressLine2;
                        request.City = vm.City;
                        request.Province = vm.Province;
                        request.PostalCode = vm.PostalCode;
                        request.Carrier = vm.Carrier;
                        request.RequestTotal = vm.RequestDetails?.Sum(d => d.Quantity * d.Price) ?? 0;

                        // Update details
                        if (vm.RequestDetails != null)
                        {
                            // Remove existing details
                            var existingDetails = _db.AllocationRequestDetails
                                .Where(rd => rd.RequestHeaderId == request.Id);
                            _db.AllocationRequestDetails.RemoveRange(existingDetails);

                            // Add new details
                            foreach (var detail in vm.RequestDetails)
                            {
                                var requestDetail = new AllocationRequestDetail
                                {
                                    RequestHeaderId = request.Id,
                                    FridgeId = detail.FridgeId,
                                    Quantity = detail.Quantity,
                                    Price = detail.Price
                                };
                                _db.AllocationRequestDetails.Add(requestDetail);
                            }
                        }

                        await _db.SaveChangesAsync();
                        TempData["success"] = "Allocation request updated successfully";
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error saving allocation request: {ex.Message}");
                }
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }

        // POST: AllocationRequests/Process/5
        [HttpPost]
        [Authorize(Roles =SD.AdminRole + "," + SD.CustomerSupportRole)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Process(int id)
        {
            var request = await _db.AllocationRequestHeaders.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            request.Status = "In Progress";
            await _db.SaveChangesAsync();

            TempData["success"] = "Allocation request is now being processed";
            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: AllocationRequests/Allocate/5
        [HttpPost]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole + "," + SD.StockControllerRole)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Allocate(int id)
        {
            var request = await _db.AllocationRequestHeaders
                .Include(r => r.RequestedFridges).ThenInclude(rd => rd.Fridge)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            try
            {
                // Create fridge allocations for each request detail
                foreach (var detail in request.RequestedFridges)
                {
                    for (int i = 0; i < detail.Quantity; i++)
                    {
                        var allocation = new FridgeAllocation
                        {
                            FridgeId = detail.FridgeId,
                            CustomerId = request.CustomerId,
                            AllocationDate = DateTime.Now,
                            AllocationLocationId = request.Customer.LocationId, // Remove IsActive if it's read-only
                            CreatedAt = DateTime.Now
                            // Remove: IsActive = true - let the model handle this
                        };
                        _db.FridgeAllocations.Add(allocation);

                        // Update fridge status to allocated
                        var fridge = await _db.Fridges.FindAsync(detail.FridgeId);
                        if (fridge != null)
                        {
                            fridge.Status = FridgeStatus.Allocated;
                            fridge.ModifiedDate = DateTime.Now;
                        }
                    }
                }

                request.Status = "Allocated";
                request.ShippingDate = DateTime.Now;
                await _db.SaveChangesAsync();

                TempData["success"] = "Fridges allocated successfully";
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Error allocating fridges: {ex.Message}";
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: AllocationRequests/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _db.AllocationRequestHeaders.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            // Authorization check for customers
            if (User.IsInRole(SD.CustomerRole))
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer == null || request.CustomerId != customer.Id || request.Status != "Pending")
                {
                    TempData["error"] = "You can only delete pending requests";
                    return RedirectToAction(nameof(Index));
                }
            }

            // Soft delete
            request.Status = "Deleted";
            await _db.SaveChangesAsync();

            TempData["success"] = "Allocation request deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        // AJAX: Add request detail row
        [HttpPost]
        public async Task<JsonResult> AddRequestDetail([FromBody] AllocationRequestDetailVM detail)
        {
            var fridge = await _db.Fridges
                .Include(f => f.Model)
                .FirstOrDefaultAsync(f => f.Id == detail.FridgeId);

            if (fridge == null)
            {
                return Json(new { success = false, message = "Fridge not found" });
            }

            var newDetail = new AllocationRequestDetailVM
            {
                TempId = Guid.NewGuid(),
                FridgeId = detail.FridgeId,
                FridgeModel = fridge.Model ?? "Unknown",
                Quantity = detail.Quantity,
                Price = detail.Price
            };

            return Json(new { success = true, detail = newDetail });
        }

        private async Task PopulateDropdowns(AllocationRequestVM vm)
        {
            vm.CustomerList = await _db.Customers
                .Where(c => c.IsActive)
                .OrderBy(c => c.TradingName)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.TradingName
                })
                .ToListAsync();

            vm.FridgeList = await _db.Fridges
                .Where(f => f.Status == FridgeStatus.Available)
                .Include(f => f.Model)
                .OrderBy(f => f.Model)
                .ThenBy(f => f.SerialNumber)
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = $"{f.Model} - {f.SerialNumber}"
                })
                .ToListAsync();

            vm.StatusList = await GetStatusListAsync();
        }

        private async Task<List<SelectListItem>> GetStatusListAsync()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = AllocationStatus.Pending.ToString(), Text = "Pending" },
            new SelectListItem { Value = AllocationStatus.Active.ToString(), Text = "Active" },
            new SelectListItem { Value = AllocationStatus.Suspended.ToString(), Text = "Suspended" },
            new SelectListItem { Value = AllocationStatus.Completed.ToString(), Text = "Completed" },
            new SelectListItem { Value = AllocationStatus.Cancelled.ToString(), Text = "Cancelled" },
            new SelectListItem { Value = AllocationStatus.Terminated.ToString(), Text = "Terminated" },
            new SelectListItem { Value = AllocationStatus.Expired.ToString(), Text = "Expired" }
        };
        }

        private async Task<Customer?> GetCurrentCustomerAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _db.Customers
                .Include(c => c.UserAccount)
                .FirstOrDefaultAsync(c => c.UserId == userId && c.IsActive);
        }
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

