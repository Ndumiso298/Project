using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

public class ReportsController : Controller
{
    private readonly ApplicationDbContext _db;

    public ReportsController(ApplicationDbContext db)
    {
        _db = db;
    }

    // Fault Analysis Report
    public IActionResult FaultAnalysisReport(DateTime? startDate, DateTime? endDate)
    {
        startDate ??= DateTime.Now.AddMonths(-1);
        endDate ??= DateTime.Now;

        var faults = _db.tblFaultTechnicians
            .Include(ft => ft.FridgeVisit)
            .ThenInclude(fv => fv.RequestHeader)
            .ThenInclude(rh => rh.RequestFridges)
            .ThenInclude(rf => rf.Fridge)
            .Where(ft => ft.Bookingate >= startDate && ft.Bookingate <= endDate)
            .ToList();

        var reportData = new
        {
            TotalFaults = faults.Count,
            CompletedFaults = faults.Count(f => f.RepairStatus == "Completed"),
            AverageRepairTime = faults.Where(f => f.ActualRepairTime.HasValue).Average(f => f.ActualRepairTime ?? 0),
            FaultsByStatus = faults.GroupBy(f => f.RepairStatus).ToDictionary(g => g.Key, g => g.Count()),
            FaultsByFridgeModel = faults
                .Where(f => f.FridgeVisit != null && f.FridgeVisit.RequestHeader != null && f.FridgeVisit.RequestHeader.RequestFridges.Any())
                .GroupBy(f => f.FridgeVisit.RequestHeader.RequestFridges.FirstOrDefault().Fridge.Model)
                .ToDictionary(g => g.Key ?? "Unknown", g => g.Count())
        };

        ViewBag.ReportData = reportData;
        ViewBag.StartDate = startDate;
        ViewBag.EndDate = endDate;

        return View();
    }

    // Maintenance Report
    public IActionResult MaintenanceReport()
    {
        var fridgesNeedMaintenance = _db.tblFridgeInStocks
            .Where(fis => fis.LastMaintenanceDate.AddMonths(6) <= DateTime.Now)
            .Include(fis => fis.Fridge)
            .OrderBy(fis => fis.LastMaintenanceDate)
            .ToList();

        var maintenanceHistory = _db.tblFridgeVisits
            .Include(v => v.RequestHeader)
            .ThenInclude(rh => rh.RequestFridges)
            .ThenInclude(rf => rf.Fridge)
            .Where(v => v.CheckupStatus != "Failed")
            .OrderByDescending(v => v.VisitDate)
            .Take(50)
            .ToList();

        ViewBag.FridgesNeedMaintenance = fridgesNeedMaintenance;
        ViewBag.MaintenanceHistory = maintenanceHistory;

        return View();
    }

    // Technician Performance Report
    public IActionResult TechnicianPerformanceReport()
    {
        var technicianPerformance = _db.tblFaultTechnicians
            .Where(ft => ft.TechnicianAssigned != null && ft.RepairStatus == "Completed")
            .GroupBy(ft => ft.TechnicianAssigned)
            .Select(g => new
            {
                Technician = g.Key,
                CompletedJobs = g.Count(),
                AvgRepairTime = g.Average(ft => ft.ActualRepairTime ?? 0),
                TotalRepairCost = g.Sum(ft => ft.RepairCost ?? 0)
            })
            .OrderByDescending(t => t.CompletedJobs)
            .ToList();

        ViewBag.TechnicianPerformance = technicianPerformance;
        return View();
    }

    // Customer Satisfaction Report
    public IActionResult CustomerSatisfactionReport()
    {
        var customerFaults = _db.tblFaultReports
            .Include(fr => fr.Customer)
            .ThenInclude(c => c.ApplicationUser)
            .GroupBy(fr => new { fr.Customer.CustomerID, fr.Customer.ApplicationUser.FirstName, fr.Customer.ApplicationUser.LastName })
            .Select(g => new
            {
                CustomerName = g.Key.FirstName + " " + g.Key.LastName,
                TotalFaults = g.Count(),
                ResolvedFaults = g.Count(f => f.Status == "Completed"),
                AvgResolutionTime = g.Where(f => f.FaultTechnicians != null && f.FaultTechnicians.Any())
                                   .SelectMany(f => f.FaultTechnicians)
                                   .Where(ft => ft.Completion.HasValue)
                                   //.Average(ft => (ft.Completion - f.ReportedDate).Value.TotalDays)
            })
            .OrderBy(c => c.AvgResolutionTime)
            .ToList();

        ViewBag.CustomerSatisfaction = customerFaults;
        return View();
    }
}