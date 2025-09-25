using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Utilities;
using Project.Utilities.Enums;

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

        public async Task<IActionResult> Upsert(int? id)
        {
            Fridge fridge = new Fridge();

            if (id == null || id == 0)
            {
                // Create new - set default values
                fridge.LastMaintenanceDate = DateTime.UtcNow;
                fridge.ServiceIntervalMonths = 6;
                fridge.Condition = FridgeCondition.New;
                fridge.Status = FridgeStatus.Available;
                ViewBag.Title = "Add New Fridge";
            }
            else
            {
                // Update existing
                fridge = await _db.Fridges
                    .Include(f => f.CurrentLocation)
                    .FirstOrDefaultAsync(f => f.Id == id);

                if (fridge == null)
                {
                    return NotFound();
                }
                ViewBag.Title = "Edit Fridge";
            }

            await PopulateDropdowns();
            return View(fridge);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Fridge fridge, IFormFile file)
        {
            // Validate service interval
            if (fridge.ServiceIntervalMonths < 1 || fridge.ServiceIntervalMonths > 24)
            {
                ModelState.AddModelError("ServiceIntervalMonths", "Service interval must be between 1 and 24 months.");
            }

            // Validate capacity
            if (fridge.CapacityLiters < 1 || fridge.CapacityLiters > 1000)
            {
                ModelState.AddModelError("CapacityLiters", "Capacity must be between 1 and 1000 liters.");
            }

            if (ModelState.IsValid)
            {
                // Handle image upload
                if (file != null && file.Length > 0)
                {
                    try
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Fridges");

                        // Create directory if it doesn't exist
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Generate unique filename
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        fridge.ImageUrl = "/Images/Fridges/" + uniqueFileName;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Error uploading image: " + ex.Message);
                        await PopulateDropdowns();
                        return View(fridge);
                    }
                }

                // Calculate next service due date
                if (fridge.LastServiceDate.HasValue && fridge.ServiceIntervalMonths > 0)
                {
                    fridge.NextServiceDue = fridge.LastServiceDate.Value.AddMonths(fridge.ServiceIntervalMonths);
                }

                if (fridge.Id == 0)
                {
                    // Create new
                    fridge.CreatedDate = DateTime.UtcNow;
                    fridge.ModifiedDate = DateTime.UtcNow;
                    fridge.IsActive = true;

                    _db.Fridges.Add(fridge);
                    TempData["success"] = "Fridge created successfully!";
                }
                else
                {
                    // Update existing - preserve existing image if no new one uploaded
                    var existingFridge = await _db.Fridges.AsNoTracking()
                        .FirstOrDefaultAsync(f => f.Id == fridge.Id);

                    if (existingFridge != null)
                    {
                        // Keep existing image if no new file uploaded
                        if (file == null && !string.IsNullOrEmpty(existingFridge.ImageUrl))
                        {
                            fridge.ImageUrl = existingFridge.ImageUrl;
                        }

                        fridge.CreatedDate = existingFridge.CreatedDate;
                        fridge.ModifiedDate = DateTime.UtcNow;
                    }

                    _db.Fridges.Update(fridge);
                    TempData["success"] = "Fridge updated successfully!";
                }

                try
                {
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Error saving fridge: " + ex.Message);
                    await PopulateDropdowns();
                    return View(fridge);
                }
            }

            // If we got this far, something failed; redisplay form
            await PopulateDropdowns();
            return View(fridge);
        }

        private async Task PopulateDropdowns()
        {
            ViewBag.LocationList = await _db.Locations
                .Where(l => l.IsActive)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = $"{l.Name} - {l.City} - {l.Suburb} - {l.Province}"
                })
                .OrderBy(l => l.Text)
                .ToListAsync();

            // Add enum lists for dropdowns
            ViewBag.FridgeConditionList = Enum.GetValues(typeof(FridgeCondition))
                .Cast<FridgeCondition>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                })
                .ToList();

            ViewBag.FridgeStatusList = Enum.GetValues(typeof(FridgeStatus))
                .Cast<FridgeStatus>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                })
                .ToList();
        }

        // Additional helper methods

        [HttpPost]
        public async Task<JsonResult> CheckSerialNumber(string serialNumber, int id = 0)
        {
            // Check if serial number already exists (excluding current fridge)
            var exists = await _db.Fridges
                .AnyAsync(f => f.SerialNumber == serialNumber && f.Id != id && f.IsActive);

            return Json(new { exists = exists, message = exists ? "Serial number already exists!" : "Serial number available." });
        }

        public async Task<IActionResult> ValidateSerialNumber(string serialNumber, int id = 0)
        {
            var exists = await _db.Fridges
                .AnyAsync(f => f.SerialNumber == serialNumber && f.Id != id && f.IsActive);

            return Json(!exists);
        }
    }
}

