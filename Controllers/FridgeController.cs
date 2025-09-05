using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Utility;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole)]
    public class FridgeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FridgeController(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            List<Fridge> fridges=_db.tblFridge.ToList();
            return View(fridges);
        }
        public IActionResult Upsert(int? id)
        {
            if(id==0||id==null)
            {
                return View(new Fridge());
            }
            else
            {

                Fridge fridgeFromDb = _db.tblFridge.FirstOrDefault(u => u.FridgeId == id);
                return View(fridgeFromDb);
            }

          
        }
        [HttpPost]
        public IActionResult Upsert(Fridge objfridge, IFormFile? file)
        {

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

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);

                        }
                        using (var fileStream = new FileStream(Path.Combine(fridgePath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        objfridge.ImageUrl = @"/Images/Fridges/" + fileName;
                    }
                }


                if (objfridge.FridgeId == 0)
                {
                    _db.tblFridge.Add(objfridge);

                }
                else
                {
                    _db.tblFridge.Update(objfridge);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(objfridge);
        }
        
        
        public IActionResult Delete(int? id)
        {
            Fridge fridgeFromDb = _db.tblFridge.FirstOrDefault(u => u.FridgeId == id);
            if (fridgeFromDb.FridgeId == null || fridgeFromDb.FridgeId == 0)
            {
                return NotFound();
            }
            return View(fridgeFromDb);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Fridge objfridge)
        {
            var oldImagePath=Path.Combine(_webHostEnvironment.WebRootPath, objfridge.ImageUrl.TrimStart('\\'));
            if(System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }


            _db.tblFridge.Remove(objfridge);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
