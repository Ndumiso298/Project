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
            //AllocationVM = new()
            //{
            //     FridgeList= _db.tblAllocation.Include(a => a.Fridge).Where(a => a.ApplicationUserId == userId).ToList()
                
            //};


            return View();
        }
            return View(AllocationVM);
        }

        public IActionResult Upsert(int? id)
        {
            AllocationVM  = new()
            {
                allocation.Price = GetPriceBasedOnQuantity(allocation);
                AllocationVM.RequestHeader.RequestTotal += (allocation.Price * allocation.Count);
            }
               

            _db.tblRequestHeader.Add(AllocationVM.RequestHeader);
            _db.SaveChanges();

                UserList = _db.AppUser.Select(u => new SelectListItem
                {
                    Text = u.FirstName + " " + u.LastName,
                    Value = u.Id.ToString()
                }),
                Allocation = new Allocation()
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
            

          return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(AllocationVM allocationVM)
        {
            if (ModelState.IsValid)
            {
                var allocation = allocationVM.Allocation;

                if (allocationVM.Allocation.AllocationId == 0)
                {
                    _db.tblAllocation.Add(allocationVM.Allocation);
                }
                else
                {
                    _db.tblAllocation.Update(allocationVM.Allocation);
                }


                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        public IActionResult Remove(int id)
        {
            var allocationFromDb = _db.tblAllocation.FirstOrDefault(u => u.AllocationId == id);

            _db.tblAllocation.Remove(allocationFromDb);

            // If model state is invalid, re-populate dropdowns for the view model
            allocationVM.FridgeList = _db.tblFridge.Select(u => new SelectListItem
            {
                Text = u.FridgeNo + " (" + u.Brand + " " + u.Type + ")",
                Value = u.FridgeId.ToString()
            }).ToList();

            allocationVM.UserList = _db.AppUser.Select(u => new SelectListItem
            {
                Text = u.FirstName + " " + u.LastName,
                Value = u.Id.ToString()
            }).ToList();

            return View(allocationVM);
        }

    }
}
