using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Utilities;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.StockControllerRole)]
    public class FridgesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FridgesController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            List<Fridge> fridges = _db.Fridges.ToList();
            return View(fridges);
        }
        public IActionResult Upsert(int? id)
        {
            if (id == 0 || id == null)
            {
                return View(new Fridge());
            }
            else
            {

                Fridge fridgeFromDb = _db.Fridges.FirstOrDefault(u => u.Id == id);
                return View(fridgeFromDb);
            }


        }
        [HttpPost]
        public IActionResult Upsert(Fridge objfridge, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null && file.Length > 0)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    string fridgePath = Path.Combine(wwwRootPath, "Images", "FridgeAllocations");
                    Directory.CreateDirectory(fridgePath);

                    // Delete old image if updating
                    if (!string.IsNullOrEmpty(objfridge.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, objfridge.ImageUrl.TrimStart('\\', '/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(fridgePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    objfridge.ImageUrl = $"/Images/FridgeAllocations/{fileName}";
                }


                if (objfridge.Id == 0)
                {
                    _db.Fridges.Add(objfridge);

                }
                else
                {
                    _db.Fridges.Update(objfridge);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(objfridge);
        }


        public IActionResult Delete(int? id)
        {
            Fridge fridgeFromDb = _db.Fridges.FirstOrDefault(u => u.Id == id);
            if (fridgeFromDb.Id == null || fridgeFromDb.Id == 0)
            {
                return NotFound();
            }
            return View(fridgeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Fridge objfridge)
        {
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, objfridge.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }


            _db.Fridges.Remove(objfridge);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

