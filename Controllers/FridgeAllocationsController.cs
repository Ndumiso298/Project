using Microsoft.AspNetCore.Authorization;
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

        public FridgeAllocationsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Allocations
        public async Task<IActionResult> Index()
        {
            IQueryable<FridgeAllocation> query = _db.FridgeAllocations
                .Include(a => a.Fridge)
                .Include(a => a.Customer)
                .Include(a => a.AllocationLocation)
                .Where(a => a.IsActive);

            // Role-based filtering
            if (User.IsInRole(SD.CustomerRole))
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer != null)
                {
                    query = query.Where(a => a.CustomerId == customer.Id);
                }
            }

            var allocations = await query.OrderByDescending(a => a.AllocationDate).ToListAsync();
            return View(allocations);
        }

        // GET: Allocations/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var allocation = await _db.FridgeAllocations
                .Include(a => a.Fridge)
                .Include(a => a.Customer)
                .Include(a => a.AllocationLocation)
                .Include(a => a.AllocatedBy)
                .Include(a => a.ProcessedBy)
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

            return View(allocation);
        }

        // GET: Allocations/Upsert
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> Upsert(int? id)
        {
            var vm = new FridgeAllocationVM();
            await PopulateDropdowns(vm);

            if (id == null || id == 0)
            {
                // Create new allocation
                vm.AllocationDate = DateTime.Now;
                return View(vm);
            }

            // Edit existing allocation
            var allocation = await _db.FridgeAllocations
                .Include(a => a.Fridge)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (allocation == null || !allocation.IsActive)
            {
                return NotFound();
            }

            vm.Id = allocation.Id;
            vm.FridgeId = allocation.FridgeId;
            vm.CustomerId = allocation.CustomerId;
            vm.AllocationDate = allocation.AllocationDate;
            vm.AllocationLocationId = allocation.AllocationLocationId;
            vm.DeallocationDate = allocation.ActualReturnDate;
            vm.DeallocationReason = allocation.Notes;
            vm.AllocatedByEmployeeId = allocation.AllocatedById;
            vm.ProcessedByEmployeeId = allocation.ProcessedById;

            return View(vm);
        }

        // POST: Allocations/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> Upsert(FridgeAllocationVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.Id == 0)
                    {
                        // Create new allocation
                        var allocation = new FridgeAllocation
                        {
                            FridgeId = vm.FridgeId,
                            CustomerId = vm.CustomerId,
                            AllocationDate = vm.AllocationDate,
                            AllocationLocationId = vm.AllocationLocationId,
                            AllocatedById = await GetCurrentEmployeeIdAsync(),
                            ProcessedById = await GetCurrentEmployeeIdAsync(),
                            CreatedAt = DateTime.Now
                        };

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

                        allocation.FridgeId = vm.FridgeId;
                        allocation.CustomerId = vm.CustomerId;
                        allocation.AllocationDate = vm.AllocationDate;
                        allocation.AllocationLocationId = vm.AllocationLocationId;
                        allocation.ActualReturnDate = vm.DeallocationDate;
                        allocation.Notes = vm.DeallocationReason;
                        allocation.UpdatedAt = DateTime.Now;

                        _db.FridgeAllocations.Update(allocation);
                        await _db.SaveChangesAsync();

                        TempData["success"] = "Allocation updated successfully";
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error saving allocation: {ex.Message}");
                }
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }

        // GET: Allocations/Deallocate/5
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> Deallocate(int id)
        {
            var allocation = await _db.FridgeAllocations
                .Include(a => a.Fridge)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (allocation == null || !allocation.IsActive)
            {
                return NotFound();
            }

            var vm = new DeallocationVM
            {
                AllocationId = allocation.Id,
                FridgeSerialNumber = allocation.Fridge?.SerialNumber ?? "Unknown",
                CustomerName = allocation.Customer?.TradingName ?? "Unknown",
                AllocationDate = allocation.AllocationDate
            };

            return View(vm);
        }

        // POST: Allocations/Deallocate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> Deallocate(DeallocationVM vm)
        {
            if (ModelState.IsValid)
            {
                var allocation = await _db.FridgeAllocations.FindAsync(vm.AllocationId);
                if (allocation == null)
                {
                    return NotFound();
                }

                allocation.ActualReturnDate = vm.DeallocationDate;
                allocation.Notes = vm.DeallocationReason;
                allocation.UpdatedAt = DateTime.Now;

                _db.FridgeAllocations.Update(allocation);
                await _db.SaveChangesAsync();

                // Update fridge status back to available
                await UpdateFridgeStatus(allocation.FridgeId, FridgeStatus.Available);

                TempData["success"] = "Fridge deallocated successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // POST: Allocations/Delete/5 (Soft Delete)
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

            // Soft delete
            allocation.UpdatedAt = DateTime.Now;

            await _db.SaveChangesAsync();
            TempData["success"] = "Allocation deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        // Customer Cart Functionality (from your original code)
        public async Task<IActionResult> Cart()
        {
            if (!User.IsInRole(SD.CustomerRole))
            {
                return Forbid();
            }

            var customer = await GetCurrentCustomerAsync();
            if (customer == null)
            {
                return NotFound();
            }

            var cartAllocations = await _db.FridgeAllocations
                .Include(a => a.Fridge)
                .Where(a => a.CustomerId == customer.Id && a.IsActive && a.ActualReturnDate == null)
                .ToListAsync();

            var vm = new AllocationCartVM
            {
                Allocations = cartAllocations,
                Customer = customer
            };

            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> SubmitRequest()
        {
            var customer = await GetCurrentCustomerAsync();
            if (customer == null)
            {
                return NotFound();
            }

            try
            {
                var cartAllocations = await _db.FridgeAllocations
                    .Include(a => a.Fridge)
                    .Where(a => a.CustomerId == customer.Id && a.IsActive && a.ActualReturnDate == null)
                    .ToListAsync();

                if (!cartAllocations.Any())
                {
                    TempData["error"] = "No fridges in cart to submit";
                    return RedirectToAction(nameof(Cart));
                }

                // Create allocation request
                var request = new AllocationRequestHeader
                {
                    CustomerId = customer.Id,
                    RequestDate = DateTime.Now,
                    FirstName = customer.UserAccount?.FirstName ?? "",
                    LastName = customer.UserAccount?.LastName ?? "",
                    PhoneNumber = customer.BusinessPhoneNumber,
                    AddressLine1 = customer.AddressLine1,
                    AddressLine2 = customer.AddressLine2,
                    City = customer.City,
                    Province = customer.Province,
                    PostalCode = customer.PostalCode,
                    Status = "Submitted",
                    RequestTotal = cartAllocations.Sum(a => a.Fridge?.RentalPricePerMonth ?? 0)
                };

                _db.AllocationRequestHeaders.Add(request);
                await _db.SaveChangesAsync();

                // Create request details
                foreach (var allocation in cartAllocations)
                {
                    var detail = new AllocationRequestDetail
                    {
                        RequestHeaderId = request.Id,
                        FridgeId = allocation.FridgeId,
                        Quantity = 1, // Each allocation is for one fridge
                        Price = allocation.Fridge?.RentalPricePerMonth ?? 0
                    };
                    _db.AllocationRequestDetails.Add(detail);
                }

                await _db.SaveChangesAsync();
                TempData["success"] = "Allocation request submitted successfully";
                return RedirectToAction(nameof(RequestConfirmation), new { id = request.Id });
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Error submitting request: {ex.Message}";
                return RedirectToAction(nameof(Cart));
            }
        }

        public IActionResult RequestConfirmation(int id)
        {
            return View(id);
        }

        private async Task PopulateDropdowns(FridgeAllocationVM vm)
        {
            vm.FridgeList = await _db.Fridges
                .Where(f => f.Status == FridgeStatus.Available)
                .OrderBy(f => f.SerialNumber)
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = $"{f.SerialNumber} - {f.Model ?? "Unknown"}"
                })
                .ToListAsync();

            vm.CustomerList = await _db.Customers
                .Where(c => c.IsActive)
                .OrderBy(c => c.TradingName)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.TradingName
                })
                .ToListAsync();

            vm.LocationList = await _db.Locations
                .Where(l => l.IsActive)
                .OrderBy(l => l.Name)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name
                })
                .ToListAsync();

            vm.EmployeeList = await _db.Employees
                .Where(e => e.IsActive)
                .OrderBy(e => e.UserAccount.LastName)
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = $"{e.UserAccount.FirstName} {e.UserAccount.LastName} ({e.EmployeeNumber})"
                })
                .ToListAsync();
        }

        private async Task<int> GetCurrentEmployeeIdAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _db.Employees
                .FirstOrDefaultAsync(e => e.UserId == userId && e.IsActive);
            return employee.Id;
        }

        private async Task<Customer?> GetCurrentCustomerAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _db.Customers
                .Include(c => c.UserAccount)
                .FirstOrDefaultAsync(c => c.UserId == userId && c.IsActive);
        }

        private async Task UpdateFridgeStatus(int fridgeId, FridgeStatus status)
        {
            var fridge = await _db.Fridges.FindAsync(fridgeId);
            if (fridge != null)
            {
                fridge.Status = status;
                fridge.ModifiedDate = DateTime.Now;
                _db.Fridges.Update(fridge);
            }
        }
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
    //        AllocationVM.RequestHeader.AddressLine1 = customer.AddressLine1;
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
    //    private decimal GetPriceBasedOnQuantity(Models.FridgeAllocation Allocation)
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
