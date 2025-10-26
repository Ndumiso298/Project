using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Authorize(Roles = SD.FaultTechnician)]
    public class FaultTechnicianController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FaultTechnicianController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        // DASHBOARD
        public IActionResult Dashboard()
        {
            try
            {
                var maintenanceFaults = _db.tblFridgeVisits
                    .Count(v => v.CheckupStatus.ToLower() == "failed");

                var customerFaults = _db.tblFaultReports
                    .Count(fr => fr.Status != "Resolved");

                var totalFaults = maintenanceFaults + customerFaults;

                var inProgress = _db.tblFaultTechnicians
                    .Count(ft => ft.RepairStatus == "In Progress");

                var completed = _db.tblFaultTechnicians
                    .Count(ft => ft.RepairStatus == "Completed" || ft.RepairStatus == "Resolved");

                var recentActivities = _db.tblFaultTechnicians
                    .Include(ft => ft.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                    .Include(ft => ft.FaultReport)
                    .ThenInclude(fr => fr.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                    .OrderByDescending(ft => ft.Bookingate)
                    .Take(5)
                    .Select(ft => new
                    {
                        Type = GetActivityType(ft.RepairStatus),
                        Source = ft.FridgeVisit != null ? "Maintenance" : "Customer Report",
                        FridgeModel = ft.FridgeVisit != null ?
                            (ft.FridgeVisit.RequestHeader.RequestFridges.FirstOrDefault().Fridge.Model ?? "Unknown") :
                            (ft.FaultReport.FridgeInStock.Fridge.Model ?? "Unknown"),
                        CustomerName = ft.FridgeVisit != null ?
                            $"{ft.FridgeVisit.RequestHeader.FirstName} {ft.FridgeVisit.RequestHeader.LastName}" :
                            ft.FaultReport.Customer.ApplicationUser.UserName,
                        TimeAgo = ft.Bookingate
                    })
                    .ToList();

                var currentDate = DateTime.Now.Date;
                var todaysBookings = _db.tblFaultTechnicians
                    .Count(ft => ft.Bookingate.HasValue && ft.Bookingate.Value.Date == currentDate);

                var upcomingBookings = _db.tblFaultTechnicians
                    .Count(ft => ft.Bookingate.HasValue && ft.Bookingate.Value.Date > currentDate);

                ViewBag.TotalFaults = totalFaults;
                ViewBag.MaintenanceFaults = maintenanceFaults;
                ViewBag.CustomerFaults = customerFaults;
                ViewBag.InProgress = inProgress;
                ViewBag.Completed = completed;
                ViewBag.TodaysBookings = todaysBookings;
                ViewBag.UpcomingBookings = upcomingBookings;
                ViewBag.RecentActivities = recentActivities;

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading dashboard: {ex.Message}");
                ViewBag.TotalFaults = 0;
                ViewBag.MaintenanceFaults = 0;
                ViewBag.CustomerFaults = 0;
                ViewBag.InProgress = 0;
                ViewBag.Completed = 0;
                ViewBag.TodaysBookings = 0;
                ViewBag.UpcomingBookings = 0;
                ViewBag.RecentActivities = new List<object>();
                return View();
            }
        }

        // VIEW MAINTENANCE FAULTS
        public IActionResult ViewMaintenanceFaults()
        {
            var maintenanceFaults = _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .Include(v => v.FaultReports)
                .Where(v => v.CheckupStatus.ToLower() == "failed")
                .AsEnumerable()
                .Select(v => new MaintenanceFaultVM
                {
                    VisitId = v.VisitId,
                    CustomerName = v.RequestHeader != null ?
                        $"{v.RequestHeader.FirstName} {v.RequestHeader.LastName}" : "Unknown",
                    FridgeModel = v.RequestHeader != null && v.RequestHeader.RequestFridges.Any()
                        ? v.RequestHeader.RequestFridges.First().Fridge.Model
                        : "Unknown",
                    Description = v.Notes ?? "Maintenance check failed",
                    VisitDate = v.VisitDate,
                    Status = "Failed Checkup",
                    Priority = "Medium",
                    HasReportedFault = v.FaultReports.Any(fr => fr.ReportedBy == "Maintenance"),
                    Notes = v.Notes
                })
                .ToList();

            ViewBag.Source = "Maintenance";
            return View("FaultsBySource", maintenanceFaults);
        }

        // REPORT FAULT FROM VISIT - GET
        public async Task<IActionResult> ReportFaultFromVisit(int visitId)
        {
            var visit = await _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .FirstOrDefaultAsync(v => v.VisitId == visitId);

            if (visit == null || visit.CheckupStatus?.ToLower() != "failed")
            {
                TempData[SD.Error] = "Visit not found or status is not 'Failed'.";
                return RedirectToAction(nameof(ViewMaintenanceFaults));
            }

            // Get customer's allocated fridges
            var customerFridges = await _db.tblCustomerFridge
                .Where(cf => cf.CustomerID == visit.RequestHeader.CustomerID)
                .Include(cf => cf.FridgeInStock)
                .ThenInclude(fis => fis.Fridge)
                .ToListAsync();

            var viewModel = new MaintenanceFaultReportVM
            {
                VisitId = visitId,
                AvailableFridges = customerFridges,
                CustomerName = $"{visit.RequestHeader.FirstName} {visit.RequestHeader.LastName}",
                TechnicianName = User.Identity?.Name ?? "Technician",
                Visit = visit
            };

            return View(viewModel);
        }

        // REPORT FAULT FROM VISIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReportFaultFromVisit(MaintenanceFaultReportVM faultReportVM)
        {
            var visit = await _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .FirstOrDefaultAsync(v => v.VisitId == faultReportVM.VisitId);

            if (visit == null || visit.CheckupStatus?.ToLower() != "failed")
            {
                TempData[SD.Error] = "Visit not found or status is not 'Failed'.";
                return RedirectToAction(nameof(ViewMaintenanceFaults));
            }

            if (!ModelState.IsValid)
            {
                await ReloadMaintenanceFaultVM(faultReportVM, visit.RequestHeader.CustomerID);
                return View(faultReportVM);
            }

            try
            {
                // Verify fridge allocation
                var allocated = await _db.tblCustomerFridge
                    .AnyAsync(cf => cf.CustomerID == visit.RequestHeader.CustomerID &&
                                   cf.FridgeInStockId == faultReportVM.FridgeInStockId);

                if (!allocated)
                {
                    TempData[SD.Error] = "Fridge is not allocated to this customer.";
                    await ReloadMaintenanceFaultVM(faultReportVM, visit.RequestHeader.CustomerID);
                    return View(faultReportVM);
                }

                // Handle image upload
                string? imageUrl = null;
                if (faultReportVM.FaultImages != null && faultReportVM.FaultImages.Count > 0)
                {
                    imageUrl = await SaveFaultImages(faultReportVM.FaultImages);
                }

                // Create the fault report entity
                var faultReport = new FaultReport
                {
                    CustomerId = visit.RequestHeader.CustomerID,
                    FridgeInStockId = faultReportVM.FridgeInStockId,
                    FaultType = faultReportVM.FaultType,
                    Description = faultReportVM.Description,
                    ReportedDate = DateTime.Now,
                    Status = "Reported",
                    Priority = faultReportVM.Priority,
                    ImageUrl = imageUrl,
                    RequestReplacement = faultReportVM.RequestReplacement,
                    DeclineReason = null,
                    ReportedBy = "Maintenance",
                    VisitId = faultReportVM.VisitId
                };

                _db.tblFaultReports.Add(faultReport);
                await _db.SaveChangesAsync();

                // Create FaultTechnician record
                var faultTechnician = new FaultTechnician
                {
                    FaultDescription = $"{faultReportVM.FaultType}: {faultReportVM.Description}",
                    FaultReportId = faultReport.FaultReportId,
                    CustomerBookingStatus = "Pending",
                    Priority = faultReportVM.Priority,
                    TechnicianAssigned = User.Identity?.Name ?? "Technician",
                    Bookingate = DateTime.Now.AddDays(1),
                    RepairStatus = "Not Started"
                };
                _db.tblFaultTechnicians.Add(faultTechnician);

                await _db.SaveChangesAsync();

                TempData[SD.Success] = "Fault reported successfully on behalf of customer!";
                return RedirectToAction(nameof(ViewMaintenanceFaults));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reporting fault from visit: {ex.Message}");
                TempData[SD.Error] = "Error reporting fault. Please try again.";
                await ReloadMaintenanceFaultVM(faultReportVM, visit.RequestHeader.CustomerID);
                return View(faultReportVM);
            }
        }

        // VIEW CUSTOMER FAULTS
        public IActionResult ViewCustomerFaults()
        {
            var customerFaults = _db.tblFaultReports
                .Include(fr => fr.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(fr => fr.FridgeInStock)
                .ThenInclude(fis => fis.Fridge)
                .Where(fr => fr.Status != "Resolved")
                .Select(fr => new CustomerFaultVM
                {
                    FaultReportId = fr.FaultReportId,
                    CustomerName = fr.Customer != null && fr.Customer.ApplicationUser != null
                        ? fr.Customer.ApplicationUser.UserName
                        : "Unknown",
                    FridgeModel = fr.FridgeInStock != null && fr.FridgeInStock.Fridge != null
                        ? fr.FridgeInStock.Fridge.Model
                        : "Unknown",
                    Description = fr.Description,
                    ReportedDate = fr.ReportedDate,
                    Status = fr.Status,
                    Priority = fr.Priority,
                    FaultType = fr.FaultType
                })
                .ToList();

            ViewBag.Source = "Customer Reports";
            return View("FaultsBySource", customerFaults);
        }

        // BOOK MAINTENANCE FAULT
        public IActionResult BookMaintenanceFault(int visitId)
        {
            var fridgeVisit = _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .FirstOrDefault(v => v.VisitId == visitId && v.CheckupStatus.ToLower() == "failed");

            if (fridgeVisit == null)
            {
                return NotFound();
            }

            var existingAssignment = _db.tblFaultTechnicians
                .FirstOrDefault(ft => ft.VisitId == visitId);

            FaultTechnician faultTechnician;
            if (existingAssignment != null)
            {
                faultTechnician = existingAssignment;
                faultTechnician.FridgeVisit = fridgeVisit;
            }
            else
            {
                faultTechnician = new FaultTechnician
                {
                    VisitId = visitId,
                    FridgeVisit = fridgeVisit,
                    Bookingate = GetNextAvailableBookingDate(),
                    FaultDescription = fridgeVisit.Notes ?? string.Empty,
                    RepairStatus = "Not Started",
                    Priority = "Medium"
                };
            }

            ViewBag.Source = "Maintenance";
            ViewBag.RepairStatusList = GetRepairStatusList();
            return View("BookFault", faultTechnician);
        }

        // BOOK CUSTOMER FAULT
        public IActionResult BookCustomerFault(int faultReportId)
        {
            var faultReport = _db.tblFaultReports
                .Include(fr => fr.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(fr => fr.FridgeInStock)
                .ThenInclude(fis => fis.Fridge)
                .FirstOrDefault(fr => fr.FaultReportId == faultReportId);

            if (faultReport == null)
            {
                return NotFound();
            }

            var existingAssignment = _db.tblFaultTechnicians
                .FirstOrDefault(ft => ft.FaultReportId == faultReportId);

            FaultTechnician faultTechnician;
            if (existingAssignment != null)
            {
                faultTechnician = existingAssignment;
                faultTechnician.FaultReport = faultReport;
            }
            else
            {
                faultTechnician = new FaultTechnician
                {
                    FaultReportId = faultReportId,
                    FaultReport = faultReport,
                    Bookingate = GetNextAvailableBookingDate(),
                    FaultDescription = faultReport.Description,
                    RepairStatus = "Not Started",
                    Priority = faultReport.Priority ?? "Medium"
                };
            }

            ViewBag.Source = "Customer Report";
            ViewBag.RepairStatusList = GetRepairStatusList();
            return View("BookFault", faultTechnician);
        }

        // BOOK FAULT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookFault(FaultTechnician fault)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (fault.FaultId == 0)
                    {
                        _db.tblFaultTechnicians.Add(fault);
                    }
                    else
                    {
                        _db.tblFaultTechnicians.Update(fault);
                    }

                    _db.SaveChanges();
                    TempData[SD.Success] = "Fault booking saved successfully!";
                    return RedirectToAction(nameof(ViewFaults));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error saving fault booking: {ex.Message}");
                }
            }

            if (fault.VisitId.HasValue)
            {
                fault.FridgeVisit = _db.tblFridgeVisits
                    .Include(v => v.RequestHeader)
                    .ThenInclude(rh => rh.RequestFridges)
                    .ThenInclude(rf => rf.Fridge)
                    .FirstOrDefault(v => v.VisitId == fault.VisitId);
                ViewBag.Source = "Maintenance";
            }
            else if (fault.FaultReportId.HasValue)
            {
                fault.FaultReport = _db.tblFaultReports
                    .Include(fr => fr.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                    .Include(fr => fr.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                    .FirstOrDefault(fr => fr.FaultReportId == fault.FaultReportId);
                ViewBag.Source = "Customer Report";
            }

            ViewBag.RepairStatusList = GetRepairStatusList();
            return View("BookFault", fault);
        }

        // VIEW ALL FAULTS
        public IActionResult ViewFaults()
        {
            var faults = _db.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(ft => ft.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .Include(ft => ft.FaultReport)
                .ThenInclude(fr => fr.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(ft => ft.FaultReport)
                .ThenInclude(fr => fr.FridgeInStock)
                .ThenInclude(fis => fis.Fridge)
                .OrderByDescending(ft => ft.Bookingate)
                .ToList();

            return View(faults);
        }

        // PROCESS FAULT - GET
        public IActionResult ProcessFault(int id)
        {
            var fault = _db.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(ft => ft.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .Include(ft => ft.FaultReport)
                .ThenInclude(fr => fr.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(ft => ft.FaultReport)
                .ThenInclude(fr => fr.FridgeInStock)
                .ThenInclude(fis => fis.Fridge)
                .FirstOrDefault(ft => ft.FaultId == id);

            if (fault == null)
            {
                return NotFound();
            }

            ViewBag.RepairStatusList = GetRepairStatusList();
            return View(fault);
        }

        // PROCESS FAULT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProcessFault(FaultTechnician faultTechnician)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingFault = _db.tblFaultTechnicians.Find(faultTechnician.FaultId);
                    if (existingFault != null)
                    {
                        existingFault.RepairStatus = faultTechnician.RepairStatus;
                        existingFault.ResolutionNotes = faultTechnician.ResolutionNotes;
                        existingFault.TechnicianAssigned = faultTechnician.TechnicianAssigned;
                        existingFault.ActualRepairTime = faultTechnician.ActualRepairTime;
                        existingFault.RepairCost = faultTechnician.RepairCost;

                        if (faultTechnician.RepairStatus == "Completed" || faultTechnician.RepairStatus == "Resolved")
                        {
                            existingFault.Completion = DateTime.Now;

                            if (existingFault.VisitId.HasValue)
                            {
                                var fridgeVisit = _db.tblFridgeVisits.Find(existingFault.VisitId);
                                if (fridgeVisit != null)
                                {
                                    fridgeVisit.CheckupStatus = "Repaired";
                                }
                            }
                            else if (existingFault.FaultReportId.HasValue)
                            {
                                var faultReport = _db.tblFaultReports.Find(existingFault.FaultReportId);
                                if (faultReport != null)
                                {
                                    faultReport.Status = "Resolved";
                                    faultReport.ResolvedDate = DateTime.Now;
                                }
                            }
                        }

                        _db.SaveChanges();
                        TempData[SD.Success] = "Fault processed successfully!";
                        return RedirectToAction(nameof(ViewFaults));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Fault not found.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error processing fault: {ex.Message}");
                }
            }

            ViewBag.RepairStatusList = GetRepairStatusList();
            return View(faultTechnician);
        }

        // ========== HELPER METHODS ==========

        private async Task<string?> SaveFaultImages(List<IFormFile> faultImages)
        {
            var imageUrls = new List<string>();

            foreach (var image in faultImages)
            {
                if (image.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "faults", fileName);

                    var directory = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    imageUrls.Add($"/images/faults/{fileName}");
                }
            }

            return imageUrls.Count > 0 ? string.Join(",", imageUrls) : null;
        }

        private List<SelectListItem> GetRepairStatusList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "Not Started", Value = "Not Started" },
                new SelectListItem { Text = "In Progress", Value = "In Progress" },
                new SelectListItem { Text = "Completed", Value = "Completed" },
                new SelectListItem { Text = "Resolved", Value = "Resolved" },
                new SelectListItem { Text = "Scrapped", Value = "Scrapped" }
            };
        }

        private DateTime GetNextAvailableBookingDate()
        {
            var latestBooking = _db.tblFaultTechnicians
                .Where(ft => ft.Bookingate.HasValue)
                .OrderByDescending(ft => ft.Bookingate)
                .FirstOrDefault()?.Bookingate;

            return latestBooking?.AddDays(1) ?? DateTime.Now.AddDays(1);
        }

        private string GetActivityType(string repairStatus)
        {
            return repairStatus == "Completed" || repairStatus == "Resolved" ? "Repair completed" :
                   repairStatus == "In Progress" ? "Repair started" : "New repair assigned";
        }

        private async Task ReloadMaintenanceFaultVM(MaintenanceFaultReportVM viewModel, int customerId)
        {
            var customerFridges = await _db.tblCustomerFridge
                .Where(cf => cf.CustomerID == customerId)
                .Include(cf => cf.FridgeInStock)
                .ThenInclude(fis => fis.Fridge)
                .ToListAsync();

            viewModel.AvailableFridges = customerFridges;

            var visit = await _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .FirstOrDefaultAsync(v => v.VisitId == viewModel.VisitId);

            viewModel.Visit = visit;
            viewModel.CustomerName = $"{visit?.RequestHeader?.FirstName} {visit?.RequestHeader?.LastName}";
        }
    }
}