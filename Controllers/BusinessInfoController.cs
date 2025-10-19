using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Utility;

namespace Project.Controllers
{
    public class BusinessInfoController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BusinessInfoController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var businesses = _db.tblBusinessInfo.ToList();
            return View(businesses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BusinessInfo obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.BusinessLogo != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + obj.BusinessLogo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                         obj.BusinessLogo.CopyTo(fileStream);
                    }

                    obj.LogoPath = "/uploads/" + uniqueFileName;
                }

                _db.tblBusinessInfo.Add(obj);
                _db.SaveChanges();
                TempData[SD.Success] = "Business successfully created!";
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var business =  _db.tblBusinessInfo.Find(id);
            if (business == null)
                return NotFound();

            return View(business);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BusinessInfo obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.BusinessLogo != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + obj.BusinessLogo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        obj.BusinessLogo.CopyTo(fileStream);
                    }

                    obj.LogoPath = "/uploads/" + uniqueFileName;
                }

                _db.tblBusinessInfo.Update(obj);
                _db.SaveChanges();
                TempData[SD.Success] = "Business info updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var business =  _db.tblBusinessInfo.Find(id);
            if (business == null)
                return NotFound();

            return View(business);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var business =  _db.tblBusinessInfo.Find(id);
            if (business == null)
                return NotFound();

            if (!string.IsNullOrEmpty(business.LogoPath))
            {
                var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, business.LogoPath.TrimStart('/'));
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }

            _db.tblBusinessInfo.Remove(business);
            _db.SaveChanges();
            TempData[SD.Success] = "Business deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var business = _db.tblBusinessInfo.FirstOrDefault(b => b.BusinessID == id);
            if (business == null)
                return NotFound();

            return View(business);
        }
    }
}
