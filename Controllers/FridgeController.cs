using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using System.Linq;

namespace Project.Controllers
{
    public class FridgeController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public FridgeController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
        }


        public IActionResult Dashboard()
        {
            var fridgeModels = _db.tblFridges
                .Include(f => f.FridgeInstances)
                .ToList();

            var dashboard = new DashboardVM
            {
                TotalFridgeModels = fridgeModels.Count,
                TotalFridgeInstances = fridgeModels.Sum(f => f.FridgeInstances.Count),
                TotalAvailableInstances = fridgeModels.Sum(f => f.FridgeInstances.Count(i => i.IsAvailable)),
                TotalRentedInstances = fridgeModels.Sum(f => f.FridgeInstances.Count(i => !i.IsAvailable)),
                FridgeStock = fridgeModels.Select(f => new FridgeStockVM
                {
                    FridgeModel = f,
                    TotalInstances = f.FridgeInstances.Count,
                    AvailableInstances = f.FridgeInstances.Count(i => i.IsAvailable),
                    RentedInstances = f.FridgeInstances.Count(i => !i.IsAvailable),
                    FridgeInstances = f.FridgeInstances.ToList()
                }).ToList()
            };

            return View(dashboard);
        }

        public IActionResult Manage()
        {
            var fridges = _db.tblFridges
                .Include(f => f.FridgeInstances)
                .ToList();
            return View(fridges);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Fridge objfridge, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null && file.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string fridgePath = Path.Combine(wwwRootPath, @"Images/Fridges/");

                    if (!Directory.Exists(fridgePath))
                    {
                        Directory.CreateDirectory(fridgePath);
                    }

                    string fullPath = Path.Combine(fridgePath, fileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    objfridge.ImageUrl = @"/Images/Fridges/" + fileName;
                }

                _db.Add(objfridge);
                _db.SaveChanges();
                TempData["success"] = "Fridge created successfully";
                return RedirectToAction(nameof(Manage));
            }
            return View(objfridge);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)

            {
                return NotFound();
            }
            var fridge = _db.tblFridges.FirstOrDefault(u => u.FridgeId == id);
            if (fridge == null) return NotFound();

            return View(fridge);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Fridge objfridge, IFormFile? file)
        {
            if (id != objfridge.FridgeId)
            { 
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string fridgePath = Path.Combine(wwwRootPath, @"Images/Fridges/");

                    if (objfridge.FridgeId != 0 && !string.IsNullOrEmpty(objfridge.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, objfridge.ImageUrl.TrimStart('\\'));
                        //Uma sikhona 
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            //siyasisusa
                            System.IO.File.Delete(oldImagePath);

                        }
                        //sifake new one uma kade ingekho
                        using (var fileStream = new FileStream(Path.Combine(fridgePath, fileName), FileMode.Create))
                        {
                            //penda isithombe esisha
                            file.CopyTo(fileStream);
                        }
                        objfridge.ImageUrl = @"/Images/Fridges/" + fileName;
                    }


                    try
                    {
                        _db.Update(objfridge);
                        _db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FridgeExists(objfridge.FridgeId))
                            return NotFound();
                        else
                            throw;
                    }
                    return RedirectToAction(nameof(Manage));
                }
            }
            return View(objfridge);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var fridge =  _db.tblFridges
                .FirstOrDefault(m => m.FridgeId == id);
            if (fridge == null) return NotFound();

            return View(fridge);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var fridge =  _db.tblFridges.FirstOrDefault(u=>u.FridgeId==id);
            if (fridge != null)
            {
                _db.tblFridges.Remove(fridge);
            }

             _db.SaveChanges();
            return RedirectToAction(nameof(Manage));
        }

        private bool FridgeExists(int id)
        {
            return _db.tblFridges.Any(e => e.FridgeId == id);
        }
    }
}