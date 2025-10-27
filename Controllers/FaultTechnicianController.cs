using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public FaultTechnicianController(ApplicationDbContext db)
        {
            _db = db;
        }

        // REPORTS
        public IActionResult Reports()
        {
            var filters = new ReportFilters();
            var reportResult = new ReportResult();
            ViewBag.Filters = filters;
            return View(reportResult);
        }

        // GENERATE REPORT DATA
        [HttpPost]
        public IActionResult GenerateReportData([FromBody] ReportFilters filters)
        {
            try
            {
                var reportResult = new ReportResult();
                return Json(new { success = true, data = reportResult });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        // VIEW MAINTENANCE FAULTS
        public IActionResult ViewMaintenanceFaults()
        {
            var maintenanceFaults = new List<MaintenanceFaultVM>();

            try
            {
                maintenanceFaults = _db.tblFridgeVisits
                    .Include(v => v.RequestHeader)
                    .Where(v => v.CheckupStatus.ToLower() == "failed")
                    .Select(v => new MaintenanceFaultVM
                    {
                        VisitId = v.VisitId,
                        CustomerName = v.RequestHeader != null ?
                            $"{v.RequestHeader.FirstName} {v.RequestHeader.LastName}" : "Unknown",
                        FridgeModel = "Unknown", // You can modify this based on your actual data structure
                        Description = v.Notes ?? "Maintenance check failed",
                        VisitDate = v.VisitDate,
                        Status = "Failed Checkup",
                        Priority = "Medium",
                        HasReportedFault = false,
                        Notes = v.Notes ?? ""
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error loading maintenance faults: {ex.Message}";
            }

            ViewBag.Source = "Maintenance";
            return View("FaultsBySource", maintenanceFaults);
        }

        // VIEW CUSTOMER FAULTS
        public IActionResult ViewCustomerFaults()
        {
            var customerFaults = new List<CustomerFaultVM>();

            try
            {
                customerFaults = _db.tblFaultReports
                    .Where(fr => fr.Status != "Resolved")
                    .Select(fr => new CustomerFaultVM
                    {
                        FaultReportId = fr.FaultReportId,
                        CustomerName = "Unknown", // Modify based on your data
                        FridgeModel = "Unknown", // Modify based on your data
                        Description = fr.Description ?? "",
                        ReportedDate = fr.ReportedDate,
                        Status = fr.Status ?? "Pending",
                        Priority = fr.Priority ?? "Medium",
                        FaultType = fr.FaultType ?? ""
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error loading customer faults: {ex.Message}";
            }

            ViewBag.Source = "Customer Reports";
            return View("FaultsBySource", customerFaults);
        }

        // VIEW ALL FAULTS
        public IActionResult ViewFaults()
        {
            var faults = new List<FaultTechnician>();

            try
            {
                faults = _db.tblFaultTechnicians
                    .OrderByDescending(ft => ft.Bookingate)
                    .ToList();
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error loading faults: {ex.Message}";
            }

            return View(faults);
        }

        // VIEW FAULT DETAILS
        public IActionResult ViewFaultDetails(int id, string source)
        {
            var viewModel = new FaultDetailsVM();

            try
            {
                if (source == "Maintenance")
                {
                    var maintenanceFault = _db.tblFridgeVisits
                        .Include(v => v.RequestHeader)
                        .FirstOrDefault(v => v.VisitId == id);

                    if (maintenanceFault != null)
                    {
                        viewModel.Source = "Maintenance";
                        viewModel.VisitId = maintenanceFault.VisitId;
                        viewModel.CustomerName = maintenanceFault.RequestHeader != null ?
                            $"{maintenanceFault.RequestHeader.FirstName} {maintenanceFault.RequestHeader.LastName}" : "Unknown";
                        viewModel.Description = maintenanceFault.Notes ?? "Maintenance check failed";
                        viewModel.ReportedDate = maintenanceFault.VisitDate;
                        viewModel.Status = maintenanceFault.CheckupStatus ?? "Unknown";
                    }
                }
                else
                {
                    var customerFault = _db.tblFaultReports
                        .FirstOrDefault(fr => fr.FaultReportId == id);

                    if (customerFault != null)
                    {
                        viewModel.Source = "Customer Report";
                        viewModel.FaultReportId = customerFault.FaultReportId;
                        viewModel.Description = customerFault.Description ?? "";
                        viewModel.FaultType = customerFault.FaultType ?? "";
                        viewModel.ReportedDate = customerFault.ReportedDate;
                        viewModel.Status = customerFault.Status ?? "Pending";
                        viewModel.Priority = customerFault.Priority ?? "Medium";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error loading fault details: {ex.Message}";
            }

            return View(viewModel);
        }

        // SCHEDULE REPAIR - GET
        public IActionResult ScheduleRepair(int id, string source)
        {
            var viewModel = new ScheduleRepairVM
            {
                FaultId = id,
                Source = source
            };
            return View(viewModel);
        }

        // SCHEDULE REPAIR - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ScheduleRepair(ScheduleRepairVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var faultTechnician = await _db.tblFaultTechnicians
                        .FirstOrDefaultAsync(ft => ft.FaultId == model.FaultId);

                    if (faultTechnician != null)
                    {
                        faultTechnician.Bookingate = model.ProposedDate;
                        faultTechnician.TechnicianAssigned = User.Identity?.Name ?? "Technician";
                        faultTechnician.CustomerBookingStatus = "Pending Approval";
                        faultTechnician.ResolutionNotes = model.TechnicianNotes;
                        faultTechnician.LastUpdated = DateTime.Now;

                        await _db.SaveChangesAsync();
                        TempData[SD.Success] = "Repair scheduled successfully!";
                    }
                    else
                    {
                        TempData[SD.Error] = "Fault assignment not found.";
                    }
                }
                catch (Exception ex)
                {
                    TempData[SD.Error] = $"Error scheduling repair: {ex.Message}";
                }
            }
            return RedirectToAction(nameof(ViewFaults));
        }

        // VIEW BOOKING CALENDAR
        public IActionResult ViewCalendar()
        {
            var calendarEvents = new List<CalendarEventVM>();

            try
            {
                var bookings = _db.tblFaultTechnicians
                    .Where(ft => ft.Bookingate != null)
                    .OrderBy(ft => ft.Bookingate)
                    .ToList();

                calendarEvents = bookings.Select(ft => new CalendarEventVM
                {
                    Id = ft.FaultId,
                    Title = "Repair Appointment",
                    Start = ft.Bookingate ?? DateTime.Now,
                    End = (ft.Bookingate ?? DateTime.Now).AddHours(2),
                    Status = ft.RepairStatus ?? "Pending",
                    CustomerBookingStatus = ft.CustomerBookingStatus ?? "Not Scheduled",
                    TechnicianName = ft.TechnicianAssigned ?? "Unassigned",
                    IsOverdue = false
                }).ToList();
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error loading calendar: {ex.Message}";
            }

            return View(calendarEvents);
        }
    }
}