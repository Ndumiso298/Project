using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReportResult> GenerateReportAsync(ReportFilters filters)
        {
            return filters.ReportType?.ToLower() switch
            {
                "faults_summary" => await GenerateFaultsSummaryReport(filters),
                "technician_performance" => await GenerateTechnicianPerformanceReport(filters),
                "maintenance_schedule" => await GenerateMaintenanceScheduleReport(filters),
                "customer_reports" => await GenerateCustomerReportsAnalysis(filters),
                "response_times" => await GenerateResponseTimeAnalysis(filters),
                _ => await GenerateFaultsSummaryReport(filters)
            };
        }

        public async Task<ReportResult> GenerateFaultsSummaryReport(ReportFilters filters)
        {
            var query = _context.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                .Include(ft => ft.FaultReport)
                .AsQueryable();

            query = ApplyFilters(query, filters);

            var faults = await query.ToListAsync();
            var totalFaults = faults.Count;
            var completedFaults = faults.Count(f => f.RepairStatus == "Completed");
            var inProgressFaults = faults.Count(f => f.RepairStatus == "In Progress");
            var notStartedFaults = faults.Count(f => f.RepairStatus == "Not Started" || f.RepairStatus == "Pending");

            var faultData = new List<Dictionary<string, object>>();
            foreach (var fault in faults)
            {
                var customerName = GetCustomerName(fault);
                var fridgeModel = GetFridgeModel(fault);
                var reportedDate = GetReportedDate(fault);

                faultData.Add(new Dictionary<string, object>
                {
                    ["id"] = fault.FaultId,
                    ["customerName"] = customerName,
                    ["fridgeModel"] = fridgeModel,
                    ["reportedDate"] = reportedDate,
                    ["status"] = fault.RepairStatus ?? "Unknown",
                    ["technicianName"] = fault.TechnicianAssigned ?? "Unassigned",
                    ["priority"] = fault.Priority ?? "Medium"
                });
            }

            return new ReportResult
            {
                Title = "Faults Summary Report",
                Summary = new List<SummaryItem>
                {
                    new() { Title = "Total Faults", Value = totalFaults.ToString(), Color = "primary", Icon = "fa-exclamation-triangle" },
                    new() { Title = "Completed", Value = completedFaults.ToString(), Color = "success", Icon = "fa-check-circle" },
                    new() { Title = "In Progress", Value = inProgressFaults.ToString(), Color = "warning", Icon = "fa-tasks" },
                    new() { Title = "Not Started", Value = notStartedFaults.ToString(), Color = "danger", Icon = "fa-clock" }
                },
                Columns = new List<ColumnDefinition>
                {
                    new() { Field = "id", Title = "Fault ID", Type = "text" },
                    new() { Field = "customerName", Title = "Customer", Type = "text" },
                    new() { Field = "fridgeModel", Title = "Fridge Model", Type = "text" },
                    new() { Field = "reportedDate", Title = "Reported Date", Type = "date" },
                    new() { Field = "status", Title = "Status", Type = "text" },
                    new() { Field = "technicianName", Title = "Technician", Type = "text" },
                    new() { Field = "priority", Title = "Priority", Type = "text" }
                },
                Data = faultData,
                ChartData = new ChartData
                {
                    Type = "bar",
                    Title = "Faults by Status",
                    Labels = new List<string> { "Completed", "In Progress", "Not Started" },
                    Datasets = new List<ChartDataset>
                    {
                        new()
                        {
                            Label = "Fault Count",
                            Data = new List<decimal> { completedFaults, inProgressFaults, notStartedFaults },
                            BackgroundColor = new List<string> { "#1cc88a", "#f6c23e", "#e74a3b" },
                            BorderColor = new List<string> { "#1cc88a", "#f6c23e", "#e74a3b" }
                        }
                    }
                }
            };
        }

        public async Task<ReportResult> GenerateTechnicianPerformanceReport(ReportFilters filters)
        {
            var dateRange = GetDateRange(filters);

            var technicianPerformance = await _context.tblFaultTechnicians
                .Where(ft => !string.IsNullOrEmpty(ft.TechnicianAssigned))
                .GroupBy(ft => ft.TechnicianAssigned)
                .Select(g => new
                {
                    TechnicianName = g.Key,
                    TotalFaults = g.Count(),
                    CompletedFaults = g.Count(ft => ft.RepairStatus == "Completed"),
                    AvgRepairTime = g.Where(ft => ft.ActualRepairTime.HasValue && ft.RepairStatus == "Completed")
                                     .Average(ft => ft.ActualRepairTime)
                })
                .ToListAsync();

            return new ReportResult
            {
                Title = "Technician Performance Report",
                Summary = new List<SummaryItem>
                {
                    new() { Title = "Total Technicians", Value = technicianPerformance.Count.ToString(), Color = "info", Icon = "fa-users" },
                    new() { Title = "Total Completed", Value = technicianPerformance.Sum(t => t.CompletedFaults).ToString(), Color = "success", Icon = "fa-check-circle" }
                },
                Columns = new List<ColumnDefinition>
                {
                    new() { Field = "name", Title = "Technician Name", Type = "text" },
                    new() { Field = "totalFaults", Title = "Total Faults", Type = "number" },
                    new() { Field = "completedFaults", Title = "Completed", Type = "number" },
                    new() { Field = "completionRate", Title = "Completion Rate", Type = "text" },
                    new() { Field = "avgRepairTime", Title = "Avg Repair Time (hrs)", Type = "number" }
                },
                Data = technicianPerformance.Select(t => new Dictionary<string, object>
                {
                    ["name"] = t.TechnicianName ?? "Unknown",
                    ["totalFaults"] = t.TotalFaults,
                    ["completedFaults"] = t.CompletedFaults,
                    ["completionRate"] = t.TotalFaults > 0 ? $"{((decimal)t.CompletedFaults / t.TotalFaults * 100):0}%" : "0%",
                    ["avgRepairTime"] = t.AvgRepairTime?.ToString("0.0") ?? "N/A"
                }).ToList()
            };
        }

        public async Task<ReportResult> GenerateMaintenanceScheduleReport(ReportFilters filters)
        {
            var query = _context.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                .Where(ft => ft.VisitId != null)
                .AsQueryable();

            query = ApplyFilters(query, filters);

            var maintenanceFaults = await query.ToListAsync();

            var data = maintenanceFaults.Select(ft => new Dictionary<string, object>
            {
                ["id"] = ft.FaultId,
                ["customerName"] = GetCustomerName(ft),
                ["fridgeModel"] = GetFridgeModel(ft),
                ["scheduledDate"] = ft.Bookingate,
                ["status"] = ft.RepairStatus ?? "Unknown",
                ["technician"] = ft.TechnicianAssigned ?? "Unassigned",
                ["priority"] = ft.Priority ?? "Medium"
            }).ToList();

            return new ReportResult
            {
                Title = "Maintenance Schedule Report",
                Summary = new List<SummaryItem>
                {
                    new() { Title = "Scheduled Maintenance", Value = data.Count.ToString(), Color = "info", Icon = "fa-calendar" },
                    new() { Title = "Completed", Value = data.Count(d => d["status"]?.ToString() == "Completed").ToString(), Color = "success", Icon = "fa-check" }
                },
                Columns = new List<ColumnDefinition>
                {
                    new() { Field = "id", Title = "Job ID", Type = "text" },
                    new() { Field = "customerName", Title = "Customer", Type = "text" },
                    new() { Field = "fridgeModel", Title = "Fridge Model", Type = "text" },
                    new() { Field = "scheduledDate", Title = "Scheduled Date", Type = "date" },
                    new() { Field = "status", Title = "Status", Type = "text" },
                    new() { Field = "technician", Title = "Technician", Type = "text" },
                    new() { Field = "priority", Title = "Priority", Type = "text" }
                },
                Data = data
            };
        }

        public async Task<ReportResult> GenerateCustomerReportsAnalysis(ReportFilters filters)
        {
            var query = _context.tblFaultTechnicians
                .Include(ft => ft.FaultReport)
                .Where(ft => ft.FaultReportId != null)
                .AsQueryable();

            query = ApplyFilters(query, filters);

            var customerFaults = await query.ToListAsync();

            var data = customerFaults.Select(ft => new Dictionary<string, object>
            {
                ["id"] = ft.FaultId,
                ["customerName"] = GetCustomerName(ft),
                ["fridgeModel"] = GetFridgeModel(ft),
                ["reportedDate"] = ft.FaultReport?.ReportedDate ?? DateTime.MinValue,
                ["status"] = ft.RepairStatus ?? "Unknown",
                ["technician"] = ft.TechnicianAssigned ?? "Unassigned",
                ["priority"] = ft.Priority ?? "Medium",
                ["resolutionNotes"] = ft.ResolutionNotes ?? "No notes"
            }).ToList();

            return new ReportResult
            {
                Title = "Customer Reports Analysis",
                Summary = new List<SummaryItem>
                {
                    new() { Title = "Customer Reports", Value = data.Count.ToString(), Color = "warning", Icon = "fa-user" },
                    new() { Title = "Resolved", Value = data.Count(d => d["status"]?.ToString() == "Completed").ToString(), Color = "success", Icon = "fa-check-circle" }
                },
                Columns = new List<ColumnDefinition>
                {
                    new() { Field = "id", Title = "Report ID", Type = "text" },
                    new() { Field = "customerName", Title = "Customer", Type = "text" },
                    new() { Field = "fridgeModel", Title = "Fridge Model", Type = "text" },
                    new() { Field = "reportedDate", Title = "Reported Date", Type = "date" },
                    new() { Field = "status", Title = "Status", Type = "text" },
                    new() { Field = "technician", Title = "Technician", Type = "text" },
                    new() { Field = "priority", Title = "Priority", Type = "text" },
                    new() { Field = "resolutionNotes", Title = "Resolution Notes", Type = "text" }
                },
                Data = data
            };
        }

        public async Task<ReportResult> GenerateResponseTimeAnalysis(ReportFilters filters)
        {
            var dateRange = GetDateRange(filters);

            var responseData = await _context.tblFaultTechnicians
                .Include(ft => ft.FaultReport)
                .Where(ft => ft.Bookingate.HasValue && ft.FaultReportId != null && ft.FaultReport.ReportedDate != null)
                .Select(ft => new
                {
                    ft.FaultId,
                    ReportedDate = ft.FaultReport.ReportedDate,
                    ft.Bookingate
                })
                .ToListAsync();

            var processedData = responseData.Select(r => new
            {
                r.FaultId,
                r.ReportedDate,
                r.Bookingate,
                ResponseTimeDays = (r.Bookingate.Value - r.ReportedDate).TotalDays
            }).ToList();

            var avgResponseTime = processedData.Any() ? processedData.Average(r => r.ResponseTimeDays) : 0;

            return new ReportResult
            {
                Title = "Response Time Analysis",
                Summary = new List<SummaryItem>
                {
                    new() { Title = "Avg Response Time", Value = $"{avgResponseTime:0.0} days", Color = "info", Icon = "fa-clock" },
                    new() { Title = "Total Responses", Value = processedData.Count.ToString(), Color = "primary", Icon = "fa-chart-line" }
                },
                Columns = new List<ColumnDefinition>
                {
                    new() { Field = "id", Title = "Fault ID", Type = "text" },
                    new() { Field = "reportedDate", Title = "Reported Date", Type = "date" },
                    new() { Field = "scheduledDate", Title = "Scheduled Date", Type = "date" },
                    new() { Field = "responseTime", Title = "Response Time (days)", Type = "number" }
                },
                Data = processedData.Select(r => new Dictionary<string, object>
                {
                    ["id"] = r.FaultId,
                    ["reportedDate"] = r.ReportedDate,
                    ["scheduledDate"] = r.Bookingate,
                    ["responseTime"] = r.ResponseTimeDays.ToString("0.0")
                }).ToList()
            };
        }

        // Helper methods
        private IQueryable<FaultTechnician> ApplyFilters(IQueryable<FaultTechnician> query, ReportFilters filters)
        {
            if (!string.IsNullOrEmpty(filters.Status))
            {
                query = query.Where(ft => ft.RepairStatus == filters.Status);
            }

            if (!string.IsNullOrEmpty(filters.Technician))
            {
                query = query.Where(ft => ft.TechnicianAssigned == filters.Technician);
            }

            var dateRange = GetDateRange(filters);
            query = query.Where(ft =>
                (ft.Bookingate >= dateRange.Start && ft.Bookingate <= dateRange.End) ||
                (ft.FaultReport != null && ft.FaultReport.ReportedDate >= dateRange.Start && ft.FaultReport.ReportedDate <= dateRange.End) ||
                (ft.FridgeVisit != null && ft.FridgeVisit.VisitDate >= dateRange.Start && ft.FridgeVisit.VisitDate <= dateRange.End)
            );

            return query;
        }

        private (DateTime Start, DateTime End) GetDateRange(ReportFilters filters)
        {
            var today = DateTime.Today;

            return filters.DateRange?.ToLower() switch
            {
                "today" => (today, today.AddDays(1).AddTicks(-1)),
                "yesterday" => (today.AddDays(-1), today.AddTicks(-1)),
                "week" => (today.AddDays(-(int)today.DayOfWeek), today.AddDays(1).AddTicks(-1)),
                "month" => (new DateTime(today.Year, today.Month, 1), today.AddDays(1).AddTicks(-1)),
                "quarter" => (today.AddMonths(-3), today.AddDays(1).AddTicks(-1)),
                "year" => (new DateTime(today.Year, 1, 1), today.AddDays(1).AddTicks(-1)),
                "custom" when filters.StartDate.HasValue && filters.EndDate.HasValue
                    => (filters.StartDate.Value, filters.EndDate.Value),
                _ => (today.AddDays(-30), today.AddDays(1).AddTicks(-1))
            };
        }

        private string GetCustomerName(FaultTechnician fault)
        {
            if (fault.FaultReport?.Customer?.ApplicationUser != null)
                return fault.FaultReport.Customer.ApplicationUser.UserName ?? "Unknown";
            if (fault.FridgeVisit?.RequestHeader != null)
                return $"{fault.FridgeVisit.RequestHeader.FirstName} {fault.FridgeVisit.RequestHeader.LastName}";
            return "Unknown";
        }

        private string GetFridgeModel(FaultTechnician fault)
        {
            if (fault.FaultReport?.FridgeInStock?.Fridge != null)
                return fault.FaultReport.FridgeInStock.Fridge.Model ?? "Unknown";
            if (fault.FridgeVisit?.RequestHeader?.RequestFridges?.FirstOrDefault()?.Fridge != null)
                return fault.FridgeVisit.RequestHeader.RequestFridges.First().Fridge.Model ?? "Unknown";
            return "Unknown";
        }

        private DateTime GetReportedDate(FaultTechnician fault)
        {
            return fault.FaultReport?.ReportedDate ??
                   fault.FridgeVisit?.VisitDate ??
                   fault.Bookingate ??
                   fault.CreatedDate;
        }
    }
}