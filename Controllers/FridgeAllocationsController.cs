using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;
using Project.Utilities;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole + "," + SD.CustomerRole)]
    public class FridgeAllocationsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public FridgeAllocationsController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // GET: FridgeAllocations
        public async Task<IActionResult> Index()
        {
            IQueryable<FridgeAllocation> query = _db.FridgeAllocations
                .Include(a => a.Fridge)
                    .ThenInclude(f => f.FridgeModel)
                .Include(a => a.Customer)
                .Include(a => a.DeliveryLocation)
                .Include(a => a.AllocatedBy)
                    .ThenInclude(e => e.UserAccount)
                .Include(a => a.ProcessedBy)
                    .ThenInclude(e => e.UserAccount)
                .Where(a => a.IsActive);

            // Role-based filtering
            if (User.IsInRole(SD.CustomerRole))
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer != null)
                {
                    query = query.Where(a => a.CustomerId == customer.Id);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }

            var allocations = await query.OrderByDescending(a => a.AllocationDate).ToListAsync();

            // Convert to ViewModel for consistent display
            var vmList = allocations.Select(a => FridgeAllocationVM.FromEntity(a)).ToList();
            return View(vmList);
        }

        // GET: FridgeAllocations/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var allocation = await _db.FridgeAllocations
                .Include(a => a.Fridge)
                    .ThenInclude(f => f.FridgeModel)
                .Include(a => a.Customer)
                .Include(a => a.DeliveryLocation)
                .Include(a => a.AllocatedBy)
                    .ThenInclude(e => e.UserAccount)
                .Include(a => a.ProcessedBy)
                    .ThenInclude(e => e.UserAccount)
                .Include(a => a.MaintenanceVisits)
                .Include(a => a.FaultReports)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (allocation == null || !allocation.IsActive)
            {
                return NotFound();
            }

            // Authorization check for customers
            if (User.IsInRole(SD.CustomerRole))
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer == null || allocation.CustomerId != customer.Id)
                {
                    return Forbid();
                }
            }

            var vm = FridgeAllocationVM.FromEntity(allocation);
            return View(vm);
        }

        // GET: FridgeAllocations/Upsert
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> Upsert(int? id)
        {
            FridgeAllocationVM vm = new FridgeAllocationVM();

            if (id == null || id == 0)
            {
                // Create new allocation
                vm.AllocationDate = DateTime.Now;
                vm.Status = AllocationStatus.Pending;
            }
            else
            {
                // Edit existing allocation
                var allocation = await _db.FridgeAllocations
                    .Include(a => a.Fridge)
                    .Include(a => a.Customer)
                    .Include(a => a.DeliveryLocation)
                    .Include(a => a.AllocatedBy)
                    .Include(a => a.ProcessedBy)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (allocation == null || !allocation.IsActive)
                {
                    return NotFound();
                }

                if (!allocation.CanBeModified())
                {
                    TempData["error"] = "This allocation cannot be modified in its current status.";
                    return RedirectToAction(nameof(Details), new { id = allocation.Id });
                }

                vm = FridgeAllocationVM.FromEntity(allocation);
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }

        // POST: FridgeAllocations/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> Upsert(FridgeAllocationVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Additional validation
                    var validationErrors = vm.GetValidationErrors().ToList();
                    if (validationErrors.Any())
                    {
                        foreach (var error in validationErrors)
                        {
                            ModelState.AddModelError("", error);
                        }
                        await PopulateDropdowns(vm);
                        return View(vm);
                    }

                    // Check fridge availability
                    var fridge = await _db.Fridges
                        .Include(f => f.FridgeModel)
                        .FirstOrDefaultAsync(f => f.Id == vm.FridgeId);

                    if (fridge == null || fridge.Status != FridgeStatus.Available)
                    {
                        ModelState.AddModelError("FridgeId", "Selected fridge is not available for allocation.");
                        await PopulateDropdowns(vm);
                        return View(vm);
                    }

                    if (vm.Id == 0)
                    {
                        // Create new allocation
                        var allocation = vm.ToEntity();
                        allocation.CreatedAt = DateTime.UtcNow;
                        allocation.CreatedBy = User.Identity.Name;
                        allocation.AllocatedByEmployeeId = await GetCurrentEmployeeIdAsync();

                        _db.FridgeAllocations.Add(allocation);
                        await _db.SaveChangesAsync();

                        // Update fridge status
                        await UpdateFridgeStatus(vm.FridgeId, FridgeStatus.Allocated);

                        TempData["success"] = "Fridge allocated successfully";
                    }
                    else
                    {
                        // Update existing allocation
                        var allocation = await _db.FridgeAllocations.FindAsync(vm.Id);
                        if (allocation == null)
                        {
                            return NotFound();
                        }

                        if (!allocation.CanBeModified())
                        {
                            TempData["error"] = "This allocation cannot be modified in its current status.";
                            return RedirectToAction(nameof(Details), new { id = allocation.Id });
                        }

                        // Store original fridge ID for status update
                        var originalFridgeId = allocation.FridgeId;

                        // Update properties
                        allocation.FridgeId = vm.FridgeId;
                        allocation.CustomerId = vm.CustomerId;
                        allocation.DeliveryLocationId = vm.DeliveryLocationId;
                        allocation.Quantity = vm.Quantity;
                        allocation.AllocationDate = vm.AllocationDate;
                        allocation.ExpectedReturnDate = vm.ExpectedReturnDate;
                        allocation.ActualReturnDate = vm.ActualReturnDate;
                        allocation.MonthlyRentalPrice = vm.MonthlyRentalPrice;
                        allocation.Notes = vm.Notes;
                        allocation.AllocationStatus = vm.Status;
                        allocation.UpdatedAt = DateTime.UtcNow;
                        allocation.UpdatedBy = User.Identity.Name;

                        _db.FridgeAllocations.Update(allocation);
                        await _db.SaveChangesAsync();

                        // Update fridge status if fridge was changed
                        if (originalFridgeId != vm.FridgeId)
                        {
                            await UpdateFridgeStatus(originalFridgeId, FridgeStatus.Available);
                            await UpdateFridgeStatus(vm.FridgeId, FridgeStatus.Allocated);
                        }

                        TempData["success"] = "Allocation updated successfully";
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error saving allocation: {ex.Message}");
                    // Log the exception
                    System.Diagnostics.Debug.WriteLine($"Error in Upsert: {ex.Message}");
                }
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }

        // GET: FridgeAllocations/Deallocate/5
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> Deallocate(int id)
        {
            var allocation = await _db.FridgeAllocations
                .Include(a => a.Fridge)
                    .ThenInclude(f => f.FridgeModel)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (allocation == null || !allocation.IsActive)
            {
                return NotFound();
            }

            if (!allocation.CanBeDeallocated())
            {
                TempData["error"] = "This allocation cannot be deallocated in its current status.";
                return RedirectToAction(nameof(Details), new { id = allocation.Id });
            }

            var vm = new DeallocationVM
            {
                AllocationId = allocation.Id,
                FridgeSerialNumber = allocation.Fridge?.SerialNumber ?? "Unknown",
                FridgeModel = allocation.Fridge?.FridgeModel?.DisplayName ?? "Unknown Model",
                CustomerName = allocation.Customer?.BusinessName ?? "Unknown Customer",
                CustomerBusinessType = allocation.Customer?.BusinessType ?? BusinessType.SpazaShop,
                AllocationDate = allocation.AllocationDate,
                MonthlyRental = allocation.MonthlyRentalPrice,
                Quantity = allocation.Quantity
            };

            await PopulateDeallocationDropdowns(vm);
            return View(vm);
        }

        // POST: FridgeAllocations/Deallocate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> Deallocate(DeallocationVM vm)
        {
            if (ModelState.IsValid)
            {
                var allocation = await _db.FridgeAllocations
                    .Include(a => a.Fridge)
                    .FirstOrDefaultAsync(a => a.Id == vm.AllocationId);

                if (allocation == null)
                {
                    return NotFound();
                }

                if (!allocation.CanBeDeallocated())
                {
                    TempData["error"] = "This allocation cannot be deallocated in its current status.";
                    return RedirectToAction(nameof(Details), new { id = allocation.Id });
                }

                // Validate deallocation date
                if (vm.DeallocationDate < allocation.AllocationDate)
                {
                    ModelState.AddModelError("DeallocationDate", "Deallocation date cannot be before allocation date.");
                    await PopulateDeallocationDropdowns(vm);
                    return View(vm);
                }

                try
                {
                    // Set processed by information
                    var currentEmployeeId = await GetCurrentEmployeeIdAsync();
                    var currentEmployee = await _db.Employees
                        .Include(e => e.UserAccount)
                        .FirstOrDefaultAsync(e => e.Id == currentEmployeeId);

                    vm.SetProcessedBy(currentEmployee?.UserAccount?.FullName ?? User.Identity.Name, currentEmployeeId);

                    // Apply deallocation to the allocation entity
                    vm.ApplyToAllocation(allocation);
                    allocation.UpdatedAt = DateTime.UtcNow;
                    allocation.UpdatedBy = User.Identity.Name;

                    _db.FridgeAllocations.Update(allocation);
                    await _db.SaveChangesAsync();

                    // Update fridge status based on return condition
                    var newFridgeStatus = vm.CanBeReallocated ? FridgeStatus.Available :
                                        vm.ShouldBeScrapped ? FridgeStatus.Scrapped : FridgeStatus.Quarantined;

                    await UpdateFridgeStatus(allocation.FridgeId, newFridgeStatus);

                    // If maintenance is required, create a maintenance request
                    if (vm.RequiresMaintenance && !string.IsNullOrEmpty(vm.MaintenanceRequired))
                    {
                        await CreateMaintenanceRequest(allocation, vm);
                    }

                    TempData["success"] = "Fridge deallocated successfully";
                    return RedirectToAction(nameof(Details), new { id = allocation.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error deallocating fridge: {ex.Message}");
                    System.Diagnostics.Debug.WriteLine($"Error in Deallocate: {ex.Message}");
                }
            }

            await PopulateDeallocationDropdowns(vm);
            return View(vm);
        }

        // GET: FridgeAllocations/CustomerAllocations
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> CustomerAllocations()
        {
            var customer = await GetCurrentCustomerAsync();
            if (customer == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var allocations = await _db.FridgeAllocations
                .Include(a => a.Fridge)
                    .ThenInclude(f => f.FridgeModel)
                .Include(a => a.DeliveryLocation)
                .Where(a => a.CustomerId == customer.Id && a.IsActive)
                .OrderByDescending(a => a.AllocationDate)
                .ToListAsync();

            var vmList = allocations.Select(a => FridgeAllocationVM.FromEntity(a)).ToList();
            return View(vmList);
        }

        // POST: FridgeAllocations/UpdateStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> UpdateStatus(int id, AllocationStatus newStatus, string? notes = null)
        {
            var allocation = await _db.FridgeAllocations.FindAsync(id);
            if (allocation == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Details), new { id = allocation.Id });
        }

        // POST: FridgeAllocations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole)]
        public async Task<IActionResult> Delete(int id)
        {
            var allocation = await _db.FridgeAllocations.FindAsync(id);
            if (allocation == null)
            {
                return NotFound();
            }

            if (allocation.AllocationStatus != AllocationStatus.Pending)
            {
                TempData["error"] = "Only pending allocations can be deleted.";
                return RedirectToAction(nameof(Details), new { id = allocation.Id });
            }

            // Soft delete
            allocation.IsDeleted = true;
            allocation.UpdatedAt = DateTime.UtcNow;
            allocation.UpdatedBy = User.Identity.Name;

            // Update fridge status back to available
            await UpdateFridgeStatus(allocation.FridgeId, FridgeStatus.Available);

            _db.FridgeAllocations.Update(allocation);
            await _db.SaveChangesAsync();

            TempData["success"] = "Allocation deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        #region Private Helper Methods

        private async Task PopulateDropdowns(FridgeAllocationVM vm)
        {
            vm.FridgeList = await _db.Fridges
                .Include(f => f.FridgeModel)
                .Where(f => f.Status == FridgeStatus.Available && f.IsActive)
                .OrderBy(f => f.SerialNumber)
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = $"{f.SerialNumber} - {f.FridgeModel.DisplayName} ({f.FridgeModel.CapacityLiters}L)"
                })
                .ToListAsync();

            vm.CustomerList = await _db.Customers
                .Where(c => !c.UserAccount.IsDeleted)
                .OrderBy(c => c.BusinessName)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.BusinessName} ({c.BusinessType})"
                })
                .ToListAsync();

            vm.LocationList = await _db.Locations
                .Where(l => l.IsDeleted)
                .OrderBy(l => l.City)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = $"{l.StreetAddress} - {l.Suburb}, {l.City}"
                })
                .ToListAsync();

            vm.EmployeeList = await _db.Employees
                .Include(e => e.UserAccount)
                .Where(e => !e.UserAccount.IsDeleted)
                .OrderBy(e => e.UserAccount.LastName)
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = $"{e.UserAccount.FirstName} {e.UserAccount.LastName} - {e.EmployeeType}"
                })
                .ToListAsync();

            vm.StatusList = Enum.GetValues<AllocationStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString()
                })
                .ToList();

            vm.RequestList = await _db.AllocationRequestHeaders
                .Where(r => r.Status == AllocationRequestStatus.Approved && r.IsApproved)
                .OrderByDescending(r => r.RequestDate)
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = $"Request #{r.Id:00000} - {r.Customer.BusinessName} ({r.RequestDate:dd/MM/yyyy})"
                })
                .ToListAsync();
        }

        private async Task PopulateDeallocationDropdowns(DeallocationVM vm)
        {
            vm.FridgeConditionList = Enum.GetValues<FridgeCondition>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()
                })
                .ToList();
        }

        private async Task<int> GetCurrentEmployeeIdAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _db.Employees
                .FirstOrDefaultAsync(e => e.UserId == userId && !e.UserAccount.IsDeleted);
            return employee?.Id ?? 0;
        }

        private async Task<Customer?> GetCurrentCustomerAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _db.Customers
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.UserAccount.IsDeleted);
        }

        private async Task UpdateFridgeStatus(int fridgeId, FridgeStatus status)
        {
            var fridge = await _db.Fridges.FindAsync(fridgeId);
            if (fridge != null)
            {
                fridge.Status = status;
                fridge.UpdatedAt = DateTime.UtcNow;
                _db.Fridges.Update(fridge);
                await _db.SaveChangesAsync();
            }
        }

        private async Task CreateMaintenanceRequest(FridgeAllocation allocation, DeallocationVM vm)
        {
            var maintenanceRequest = new MaintenanceVisit
            {
                FridgeId = allocation.FridgeId,
                CustomerId = allocation.CustomerId,
                ScheduledDate = DateTime.UtcNow.AddDays(7), // Schedule for next week
                Status = ServicingStatus.Scheduled,
                MaintenanceDetails = $"Maintenance required after deallocation: {vm.MaintenanceRequired}",
                CreatedBy = User.Identity.Name,
                CreatedAt = DateTime.UtcNow
            };

            _db.MaintenanceVisits.Add(maintenanceRequest);
            await _db.SaveChangesAsync();
        }

        #endregion
    }


    //[Authorize]
    //public class FridgeAllocationsController : Controller
    //{
    //    private readonly ApplicationDbContext _db;
    //    [BindProperty]
    //    public FridgeAllocationVM AllocationVM { get; set; }

    //    public FridgeAllocationsController(ApplicationDbContext db)
    //    {
    //        _db = db;
    //    }
    //    public IActionResult Index()
    //    {
    //        var claimsIdentity=(ClaimsIdentity)User.Identity;
    //        var userId= claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
    //        AllocationVM = new()
    //        {
    //                AllocationList = _db.FridgeAllocations
    //                .Include(a => a.Fridge)
    //                .Where(a => a.Customer.UserId==userId)
    //                .ToList(),
    //                 RequestHeader = new()
    //        };
    //        foreach (var allocation in AllocationVM.AllocationList)
    //        {
    //           allocation.StoredPrice = GetPriceBasedOnQuantity(allocation);
    //           AllocationVM.RequestHeader.RequestTotal += (allocation.Price * allocation.Quantity);
    //        }
    //        return View(AllocationVM);          
    //    }
    //    public IActionResult Summary()
    //    {
    //        var claimsIdentity = (ClaimsIdentity)User.Identity;
    //        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

    //        // Get the customer with their related UserAccount
    //        var customer = _db.Customers
    //            .Include(c => c.UserAccount)  // Important: Include the UserAccount
    //            .FirstOrDefault(u => u.UserId == userId);

    //        if (customer == null)
    //        {
    //            // Handle the case where customer is not found
    //            return NotFound();
    //        }


    //        AllocationVM = new()
    //        {
    //            AllocationList = _db.FridgeAllocations
    //                .Include(a => a.Fridge)
    //                .Where(a => a.Customer.UserId == userId)
    //                .ToList(),
    //            RequestHeader = new()
    //        };

    //        AllocationVM.RequestHeader.Customer = customer;
    //        AllocationVM.RequestHeader.CustomerId = customer.Id;

    //        // Get properties from UserAccount instead of Customer
    //        AllocationVM.RequestHeader.FirstName = customer.UserAccount?.FirstName ?? "";
    //        AllocationVM.RequestHeader.LastName = customer.UserAccount?.LastName ?? "";

    //        // Use Customer'CustomersController address properties (not UserAccount'CustomersController)
    //        AllocationVM.RequestHeader.StreetAddress = customer.StreetAddress;
    //        AllocationVM.RequestHeader.AddressLine2 = customer.AddressLine2;
    //        AllocationVM.RequestHeader.City = customer.City;
    //        AllocationVM.RequestHeader.Province = customer.Province;
    //        AllocationVM.RequestHeader.PostalCode = customer.PostalCode;

    //        // Use BusinessPhoneNumber from Customer
    //        AllocationVM.RequestHeader.PhoneNumber = customer.BusinessPhoneNumber;


    //        foreach (var allocation in AllocationVM.AllocationList)
    //        {
    //            allocation.StoredPrice = GetPriceBasedOnQuantity(allocation);
    //            AllocationVM.RequestHeader.RequestTotal += (allocation.Price * allocation.Quantity);
    //        }
    //        return View(AllocationVM);
    //    }


    //    [HttpPost]
    //    [ActionName("Summary")]
    //    public IActionResult SummaryPost()
    //    {
    //        var claimsIdedity = (ClaimsIdentity)User.Identity;
    //        var userId = claimsIdedity.FindFirst(ClaimTypes.NameIdentifier).Value;

    //        AllocationVM.AllocationList = _db.FridgeAllocations
    //                 .Include(a => a.Fridge)
    //                 .Where(a => a.Customer.UserId == userId)
    //                 .ToList();

    //        AllocationVM.RequestHeader.RequestDate = System.DateTime.Now;
    //        AllocationVM.RequestHeader.Customer.UserId = userId;

    //        ApplicationUser applicationUser = _db.ApplicationUsers.FirstOrDefault(u => u.Id == userId);



    //        foreach (var allocation in AllocationVM.AllocationList)
    //        {
    //            allocation.StoredPrice = GetPriceBasedOnQuantity(allocation);
    //            AllocationVM.RequestHeader.RequestTotal += (allocation.Price * allocation.Quantity);
    //        }


    //        _db.AllocationRequestHeaders.Add(AllocationVM.RequestHeader);
    //        _db.SaveChanges();

    //        foreach (var allocation in AllocationVM.AllocationList)
    //        {
    //            AllocationRequestDetail requestDetail = new()
    //            {
    //                FridgeId = allocation.FridgeId,
    //                RequestHeaderId = AllocationVM.RequestHeader.Id,
    //                Price = allocation.Price,
    //                Quantity = allocation.Quantity,
    //            };
    //            _db.AllocationRequestDetails.Add(requestDetail);
    //            _db.SaveChanges();

    //        }
    //        return RedirectToAction(nameof(Confirmation));
    //    }


    //    public IActionResult Confirmation(int id)
    //    {
    //        return View(id);
    //    }
    //    private decimal GetPriceBasedOnQuantity(Models.RelatedAllocation Allocation)
    //    {


    //            return Allocation.Fridge.RentalPricePerMonth;

    //    }
    //    public IActionResult Plus(int id)
    //    {
    //        var allocationFromDb = _db.FridgeAllocations.FirstOrDefault(u => u.Id == id);
    //        if (allocationFromDb == null)
    //        {
    //            return NotFound();
    //        }
    //        allocationFromDb.Quantity += 1;
    //        _db.FridgeAllocations.Update(allocationFromDb);
    //        _db.SaveChanges();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    public IActionResult Minus(int id)
    //    {
    //        var allocationFromDb = _db.FridgeAllocations.FirstOrDefault(u => u.Id == id);
    //        if (allocationFromDb.Quantity >= 0)
    //        {
    //            _db.FridgeAllocations.Remove(allocationFromDb);
    //        }
    //        else
    //        {
    //            allocationFromDb.Quantity -= 1;
    //            _db.FridgeAllocations.Update(allocationFromDb);
    //        }
    //        _db.SaveChanges();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    public IActionResult Remove(int id)
    //    {
    //        var allocationFromDb = _db.FridgeAllocations.FirstOrDefault(u => u.Id == id);

    //        _db.FridgeAllocations.Remove(allocationFromDb);
    //        _db.SaveChanges();
    //        return RedirectToAction(nameof(Index));
    //    }
    //}
}
