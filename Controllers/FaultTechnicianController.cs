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
    public class FaultTechnicianController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FaultTechnicianController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Dashboard()
        {
            try
            {
                var maintenanceFaults = _db.tblFridgeVisits
                    .Count(v => v.CheckupStatus.ToLower() == "failed");

                var customerFaults = _db.tblFaultReports
                    .Count(fr => fr.Status != "Resolved");

                var totalFaults = maintenanceFaults + customerFaults;

                var pendingMaintenanceFaults = _db.tblFridgeVisits
                    .Count(v => v.CheckupStatus.ToLower() == "failed" && !v.FaultTechnicians.Any());

                var pendingCustomerFaults = _db.tblFaultReports
                    .Count(fr => fr.Status == "Reported" && !fr.FaultTechnicians.Any());

                var pendingFaults = pendingMaintenanceFaults + pendingCustomerFaults;

                var inProgress = _db.tblFaultTechnicians
                    .Count(ft => ft.RepairStatus == "In Progress");

                var completed = _db.tblFaultTechnicians
                    .Count(ft => ft.RepairStatus == "Completed" || ft.RepairStatus == "Resolved");

                var recentMaintenanceActivities = _db.tblFaultTechnicians
                    .Include(ft => ft.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                    .ThenInclude(rh => rh.RequestFridges)
                    .ThenInclude(rf => rf.Fridge)
                    .Where(ft => ft.FridgeVisit != null)
                    .OrderByDescending(ft => ft.Bookingate)
                    .Take(5)
                    .Select(ft => new
                    {
                        Type = GetActivityType(ft.RepairStatus),
                        Source = "Maintenance",
                        FridgeModel = ft.FridgeVisit.RequestHeader != null && ft.FridgeVisit.RequestHeader.RequestFridges.Any()
                            ? ft.FridgeVisit.RequestHeader.RequestFridges.First().Fridge.Model
                            : "Unknown",
                        CustomerName = ft.FridgeVisit.RequestHeader != null
                            ? (ft.FridgeVisit.RequestHeader.FirstName ?? "") + " " + (ft.FridgeVisit.RequestHeader.LastName ?? "")
                            : "",
                        TimeAgo = ft.Bookingate
                    })
                    .ToList();

                var recentCustomerActivities = _db.tblFaultTechnicians
                    .Include(ft => ft.FaultReport)
                    .ThenInclude(fr => fr.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                    .Include(ft => ft.FaultReport)
                    .ThenInclude(fr => fr.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                    .Where(ft => ft.FaultReport != null)
                    .OrderByDescending(ft => ft.Bookingate)
                    .Take(5)
                    .Select(ft => new
                    {
                        Type = GetActivityType(ft.RepairStatus),
                        Source = "Customer Report",
                        FridgeModel = ft.FaultReport.FridgeInStock != null && ft.FaultReport.FridgeInStock.Fridge != null
                            ? ft.FaultReport.FridgeInStock.Fridge.Model
                            : "Unknown",
                        CustomerName = ft.FaultReport.Customer != null && ft.FaultReport.Customer.ApplicationUser != null
                            ? ft.FaultReport.Customer.ApplicationUser.UserName
                            : "Unknown",
                        TimeAgo = ft.Bookingate
                    })
                    .ToList();

                var recentActivities = recentMaintenanceActivities
                    .Concat(recentCustomerActivities)
                    .OrderByDescending(a => a.TimeAgo)
                    .Take(5)
                    .ToList();

                var currentDate = DateTime.Now.Date;
                var todaysBookings = _db.tblFaultTechnicians
                    .Count(ft => ft.Bookingate.HasValue && ft.Bookingate.Value.Date == currentDate);

                var upcomingBookings = _db.tblFaultTechnicians
                    .Count(ft => ft.Bookingate.HasValue && ft.Bookingate.Value.Date > currentDate);

                ViewBag.TotalFaults = totalFaults;
                ViewBag.MaintenanceFaults = maintenanceFaults;
                ViewBag.CustomerFaults = customerFaults;
                ViewBag.PendingFaults = pendingFaults;
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
                ViewBag.PendingFaults = 0;
                ViewBag.InProgress = 0;
                ViewBag.Completed = 0;
                ViewBag.TodaysBookings = 0;
                ViewBag.UpcomingBookings = 0;
                ViewBag.RecentActivities = new List<object>();
                return View();
            }
        }

        public IActionResult Index()
        {
            var maintenanceFaults = _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.Customer.ApplicationUser)
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .Where(v => v.CheckupStatus.ToLower() == "failed")
                .Select(v => new FaultViewModel
                {
                    Id = v.VisitId,
                    Source = "Maintenance",
                    CustomerName = v.RequestHeader != null ? (v.RequestHeader.FirstName ?? "") + " " + (v.RequestHeader.LastName ?? "") : "Unknown",
                    FridgeModel = v.RequestHeader != null && v.RequestHeader.RequestFridges.Any()
                        ? v.RequestHeader.RequestFridges.First().Fridge.Model
                        : "Unknown",
                    Description = v.Notes ?? "Maintenance check failed",
                    ReportedDate = v.VisitDate,
                    Status = "Failed Checkup",
                    Priority = "Medium"
                })
                .ToList();

            var customerFaults = _db.tblFaultReports
                .Include(fr => fr.Customer.ApplicationUser)
                .Include(fr => fr.FridgeInStock.Fridge)
                .Where(fr => fr.Status != "Resolved")
                .Select(fr => new FaultViewModel
                {
                    Id = fr.FaultReportId,
                    Source = "Customer Report",
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
                    FaultType = fr.FaultType,
                    AdditionalNotes = fr.AdditionalNotes
                })
                .ToList();

            var allFaults = maintenanceFaults
                .Concat(customerFaults)
                .OrderByDescending(f => f.ReportedDate)
                .ToList();

            return View(allFaults);
        }

        public IActionResult Calendar()
        {
            try
            {
                var visits = _db.tblFaultTechnicians
                    .Include(u => u.FridgeVisit)
                    .ThenInclude(u => u.RequestHeader)
                    .ThenInclude(u => u.Customer.ApplicationUser)
                    .Include(u => u.FridgeVisit)
                    .ThenInclude(u => u.RequestHeader)
                    .ThenInclude(u => u.RequestFridges)
                    .ThenInclude(u => u.Fridge)
                    .Include(u => u.FaultReport)
                    .ThenInclude(fr => fr.Customer.ApplicationUser)
                    .Include(u => u.FaultReport)
                    .ThenInclude(fr => fr.FridgeInStock.Fridge)
                    .Where(ft => ft.Bookingate.HasValue)
                    .OrderBy(ft => ft.Bookingate)
                    .ToList();

                return View(visits ?? new List<FaultTechnician>());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading calendar: {ex.Message}");
                return View(new List<FaultTechnician>());
            }
        }

        public IActionResult ViewMaintenanceFaults()
        {
            var maintenanceFaults = _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.Customer.ApplicationUser)
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .Where(v => v.CheckupStatus.ToLower() == "failed")
                .Select(v => new FaultViewModel
                {
                    Id = v.VisitId,
                    Source = "Maintenance",
                    CustomerName = v.RequestHeader != null ? (v.RequestHeader.FirstName ?? "") + " " + (v.RequestHeader.LastName ?? "") : "Unknown",
                    FridgeModel = v.RequestHeader != null && v.RequestHeader.RequestFridges.Any()
                        ? v.RequestHeader.RequestFridges.First().Fridge.Model
                        : "Unknown",
                    Description = v.Notes ?? "Maintenance check failed",
                    ReportedDate = v.VisitDate,
                    Status = "Failed Checkup",
                    Priority = "Medium"
                })
                .ToList();

            ViewBag.Source = "Maintenance";
            return View("FaultsBySource", maintenanceFaults);
        }

        public IActionResult ViewCustomerFaults()
        {
            var customerFaults = _db.tblFaultReports
                .Include(fr => fr.Customer.ApplicationUser)
                .Include(fr => fr.FridgeInStock.Fridge)
                .Where(fr => fr.Status != "Resolved")
                .Select(fr => new FaultViewModel
                {
                    Id = fr.FaultReportId,
                    Source = "Customer Report",
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
                    FaultType = fr.FaultType,
                    AdditionalNotes = fr.AdditionalNotes
                })
                .ToList();

            ViewBag.Source = "Customer Reports";
            return View("FaultsBySource", customerFaults);
        }

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

        public IActionResult BookCustomerFault(int faultReportId)
        {
            var faultReport = _db.tblFaultReports
                .Include(fr => fr.Customer.ApplicationUser)
                .Include(fr => fr.FridgeInStock.Fridge)
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
                    TempData["Success"] = "Fault booking saved successfully!";
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
                    .Include(fr => fr.Customer.ApplicationUser)
                    .Include(fr => fr.FridgeInStock.Fridge)
                    .FirstOrDefault(fr => fr.FaultReportId == fault.FaultReportId);
                ViewBag.Source = "Customer Report";
            }

            ViewBag.RepairStatusList = GetRepairStatusList();
            return View("BookFault", fault);
        }

        public IActionResult ViewFaults()
        {
            var faults = _db.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.Customer.ApplicationUser)
                .Include(ft => ft.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .Include(ft => ft.FaultReport)
                .ThenInclude(fr => fr.Customer.ApplicationUser)
                .Include(ft => ft.FaultReport)
                .ThenInclude(fr => fr.FridgeInStock.Fridge)
                .OrderByDescending(ft => ft.Bookingate)
                .ToList();

            return View(faults);
        }

        public IActionResult ProcessFault(int id)
        {
            var fault = _db.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.Customer.ApplicationUser)
                .Include(ft => ft.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .Include(ft => ft.FaultReport)
                .ThenInclude(fr => fr.Customer.ApplicationUser)
                .Include(ft => ft.FaultReport)
                .ThenInclude(fr => fr.FridgeInStock.Fridge)
                .FirstOrDefault(ft => ft.FaultId == id);

            if (fault == null)
            {
                return NotFound();
            }

            ViewBag.RepairStatusList = GetRepairStatusList();
            return View(fault);
        }

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
                        TempData["Success"] = "Fault processed successfully!";
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

            var fault = _db.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.Customer.ApplicationUser)
                .Include(ft => ft.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .Include(ft => ft.FaultReport)
                .ThenInclude(fr => fr.Customer.ApplicationUser)
                .Include(ft => ft.FaultReport)
                .ThenInclude(fr => fr.FridgeInStock.Fridge)
                .FirstOrDefault(ft => ft.FaultId == faultTechnician.FaultId);

            if (fault != null)
            {
                faultTechnician.FridgeVisit = fault.FridgeVisit;
                faultTechnician.FaultReport = fault.FaultReport;
            }

            ViewBag.RepairStatusList = GetRepairStatusList();
            return View(faultTechnician);
        }

        public IActionResult FaultDetails(int id, string source)
        {
            if (source == "maintenance")
            {
                var fault = _db.tblFridgeVisits
                    .Include(v => v.RequestHeader)
                    .ThenInclude(rh => rh.Customer.ApplicationUser)
                    .Include(v => v.RequestHeader)
                    .ThenInclude(rh => rh.RequestFridges)
                    .ThenInclude(rf => rf.Fridge)
                    .FirstOrDefault(v => v.VisitId == id);

                if (fault == null)
                {
                    return NotFound();
                }

                return View("MaintenanceFaultDetails", fault);
            }
            else if (source == "customer")
            {
                var fault = _db.tblFaultReports
                    .Include(fr => fr.Customer.ApplicationUser)
                    .Include(fr => fr.FridgeInStock.Fridge)
                    .FirstOrDefault(fr => fr.FaultReportId == id);

                if (fault == null)
                {
                    return NotFound();
                }

                return View("CustomerFaultDetails", fault);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateFaultStatus(int id, string status)
        {
            try
            {
                var faultTechnician = _db.tblFaultTechnicians.Find(id);
                if (faultTechnician != null)
                {
                    faultTechnician.RepairStatus = status;

                    if (status == "Completed" || status == "Resolved")
                    {
                        faultTechnician.Completion = DateTime.Now;
                    }

                    _db.SaveChanges();
                    TempData["Success"] = $"Fault status updated to {status}";
                }
                else
                {
                    TempData["Error"] = "Fault not found";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error updating status: {ex.Message}";
            }

            return RedirectToAction(nameof(ViewFaults));
        }

        public IActionResult DeleteFaultAssignment(int id)
        {
            var fault = _db.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                .Include(ft => ft.FaultReport)
                .FirstOrDefault(ft => ft.FaultId == id);

            if (fault == null)
            {
                return NotFound();
            }

            return View(fault);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFaultAssignmentConfirmed(int id)
        {
            try
            {
                var fault = _db.tblFaultTechnicians.Find(id);
                if (fault != null)
                {
                    _db.tblFaultTechnicians.Remove(fault);
                    _db.SaveChanges();
                    TempData["Success"] = "Fault assignment deleted successfully!";
                }
                else
                {
                    TempData["Error"] = "Fault assignment not found";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error deleting fault assignment: {ex.Message}";
            }

            return RedirectToAction(nameof(ViewFaults));
        }

        [HttpGet]
        public IActionResult GetFaultStatistics()
        {
            var maintenanceFaults = _db.tblFridgeVisits.Count(v => v.CheckupStatus.ToLower() == "failed");
            var customerFaults = _db.tblFaultReports.Count(fr => fr.Status != "Resolved");
            var inProgress = _db.tblFaultTechnicians.Count(ft => ft.RepairStatus == "In Progress");
            var completed = _db.tblFaultTechnicians.Count(ft => ft.RepairStatus == "Completed" || ft.RepairStatus == "Resolved");

            var statistics = new
            {
                MaintenanceFaults = maintenanceFaults,
                CustomerFaults = customerFaults,
                InProgress = inProgress,
                Completed = completed,
                TotalFaults = maintenanceFaults + customerFaults
            };

            return Json(statistics);
        }

        public IActionResult RepairFridge(int faultReportId)
        {
            var faultReport = _db.tblFaultReports
                .Include(fr => fr.FridgeInStock)
                .ThenInclude(fis => fis.Fridge)
                .FirstOrDefault(fr => fr.FaultReportId == faultReportId);

            if (faultReport == null)
            {
                return NotFound();
            }

            ViewBag.FaultReport = faultReport;
            ViewBag.RepairStatusList = GetRepairStatusList();
            return View(new FaultTechnician { FaultReportId = faultReportId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RepairFridge(FaultTechnician faultTechnician)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingFault = _db.tblFaultTechnicians
                        .FirstOrDefault(ft => ft.FaultReportId == faultTechnician.FaultReportId);

                    if (existingFault != null)
                    {
                        existingFault.TechnicianAssigned = faultTechnician.TechnicianAssigned;
                        existingFault.FaultDescription = faultTechnician.FaultDescription;
                        existingFault.EstimatedRepairTime = faultTechnician.EstimatedRepairTime;
                        existingFault.RepairStatus = faultTechnician.RepairStatus;
                        existingFault.Bookingate = DateTime.Now;
                        _db.tblFaultTechnicians.Update(existingFault);
                    }
                    else
                    {
                        faultTechnician.Bookingate = DateTime.Now;
                        _db.tblFaultTechnicians.Add(faultTechnician);
                    }

                    var associatedFaultReport = _db.tblFaultReports
                        .FirstOrDefault(fr => fr.FaultReportId == faultTechnician.FaultReportId);
                    if (associatedFaultReport != null && faultTechnician.RepairStatus == "In Progress")
                    {
                        associatedFaultReport.Status = "In Progress";
                    }

                    _db.SaveChanges();
                    TempData["Success"] = "Repair assignment created successfully!";
                    return RedirectToAction(nameof(ViewFaults));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error saving repair assignment: {ex.Message}");
                }
            }

            var faultReportForView = _db.tblFaultReports
                .Include(fr => fr.FridgeInStock)
                .ThenInclude(fis => fis.Fridge)
                .FirstOrDefault(fr => fr.FaultReportId == faultTechnician.FaultReportId);

            if (faultReportForView == null)
            {
                return NotFound();
            }

            ViewBag.FaultReport = faultReportForView;
            ViewBag.RepairStatusList = GetRepairStatusList();
            return View(faultTechnician);
        }

        // ========== HELPER METHODS ==========

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
    }
}