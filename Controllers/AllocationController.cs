using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize]
    public class AllocationController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public AllocationVM AllocationVM { get; set; }

        public AllocationController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            AllocationVM = new()
            {
                AllocationList = _db.tblAllocations
                    .Include(a => a.Fridge)
                    .Include(a => a.Customer)
                    .Where(a => a.Customer != null && a.Customer.ApplicationUserId == userId)
                    .ToList(),
                RequestHeader = new()
            };

            foreach (var allocation in AllocationVM.AllocationList)
            {
                allocation.Price = GetPriceBasedOnQuantity(allocation);
            }
            return View(AllocationVM);
        }

        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            AllocationVM = new()
            {
                AllocationList = _db.tblAllocations
                    .Include(a => a.Fridge)
                    .Include(a => a.Customer)
                    .Where(u => u.Customer.ApplicationUserId == userId)
                    .ToList(),
                RequestHeader = new()
            };

            AllocationVM.RequestHeader.Customer = _db.tblCustomer
                .Include(u => u.ApplicationUser)
                .FirstOrDefault(u => u.ApplicationUserId == userId);

            if (AllocationVM.RequestHeader.Customer?.ApplicationUser != null)
            {
                AllocationVM.RequestHeader.FirstName = AllocationVM.RequestHeader.Customer.ApplicationUser.FirstName;
                AllocationVM.RequestHeader.LastName = AllocationVM.RequestHeader.Customer.ApplicationUser.LastName;
                AllocationVM.RequestHeader.StreetAddress = AllocationVM.RequestHeader.Customer.ApplicationUser.StreetAddress ?? "";
                AllocationVM.RequestHeader.City = AllocationVM.RequestHeader.Customer.ApplicationUser.City ?? "";
                AllocationVM.RequestHeader.State = AllocationVM.RequestHeader.Customer.ApplicationUser.State ?? "";
                AllocationVM.RequestHeader.PostalCode = AllocationVM.RequestHeader.Customer.ApplicationUser.PostalCode ?? "";
                AllocationVM.RequestHeader.CellNumber = AllocationVM.RequestHeader.Customer.ApplicationUser.CellNumber ?? "";
            }

            foreach (var allocation in AllocationVM.AllocationList)
            {
                allocation.Price = GetPriceBasedOnQuantity(allocation);
            }

            return View(AllocationVM);
        }

        [HttpPost]
        [ActionName("Summary")]
        [ValidateAntiForgeryToken]
        public IActionResult SummaryPost()
        {
            // Terms and conditions validation using the bound property
            if (!AllocationVM.AcceptTerms)
            {
                TempData["Error"] = "You must accept the terms and conditions to place your order.";
                return RedirectToAction(nameof(Summary));
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            // Get current allocations from database
            var allocations = _db.tblAllocations
                     .Include(a => a.Fridge)
                     .Include(a => a.Customer)
                     .Where(a => a.Customer.ApplicationUserId == userId)
                     .ToList();

            var customer = _db.tblCustomer
                .Include(u => u.ApplicationUser)
                .FirstOrDefault(u => u.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData["Error"] = "Customer not found.";
                return RedirectToAction(nameof(Index));
            }

            if (!allocations.Any())
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction(nameof(Index));
            }

            // Create request header
            var requestHeader = new RequestHeader
            {
                CustomerID = customer.CustomerID,
                RequestDate = DateTime.Now,
                FirstName = AllocationVM.RequestHeader.FirstName,
                LastName = AllocationVM.RequestHeader.LastName,
                StreetAddress = AllocationVM.RequestHeader.StreetAddress,
                City = AllocationVM.RequestHeader.City,
                State = AllocationVM.RequestHeader.State,
                PostalCode = AllocationVM.RequestHeader.PostalCode,
                CellNumber = AllocationVM.RequestHeader.CellNumber,
                Status = "Pending",
                PaymentDueDate = DateTime.Now.AddDays(7)
            };

            // Calculate total
            foreach (var allocation in allocations)
            {
                var price = GetPriceBasedOnQuantity(allocation);
                requestHeader.RequestTotal += (price * allocation.Count);
            }

            // Add request header
            _db.tblRequestHeaders.Add(requestHeader);
            _db.SaveChanges();

            // Create request details
            foreach (var allocation in allocations)
            {
                var price = GetPriceBasedOnQuantity(allocation);
                RequestDetails requestDetail = new()
                {
                    FridgeId = allocation.FridgeId,
                    RequestHeaderId = requestHeader.RequestHeaderId,
                    Price = price,
                    Count = allocation.Count,
                };
                _db.tblRequestDetais.Add(requestDetail);
            }

            // Remove allocations after creating request
            _db.tblAllocations.RemoveRange(allocations);
            _db.SaveChanges();

            return RedirectToAction(nameof(Confirmation), new { id = requestHeader.RequestHeaderId });
        }

        public IActionResult Confirmation(int id)
        {
            return View(id);
        }

        private double GetPriceBasedOnQuantity(Allocation allocation)
        {
            return allocation.Fridge?.RentalPricePerMonth ?? 0.0;
        }

        public IActionResult Plus(int id)
        {
            var allocationFromDb = _db.tblAllocations.FirstOrDefault(u => u.AllocationId == id);
            if (allocationFromDb != null)
            {
                allocationFromDb.Count += 1;
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int id)
        {
            var allocationFromDb = _db.tblAllocations.FirstOrDefault(u => u.AllocationId == id);
            if (allocationFromDb != null)
            {
                if (allocationFromDb.Count <= 1)
                {
                    _db.tblAllocations.Remove(allocationFromDb);
                }
                else
                {
                    allocationFromDb.Count -= 1;
                }
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int id)
        {
            var allocationFromDb = _db.tblAllocations.FirstOrDefault(u => u.AllocationId == id);
            if (allocationFromDb != null)
            {
                _db.tblAllocations.Remove(allocationFromDb);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}