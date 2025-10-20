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
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Fridge> fridgesList = _db.tblFridges.ToList();
            return View(fridgesList);
        }
        public IActionResult Details(int id)
        {
            Allocation allocation = new()
            {
                Fridge = _db.tblFridges.FirstOrDefault(u => u.FridgeId == id),
                Count = 1,
                FridgeId = id
            };
            return View(allocation);

        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(Allocation allocation)
        {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

               
                Allocation allocationFromDb = _db.tblAllocations
                    .Include(a => a.Customer) 
                    .FirstOrDefault(u => u.Customer.ApplicationUserId == userId && u.FridgeId == allocation.FridgeId);

                if (allocationFromDb != null)
                {
                   
                    allocationFromDb.Count += allocation.Count;
                }
                else
                {
    
                    var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);
                    if (customer != null)
                    {
                        allocation.CustomerID = customer.CustomerID; 
                    }
                    _db.tblAllocations.Add(allocation);
                }

                TempData[SD.Success] = "cart updated successfully";
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            
        }
    }
}
