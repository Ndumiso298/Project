using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
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
                    AllocationList = _db.tblAllocation
                    .Include(a => a.Fridge)
                    .Where(a => a.ApplicationUserId == userId)
                    .ToList(),
                     RequestHeader = new()
            };
            foreach (var allocation in AllocationVM.AllocationList)
            {
               allocation.Price=GetPriceBasedOnQuantity(allocation);
               AllocationVM.RequestHeader.RequestTotal += (allocation.Price * allocation.Count);
            }
            return View(AllocationVM);          
        }
        public IActionResult Summary()
        {
            var claimsIdedity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdedity.FindFirst(ClaimTypes.NameIdentifier).Value;

            AllocationVM = new()
            {
                AllocationList = _db.tblAllocation
                    .Include(a => a.Fridge)
                    .Where(a => a.ApplicationUserId == userId)
                    .ToList(),
                RequestHeader = new()
            };
            AllocationVM.RequestHeader.ApplicationUser = _db.AppUser.FirstOrDefault(u => u.Id == userId);



            AllocationVM.RequestHeader.FirstName = AllocationVM.RequestHeader.ApplicationUser.FirstName;
            AllocationVM.RequestHeader.LastName = AllocationVM.RequestHeader.ApplicationUser.LastName;
            AllocationVM.RequestHeader.StreetAddress = AllocationVM.RequestHeader.ApplicationUser.StreetAddress;
            AllocationVM.RequestHeader.City = AllocationVM.RequestHeader.ApplicationUser.City;
            AllocationVM.RequestHeader.State = AllocationVM.RequestHeader.ApplicationUser.State;
            AllocationVM.RequestHeader.PostalCode = AllocationVM.RequestHeader.ApplicationUser.PostalCode;

            foreach (var allocation in AllocationVM.AllocationList)
            {
                allocation.Price = GetPriceBasedOnQuantity(allocation);
                AllocationVM.RequestHeader.RequestTotal += (allocation.Price * allocation.Count);
            }
            return View(AllocationVM);
        }


        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPost()
        {
            var claimsIdedity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdedity.FindFirst(ClaimTypes.NameIdentifier).Value;

            AllocationVM.AllocationList = _db.tblAllocation
                     .Include(a => a.Fridge)
                     .Where(a => a.ApplicationUserId == userId)
                     .ToList();

            AllocationVM.RequestHeader.RequestDate = System.DateTime.Now;
            AllocationVM.RequestHeader.ApplicationUserId = userId;

            ApplicationUser applicationUser = _db.AppUser.FirstOrDefault(u => u.Id == userId);



            foreach (var allocation in AllocationVM.AllocationList)
            {
                allocation.Price = GetPriceBasedOnQuantity(allocation);
                AllocationVM.RequestHeader.RequestTotal += (allocation.Price * allocation.Count);
            }

           
            _db.tblRequestHeader.Add(AllocationVM.RequestHeader);
            _db.SaveChanges();

            foreach (var allocation in AllocationVM.AllocationList)
            {
                RequestDetails requestDetail = new()
                {
                    FridgeId = allocation.FridgeId,
                    RequestHeaderId = AllocationVM.RequestHeader.RequestHeaderId,
                    Price = allocation.Price,
                    Count = allocation.Count,
                };
                _db.tblRequestDetail.Add(requestDetail);
                _db.SaveChanges();

            }
            return RedirectToAction(nameof(Confirmation));
        }


        public IActionResult Confirmation(int id)
        {
            return View(id);
        }
        private double GetPriceBasedOnQuantity(Allocation Allocation)
        {
            
            
                return Allocation.Fridge.RentalPricePerMonth;
            
        }
        public IActionResult Plus(int id)
        {
            var allocationFromDb = _db.tblAllocation.FirstOrDefault(u => u.AllocationId == id);
            allocationFromDb.Count += 1;
            _db.tblAllocation.Update(allocationFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Minus(int id)
        {
            var allocationFromDb = _db.tblAllocation.FirstOrDefault(u => u.AllocationId == id);
            if (allocationFromDb.Count >= 0)
            {
                _db.tblAllocation.Remove(allocationFromDb);
            }
            else
            {
                allocationFromDb.Count -= 1;
                _db.tblAllocation.Update(allocationFromDb);
            }


            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int id)
        {
            var allocationFromDb = _db.tblAllocation.FirstOrDefault(u => u.AllocationId == id);

            _db.tblAllocation.Remove(allocationFromDb);



            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
