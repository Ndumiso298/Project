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
    [Authorize(Roles = SD.CustomerRole)]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomerController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        // Customer Dashboard
        public async Task<IActionResult> Dashboard()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction("Index", "Home");
            }

            var model = new CustomerDashboardVM
            {
                Customer = customer,
                ActiveFridges = await _db.tblCustomerFridge
                    .Where(cf => cf.CustomerID == customer.CustomerID)
                    .Include(cf => cf.Fridge)
                    .Include(cf => cf.FridgeInStock)
                    .ToListAsync(),
                RecentFaults = await _db.tblFaultReports
                    .Where(fr => fr.CustomerId == customer.CustomerID)
                    .OrderByDescending(fr => fr.ReportedDate) 
                    .Take(5)
                    .ToListAsync(),
                PendingRequests = await _db.tblRequestHeaders
                    .Where(rh => rh.CustomerID == customer.CustomerID && rh.Status == SD.Pending)
                    .CountAsync()
            };

            return View(model);
        }

        // Browse available fridges
        public IActionResult Index()
        {
            var fridgesList = _db.tblFridges
                .Where(f => f.AvailabilityStatus == "Available")
                .ToList();
            return View(fridgesList);
        }

        // Fridge Details - GET
        public IActionResult Details(int id)
        {
            var fridge = _db.tblFridges.FirstOrDefault(u => u.FridgeId == id);
            if (fridge == null)
            {
                TempData[SD.Error] = "Fridge not found.";
                return RedirectToAction(nameof(Index));
            }

            var addToCartVM = new AddToCartVM
            {
                FridgeId = fridge.FridgeId,
                Count = 1,
                Brand = fridge.Brand,
                Model = fridge.Model,
                Description = fridge.Description,
                RentalPricePerMonth = fridge.RentalPricePerMonth,
                CapacityLiters = fridge.CapacityLiters,
                Type = fridge.Type,
                ImageUrl = fridge.ImageUrl
            };

            return View(addToCartVM);
        }

        // Add to Cart - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(AddToCartVM addToCartVM)
        {
            if (!ModelState.IsValid)
            {
                var fridge = _db.tblFridges.Find(addToCartVM.FridgeId);
                if (fridge != null)
                {
                    addToCartVM.Brand = fridge.Brand;
                    addToCartVM.Model = fridge.Model;
                    addToCartVM.Description = fridge.Description;
                    addToCartVM.RentalPricePerMonth = fridge.RentalPricePerMonth;
                    addToCartVM.CapacityLiters = fridge.CapacityLiters;
                    addToCartVM.Type = fridge.Type;
                    addToCartVM.ImageUrl = fridge.ImageUrl;
                }
                return View(addToCartVM);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var fridge = _db.tblFridges.Find(addToCartVM.FridgeId);
                if (fridge == null)
                {
                    TempData[SD.Error] = "Selected fridge not found.";
                    return RedirectToAction(nameof(Index));
                }

                var existingAllocation = _db.tblAllocations
                    .FirstOrDefault(a => a.CustomerID == customer.CustomerID && a.FridgeId == addToCartVM.FridgeId);

                if (existingAllocation != null)
                {
                    existingAllocation.Count += addToCartVM.Count;
                    TempData[SD.Success] = $"Updated quantity for {fridge.Brand} {fridge.Model}. Total: {existingAllocation.Count}";
                }
                else
                {
                    var newAllocation = new Allocation
                    {
                        CustomerID = customer.CustomerID,
                        FridgeId = addToCartVM.FridgeId,
                        Count = addToCartVM.Count,
                        RejectReason = "Not Rejected",
                        Status = "InCart",
                        AllocationDate = DateTime.Now
                    };
                    _db.tblAllocations.Add(newAllocation);
                    TempData[SD.Success] = $"Added {fridge.Brand} {fridge.Model} to cart!";
                }

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                TempData[SD.Error] = "An unexpected error occurred.";
                return RedirectToAction(nameof(Index));
            }
        }

        // View Cart
        public IActionResult Cart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Index));
            }

            var allocations = _db.tblAllocations
                .Where(a => a.CustomerID == customer.CustomerID && a.Status == "InCart")
                .Include(a => a.Fridge)
                .ToList();

            return View(allocations);
        }

        // Remove from Cart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCart(int allocationId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Cart));
            }

            try
            {
                var allocation = _db.tblAllocations
                    .FirstOrDefault(a => a.AllocationId == allocationId && a.CustomerID == customer.CustomerID);

                if (allocation != null)
                {
                    _db.tblAllocations.Remove(allocation);
                    _db.SaveChanges();
                    TempData[SD.Success] = "Item removed from cart.";
                }
                else
                {
                    TempData[SD.Error] = "Item not found in cart.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing from cart: {ex.Message}");
                TempData[SD.Error] = "Error removing item from cart.";
            }

            return RedirectToAction(nameof(Cart));
        }

        // Update Cart Quantity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCartQuantity(int allocationId, int newQuantity)
        {
            if (newQuantity < 1)
            {
                TempData[SD.Error] = "Quantity must be at least 1.";
                return RedirectToAction(nameof(Cart));
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Cart));
            }

            try
            {
                var allocation = _db.tblAllocations
                    .FirstOrDefault(a => a.AllocationId == allocationId && a.CustomerID == customer.CustomerID);

                if (allocation != null)
                {
                    allocation.Count = newQuantity;
                    _db.SaveChanges();
                    TempData[SD.Success] = "Cart updated successfully.";
                }
                else
                {
                    TempData[SD.Error] = "Item not found in cart.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating cart: {ex.Message}");
                TempData[SD.Error] = "Error updating cart.";
            }

            return RedirectToAction(nameof(Cart));
        }

        // Checkout - Process cart to request
        public IActionResult Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefault(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Index));
            }

            var allocations = _db.tblAllocations
                .Where(a => a.CustomerID == customer.CustomerID && a.Status == "InCart")
                .Include(a => a.Fridge)
                .ToList();

            if (!allocations.Any())
            {
                TempData[SD.Error] = "Your cart is empty.";
                return RedirectToAction(nameof(Cart));
            }

            var allocationVM = new AllocationVM
            {
                AllocationList = allocations,
                RequestHeader = new RequestHeader
                {
                    FirstName = customer.ApplicationUser.FirstName,
                    LastName = customer.ApplicationUser.LastName,
                    CellNumber = customer.ApplicationUser.CellNumber ?? "",
                    StreetAddress = customer.ApplicationUser.StreetAddress ?? "",
                    City = customer.ApplicationUser.City ?? "",
                    State = customer.ApplicationUser.State ?? "",
                    PostalCode = customer.ApplicationUser.PostalCode ?? ""
                }
            };

            return View(allocationVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(AllocationVM allocationVM)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                var allocations = _db.tblAllocations
                    .Where(a => a.CustomerID == customer.CustomerID && a.Status == "InCart")
                    .Include(a => a.Fridge)
                    .ToList();
                allocationVM.AllocationList = allocations;
                return View(allocationVM);
            }

            try
            {
                var cartAllocations = _db.tblAllocations
                    .Where(a => a.CustomerID == customer.CustomerID && a.Status == "InCart")
                    .Include(a => a.Fridge)
                    .ToList();

                if (!cartAllocations.Any())
                {
                    TempData[SD.Error] = "Your cart is empty.";
                    return RedirectToAction(nameof(Cart));
                }

                var requestHeader = new RequestHeader
                {
                    CustomerID = customer.CustomerID,
                    RequestDate = DateTime.Now,
                    RequestTotal = cartAllocations.Sum(a => a.Count * (a.Fridge.RentalPricePerMonth)),
                    FirstName = allocationVM.RequestHeader.FirstName,
                    LastName = allocationVM.RequestHeader.LastName,
                    StreetAddress = allocationVM.RequestHeader.StreetAddress,
                    City = allocationVM.RequestHeader.City,
                    State = allocationVM.RequestHeader.State,
                    PostalCode = allocationVM.RequestHeader.PostalCode,
                    CellNumber = allocationVM.RequestHeader.CellNumber,
                    Status = SD.Pending,
                    PaymentDueDate = DateTime.Now.AddDays(7)
                };

                _db.tblRequestHeaders.Add(requestHeader);
                await _db.SaveChangesAsync();

                foreach (var allocation in cartAllocations)
                {
                    var requestDetail = new RequestDetails
                    {
                        RequestHeaderId = requestHeader.RequestHeaderId,
                        FridgeId = allocation.FridgeId,
                        Count = allocation.Count,
                        Price = allocation.Fridge.RentalPricePerMonth
                    };
                    _db.tblRequestDetais.Add(requestDetail); 
                    allocation.Status = "Submitted";
                }

                await _db.SaveChangesAsync();

                TempData[SD.Success] = "Checkout successful! Your request has been submitted.";
                return RedirectToAction(nameof(ViewRequestStatus));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Checkout error: {ex.Message}");
                TempData[SD.Error] = "Error during checkout. Please try again.";
                return RedirectToAction(nameof(Cart));
            }
        }

        // CREATE FAULT REPORT - GET
        public async Task<IActionResult> CreateFault()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Dashboard));
            }

            var customerFridges = await _db.tblCustomerFridge
                .Where(cf => cf.CustomerID == customer.CustomerID)
                .Include(cf => cf.FridgeInStock).ThenInclude(fis => fis.Fridge)
                .ToListAsync();

            var viewModel = new FaultReportVM
            {
                AvailableFridges = customerFridges,
                CustomerName = $"{customer.ApplicationUser.FirstName} {customer.ApplicationUser.LastName}"
            };

            return View(viewModel);
        }

        // CREATE FAULT REPORT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFault(FaultReportVM faultReportVM)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Dashboard));
            }

            if (!ModelState.IsValid)
            {
                await ReloadFaultReportVM(faultReportVM, customer.CustomerID);
                return View(faultReportVM);
            }

            try
            {
                // Verify fridge allocation
                var allocated = await _db.tblCustomerFridge
                    .AnyAsync(cf => cf.CustomerID == customer.CustomerID && cf.FridgeInStockId == faultReportVM.FridgeInStockId);

                if (!allocated)
                {
                    TempData[SD.Error] = "You can only report faults for your allocated fridges.";
                    await ReloadFaultReportVM(faultReportVM, customer.CustomerID);
                    return View(faultReportVM);
                }

                // Handle image upload
                string? imageUrl = null;
                if (faultReportVM.FaultImages != null && faultReportVM.FaultImages.Count > 0)
                {
                    imageUrl = await SaveFaultImages(faultReportVM.FaultImages);
                }

                // Create the fault report entity
                var faultReport = new FaultReport
                {
                    CustomerId = customer.CustomerID,
                    FridgeInStockId = faultReportVM.FridgeInStockId,
                    FaultType = faultReportVM.FaultType,
                    Description = faultReportVM.Description,
                    ReportedDate = DateTime.Now,
                    Status = "Reported",
                    Priority = faultReportVM.Priority,
                    ImageUrl = imageUrl,
                    RequestReplacement = faultReportVM.RequestReplacement,
                    DeclineReason = null
                };

                _db.tblFaultReports.Add(faultReport);
                await _db.SaveChangesAsync();

                // Create FaultTechnician record
                var faultTechnician = new FaultTechnician
                {
                    FaultDescription = $"{faultReportVM.FaultType}: {faultReportVM.Description}",
                    FaultReportId = faultReport.FaultReportId,
                    CustomerBookingStatus = "Pending",
                    Priority = faultReportVM.Priority
                };
                _db.tblFaultTechnicians.Add(faultTechnician);

                

                await _db.SaveChangesAsync();

                TempData[SD.Success] = "Fault reported successfully! Our team will contact you soon.";
                return RedirectToAction(nameof(ViewFaultStatus));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating fault report: {ex.Message}");
                TempData[SD.Error] = "Error reporting fault. Please try again.";
                await ReloadFaultReportVM(faultReportVM, customer.CustomerID);
                return View(faultReportVM);
            }
        }

        // RELAUNCH DECLINED FAULT REQUEST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RelaunchFault(int faultReportId, string additionalInfo)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Dashboard));
            }

            try
            {
                var originalFault = await _db.tblFaultReports
                    .FirstOrDefaultAsync(fr => fr.FaultReportId == faultReportId && fr.CustomerId == customer.CustomerID);

                if (originalFault == null)
                {
                    TempData[SD.Error] = "Fault report not found.";
                    return RedirectToAction(nameof(ViewFaultStatus));
                }

                if (originalFault.Status != "Declined")
                {
                    TempData[SD.Error] = "Only declined requests can be relaunched.";
                    return RedirectToAction(nameof(ViewFaultStatus));
                }

                var newFaultReport = new FaultReport
                {
                    CustomerId = customer.CustomerID,
                    FridgeInStockId = originalFault.FridgeInStockId,
                    FaultType = originalFault.FaultType,
                    Description = originalFault.Description +
                                 (string.IsNullOrEmpty(additionalInfo) ? "" : $"\n\nAdditional Info: {additionalInfo}"),
                    ReportedDate = DateTime.Now,
                    Status = "Reported",
                    Priority = originalFault.Priority,
                    ImageUrl = originalFault.ImageUrl,
                    RequestReplacement = originalFault.RequestReplacement,
                    DeclineReason = null,
                    IsRelaunched = true,
                    OriginalFaultReportId = faultReportId
                };

                _db.tblFaultReports.Add(newFaultReport);
                await _db.SaveChangesAsync();

                var newFaultTechnician = new FaultTechnician
                {
                    FaultDescription = $"{newFaultReport.FaultType}: {newFaultReport.Description}",
                    FaultReportId = newFaultReport.FaultReportId,
                    CustomerBookingStatus = "Pending",
                    Priority = newFaultReport.Priority
                };
                _db.tblFaultTechnicians.Add(newFaultTechnician);
                await _db.SaveChangesAsync();

                TempData[SD.Success] = "Fault request relaunched successfully!";
                return RedirectToAction(nameof(ViewFaultStatus));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error relaunching fault report: {ex.Message}");
                TempData[SD.Error] = "Error relaunching fault request. Please try again.";
                return RedirectToAction(nameof(ViewFaultStatus));
            }
        }

        // VIEW REQUEST DETAILS
        public async Task<IActionResult> RequestDetails(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Dashboard));
            }

            var request = await _db.tblRequestHeaders
                .Include(rh => rh.RequestFridges)
                    .ThenInclude(rd => rd.Fridge)
                .FirstOrDefaultAsync(rh => rh.RequestHeaderId == id && rh.CustomerID == customer.CustomerID);

            if (request == null)
            {
                TempData[SD.Error] = "Request not found.";
                return RedirectToAction(nameof(ViewRequestStatus));
            }

            return View(request);
        }

        // VIEW REQUEST STATUS
        public async Task<IActionResult> ViewRequestStatus()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Dashboard));
            }

            var requests = await _db.tblRequestHeaders
                .Where(rh => rh.CustomerID == customer.CustomerID)
                .Include(rh => rh.RequestFridges)
                    .ThenInclude(rd => rd.Fridge)
                .OrderByDescending(rh => rh.RequestDate)
                .ToListAsync();

            return View(requests);
        }

        // VIEW FAULT STATUS
        public async Task<IActionResult> ViewFaultStatus(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Dashboard));
            }

            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;
            ViewData["DateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewData["FaultTypeSortParm"] = sortOrder == "faulttype" ? "faulttype_desc" : "faulttype";
            ViewData["PrioritySortParm"] = sortOrder == "priority" ? "priority_desc" : "priority";
            ViewData["StatusSortParm"] = sortOrder == "status" ? "status_desc" : "status";

            var faults = _db.tblFaultReports
                .Where(fr => fr.CustomerId == customer.CustomerID)
                .Include(fr => fr.FaultTechnicians)
                .Include(fr => fr.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                faults = faults.Where(fr => fr.FaultType.Contains(searchString) || fr.Status.Contains(searchString));
            }

            faults = sortOrder switch
            {
                "date_desc" => faults.OrderByDescending(fr => fr.ReportedDate),
                "faulttype" => faults.OrderBy(fr => fr.FaultType),
                "faulttype_desc" => faults.OrderByDescending(fr => fr.FaultType),
                "priority" => faults.OrderBy(fr => fr.Priority),
                "priority_desc" => faults.OrderByDescending(fr => fr.Priority),
                "status" => faults.OrderBy(fr => fr.Status),
                "status_desc" => faults.OrderByDescending(fr => fr.Status),
                _ => faults.OrderByDescending(fr => fr.ReportedDate)
            };

            int pageSize = 10;
            int pageNumber = page ?? 1;

            var paginatedFaults = await Project.Utility.PaginatedList<FaultReport>.CreateAsync(faults.AsNoTracking(), pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = paginatedFaults.TotalPages;

            return View(paginatedFaults);
        }

        // CREATE FRIDGE REQUEST - GET
       
        // VIEW FAULT DETAILS
        public async Task<IActionResult> FaultDetails(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Dashboard));
            }

            var fault = await _db.tblFaultReports
                .Include(fr => fr.FaultTechnicians)
                .Include(fr => fr.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                .FirstOrDefaultAsync(fr => fr.FaultReportId == id && fr.CustomerId == customer.CustomerID);

            if (fault == null)
            {
                TempData[SD.Error] = "Fault report not found.";
                return RedirectToAction(nameof(ViewFaultStatus));
            }

            return View(fault);
        }

        // CANCEL REQUEST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelRequest(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Dashboard));
            }

            try
            {
                var request = await _db.tblRequestHeaders
                    .FirstOrDefaultAsync(rh => rh.RequestHeaderId == id && rh.CustomerID == customer.CustomerID);

                if (request == null)
                {
                    TempData[SD.Error] = "Request not found.";
                    return RedirectToAction(nameof(ViewRequestStatus));
                }

                if (request.Status != SD.Pending)
                {
                    TempData[SD.Error] = "Only pending requests can be cancelled.";
                    return RedirectToAction(nameof(ViewRequestStatus));
                }

                request.Status = "Cancelled";
                await _db.SaveChangesAsync();

                TempData[SD.Success] = "Request cancelled successfully.";
                return RedirectToAction(nameof(ViewRequestStatus));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cancelling request: {ex.Message}");
                TempData[SD.Error] = "Error cancelling request. Please try again.";
                return RedirectToAction(nameof(ViewRequestStatus));
            }
        }

        // CLEAR CART
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClearCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Cart));
            }

            try
            {
                var cartItems = _db.tblAllocations
                    .Where(a => a.CustomerID == customer.CustomerID && a.Status == "InCart")
                    .ToList();

                _db.tblAllocations.RemoveRange(cartItems);
                _db.SaveChanges();

                TempData[SD.Success] = "Cart cleared successfully.";
                return RedirectToAction(nameof(Cart));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing cart: {ex.Message}");
                TempData[SD.Error] = "Error clearing cart. Please try again.";
                return RedirectToAction(nameof(Cart));
            }
        }

        // ========== HELPER METHODS ==========

        private async Task<string?> SaveFaultImages(List<IFormFile> faultImages)
        {
            var imageUrls = new List<string>();

            foreach (var image in faultImages)
            {
                if (image.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "faults", fileName);

                    var directory = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    imageUrls.Add($"/images/faults/{fileName}");
                }
            }

            return imageUrls.Count > 0 ? string.Join(",", imageUrls) : null;
        }

       

        private async Task ReloadFaultReportVM(FaultReportVM viewModel, int customerId)
        {
            var customerFridges = await _db.tblCustomerFridge
                .Where(cf => cf.CustomerID == customerId)
                .Include(cf => cf.FridgeInStock).ThenInclude(fis => fis.Fridge)
                .ToListAsync();

            viewModel.AvailableFridges = customerFridges;
            viewModel.CustomerName = (await _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.CustomerID == customerId))
                ?.ApplicationUser.FirstName + " " +
                (await _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.CustomerID == customerId))
                ?.ApplicationUser.LastName;
        }
    }
}