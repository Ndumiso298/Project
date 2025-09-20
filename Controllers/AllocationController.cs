using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;
using Project.Utilities;
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
            var claimsIdentity=(ClaimsIdentity)User.Identity;
            var userId= claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            AllocationVM = new()
            {
                    AllocationList = _db.FridgeAllocations
                    .Include(a => a.Fridge)
                    .Where(a => a.Customer.UserId==userId)
                    .ToList(),
                     RequestHeader = new()
            };
            foreach (var allocation in AllocationVM.AllocationList)
            {
               allocation.Price=GetPriceBasedOnQuantity(allocation);
               AllocationVM.RequestHeader.RequestTotal += (allocation.Price * allocation.Quantity);
            }
            return View(AllocationVM);          
        }
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            // Get the customer with their related UserAccount
            var customer = _db.Customers
                .Include(c => c.UserAccount)  // Important: Include the UserAccount
                .FirstOrDefault(u => u.UserId == userId);

            if (customer == null)
            {
                // Handle the case where customer is not found
                return NotFound();
            }


            AllocationVM = new()
            {
                AllocationList = _db.FridgeAllocations
                    .Include(a => a.Fridge)
                    .Where(a => a.Customer.UserId == userId)
                    .ToList(),
                RequestHeader = new()
            };

            AllocationVM.RequestHeader.Customer = customer;
            AllocationVM.RequestHeader.CustomerId = customer.Id;

            // Get properties from UserAccount instead of Customer
            AllocationVM.RequestHeader.FirstName = customer.UserAccount?.FirstName ?? "";
            AllocationVM.RequestHeader.LastName = customer.UserAccount?.LastName ?? "";

            // Use Customer's address properties (not UserAccount's)
            AllocationVM.RequestHeader.AddressLine1 = customer.AddressLine1;
            AllocationVM.RequestHeader.AddressLine2 = customer.AddressLine2;
            AllocationVM.RequestHeader.City = customer.City;
            AllocationVM.RequestHeader.Province = customer.Province;
            AllocationVM.RequestHeader.PostalCode = customer.PostalCode;

            // Use BusinessPhoneNumber from Customer
            AllocationVM.RequestHeader.CellNumber = customer.BusinessPhoneNumber;


            foreach (var allocation in AllocationVM.AllocationList)
            {
                allocation.Price = GetPriceBasedOnQuantity(allocation);
                AllocationVM.RequestHeader.RequestTotal += (allocation.Price * allocation.Quantity);
            }
            return View(AllocationVM);
        }


        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPost()
        {
            var claimsIdedity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdedity.FindFirst(ClaimTypes.NameIdentifier).Value;

            AllocationVM.AllocationList = _db.FridgeAllocations
                     .Include(a => a.Fridge)
                     .Where(a => a.Customer.UserId == userId)
                     .ToList();

            AllocationVM.RequestHeader.RequestDate = System.DateTime.Now;
            AllocationVM.RequestHeader.Customer.UserId = userId;

            ApplicationUser applicationUser = _db.ApplicationUsers.FirstOrDefault(u => u.Id == userId);



            foreach (var allocation in AllocationVM.AllocationList)
            {
                allocation.Price = GetPriceBasedOnQuantity(allocation);
                AllocationVM.RequestHeader.RequestTotal += (allocation.Price * allocation.Quantity);
            }

           
            _db.RequestHeaders.Add(AllocationVM.RequestHeader);
            _db.SaveChanges();

            foreach (var allocation in AllocationVM.AllocationList)
            {
                RequestDetail requestDetail = new()
                {
                    FridgeId = allocation.FridgeId,
                    RequestHeaderId = AllocationVM.RequestHeader.Id,
                    Price = allocation.Price,
                    Count = allocation.Quantity,
                };
                _db.RequestDetails.Add(requestDetail);
                _db.SaveChanges();

            }
            return RedirectToAction(nameof(Confirmation));
        }


        public IActionResult Confirmation(int id)
        {
            return View(id);
        }
        private decimal GetPriceBasedOnQuantity(FridgeAllocation Allocation)
        {
            
            
                return Allocation.Fridge.RentalPricePerMonth;
            
        }
        public IActionResult Plus(int id)
        {
            var allocationFromDb = _db.FridgeAllocations.FirstOrDefault(u => u.Id == id);
            allocationFromDb.Quantity += 1;
            _db.FridgeAllocations.Update(allocationFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Minus(int id)
        {
            var allocationFromDb = _db.FridgeAllocations.FirstOrDefault(u => u.Id == id);
            if (allocationFromDb.Quantity >= 0)
            {
                _db.FridgeAllocations.Remove(allocationFromDb);
            }
            else
            {
                allocationFromDb.Quantity -= 1;
                _db.FridgeAllocations.Update(allocationFromDb);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int id)
        {
            var allocationFromDb = _db.FridgeAllocations.FirstOrDefault(u => u.Id == id);

            _db.FridgeAllocations.Remove(allocationFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
