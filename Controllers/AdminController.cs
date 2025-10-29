using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models.ViewModel;
using Project.Utility;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole)]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var dashboard = new AdminVM
            {
                // User Statistics
                TotalUsers = _db.AppUser.Count(),
                TotalCustomers = _db.tblCustomer.Count(),
                TotalEmployees = _db.tblEmployee.Count(),
                PendingApprovals = _db.AppUser.Count(u => !u.IsApproved && u.Status == "Pending"),

                // Fridge Statistics
                TotalFridgeModels = _db.tblFridges.Count(),
                TotalFridgeInstances = _db.tblFridgeInStocks.Count(),
                AvailableFridges = _db.tblFridgeInStocks.Count(f => f.IsAvailable),
                RentedFridges = _db.tblFridgeInStocks.Count(f => !f.IsAvailable),

                // Fridge Stock Details
                LowStockFridges = GetLowStockFridges(),
                FridgeStockStatus = GetFridgeStockStatus(),
                FridgeMaintenanceStatus = GetFridgeMaintenanceStatus(),

                // Request Statistics
                TotalRequests = _db.tblRequestHeaders.Count(),
                ApprovedRequests = _db.tblRequestHeaders.Count(r => r.Status == SD.Approved),
                PendingRequests = _db.tblRequestHeaders.Count(r => r.Status == SD.Pending),
                RejectedRequests = _db.tblRequestHeaders.Count(r => r.Status == SD.Rejected),

                // Maintenance Statistics
                TotalVisits = _db.tblFridgeVisits.Count(),
                CompletedVisits = _db.tblFridgeVisits.Count(v => v.CheckupStatus == "Passed"),
                FailedVisits = _db.tblFridgeVisits.Count(v => v.CheckupStatus == "Failed"),
                PendingRepairs = _db.tblFaultTechnicians.Count(ft => ft.RepairStatus == "In Progress"),

                // Financial Statistics
                MonthlyRevenue = CalculateMonthlyRevenue(),
                ActiveRentals = _db.tblCustomerFridge.Count(cf => cf.FridgeInStock.IsAvailable == false),
                ReplacementRequests = _db.tblFridgeReplacements.Count(fr => fr.ReplacementStatus == "Pending")
            };

            // Chart Data - Using client-side evaluation for complex queries
            dashboard.RequestsByStatus = GetRequestsByStatus();
            dashboard.FridgeBrandDistribution = GetFridgeBrandDistribution();
            dashboard.MonthlyRequestTrend = GetMonthlyRequestTrend();
            dashboard.VisitStatusDistribution = GetVisitStatusDistribution();
            dashboard.TopPerformingFridges = GetTopPerformingFridges();
            dashboard.RevenueByFridgeType = GetRevenueByFridgeType();
            dashboard.FridgeStockLevels = GetFridgeStockLevels();
            dashboard.MaintenanceDueFridges = GetMaintenanceDueFridges();

            // Recent Activities
            dashboard.RecentRequests = GetRecentRequests();
            dashboard.RecentVisits = GetRecentVisits();
            dashboard.RecentUsers = GetRecentUsers();
            dashboard.RecentStockUpdates = GetRecentStockUpdates();

            return View(dashboard);
        }

        private decimal CalculateMonthlyRevenue()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var monthlyRevenue = _db.tblRequestDetais
                .Include(rd => rd.RequestHeader)
                .Where(rd => rd.RequestHeader.RequestDate.Month == currentMonth &&
                            rd.RequestHeader.RequestDate.Year == currentYear &&
                            rd.RequestHeader.Status == SD.Approved)
                .Sum(rd => (decimal)(rd.Price * rd.Count));

            return monthlyRevenue;
        }

        private List<ChartData> GetRequestsByStatus()
        {
            return new List<ChartData>
            {
                new ChartData { Label = "Approved", Value = _db.tblRequestHeaders.Count(r => r.Status == SD.Approved) },
                new ChartData { Label = "Pending", Value = _db.tblRequestHeaders.Count(r => r.Status == SD.Pending) },
                new ChartData { Label = "Rejected", Value = _db.tblRequestHeaders.Count(r => r.Status == SD.Rejected) },
                new ChartData { Label = "Needs Feedback", Value = _db.tblRequestHeaders.Count(r => r.Status == SD.NeedsFeedback) }
            };
        }

        private List<ChartData> GetFridgeBrandDistribution()
        {
            return _db.tblFridges
                .GroupBy(f => f.Brand)
                .Select(g => new ChartData { Label = g.Key, Value = g.Count() })
                .ToList();
        }

        private List<ChartData> GetMonthlyRequestTrend()
        {
            var sixMonthsAgo = DateTime.Now.AddMonths(-6);

            var monthlyData = _db.tblRequestHeaders
                .Where(r => r.RequestDate >= sixMonthsAgo)
                .Select(r => new { r.RequestDate.Year, r.RequestDate.Month })
                .AsEnumerable()
                .GroupBy(r => new { r.Year, r.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToList();

            return monthlyData.Select(m => new ChartData
            {
                Label = $"{m.Month:00}/{m.Year}",
                Value = m.Count
            }).ToList();
        }

        private List<ChartData> GetVisitStatusDistribution()
        {
            return _db.tblFridgeVisits
                .GroupBy(v => v.CheckupStatus)
                .Select(g => new ChartData { Label = g.Key ?? "Unknown", Value = g.Count() })
                .ToList();
        }

        private List<TopFridgeVM> GetTopPerformingFridges()
        {
            // First get the data from database
            var approvedRequests = _db.tblRequestDetais
                .Include(rd => rd.RequestHeader)
                .Include(rd => rd.Fridge)
                .Where(rd => rd.RequestHeader.Status == SD.Approved)
                .AsEnumerable();

            // Then process on client side
            var fridgePerformance = approvedRequests
                .GroupBy(rd => new { rd.FridgeId, rd.Fridge.Brand, rd.Fridge.Model })
                .Select(g => new
                {
                    FridgeId = g.Key.FridgeId,
                    Brand = g.Key.Brand,
                    Model = g.Key.Model,
                    TotalRentals = g.Count(),
                    Revenue = (decimal)g.Sum(rd => rd.Price * rd.Count)
                })
                .ToList();

            // Now create the final view models with stock level
            var result = fridgePerformance.Select(x => new TopFridgeVM
            {
                FridgeModel = $"{x.Brand} {x.Model}",
                TotalRentals = x.TotalRentals,
                Revenue = x.Revenue,
                AvailabilityRate = CalculateAvailabilityRate(x.FridgeId),
                StockLevel = GetStockLevelStatus(x.FridgeId)
            })
            .OrderByDescending(f => f.Revenue)
            .Take(5)
            .ToList();

            return result;
        }

        private List<ChartData> GetRevenueByFridgeType()
        {
            var revenueData = _db.tblRequestDetais
                .Include(rd => rd.RequestHeader)
                .Include(rd => rd.Fridge)
                .Where(rd => rd.RequestHeader.Status == SD.Approved)
                .AsEnumerable()
                .GroupBy(rd => rd.Fridge.Type)
                .Select(g => new ChartData
                {
                    Label = g.Key ?? "Unknown",
                    Value = (int)g.Sum(rd => rd.Price * rd.Count)
                })
                .ToList();

            return revenueData;
        }

        // NEW: Fridge Stock Methods
        private List<LowStockFridgeVM> GetLowStockFridges()
        {
            // First get fridge data from database
            var fridgeData = _db.tblFridges
                .Include(f => f.FridgeInstances)
                .Select(f => new
                {
                    FridgeId = f.FridgeId,
                    Brand = f.Brand,
                    Model = f.Model,
                    TotalInstances = f.FridgeInstances.Count,
                    AvailableInstances = f.FridgeInstances.Count(i => i.IsAvailable)
                })
                .Where(x => x.AvailableInstances <= 5) // Low stock threshold
                .ToList();

            // Then process on client side
            var lowStockFridges = fridgeData.Select(x => new LowStockFridgeVM
            {
                FridgeModel = $"{x.Brand} {x.Model}",
                AvailableStock = x.AvailableInstances,
                TotalStock = x.TotalInstances,
                StockLevel = GetStockLevelStatus(x.FridgeId)
            })
            .OrderBy(f => f.AvailableStock)
            .Take(5)
            .ToList();

            return lowStockFridges;
        }

        private List<ChartData> GetFridgeStockStatus()
        {
            var fridgeData = _db.tblFridges
                .Include(f => f.FridgeInstances)
                .AsEnumerable()
                .Select(f => new
                {
                    Available = f.FridgeInstances.Count(i => i.IsAvailable),
                    Total = f.FridgeInstances.Count
                })
                .ToList();

            var stockGroups = fridgeData
                .GroupBy(x => GetOverallStockLevel(x.Available))
                .Select(g => new ChartData
                {
                    Label = g.Key,
                    Value = g.Count()
                })
                .ToList();

            return stockGroups;
        }

        private List<ChartData> GetFridgeStockLevels()
        {
            var stockData = _db.tblFridges
                .Include(f => f.FridgeInstances)
                .AsEnumerable()
                .Select(f => new
                {
                    Label = $"{f.Brand} {f.Model}",
                    Value = f.FridgeInstances.Count(i => i.IsAvailable)
                })
                .OrderByDescending(s => s.Value)
                .Take(10)
                .ToList();

            return stockData.Select(s => new ChartData
            {
                Label = s.Label,
                Value = s.Value
            }).ToList();
        }

        private List<MaintenanceDueVM> GetMaintenanceDueFridges()
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            var maintenanceDue = _db.tblFridgeInStocks
                .Include(f => f.Fridge)
                .Where(f => f.LastMaintenanceDate <= thirtyDaysAgo || f.LastMaintenanceDate == null)
                .Select(f => new MaintenanceDueVM
                {
                    FridgeNo = f.FridgeNo,
                    FridgeModel = $"{f.Fridge.Brand} {f.Fridge.Model}",
                    LastMaintenanceDate = f.LastMaintenanceDate,
                    Condition = f.Condition,
                    Location = f.Location
                })
                .OrderBy(f => f.LastMaintenanceDate)
                .Take(5)
                .ToList();

            return maintenanceDue;
        }

        private List<ChartData> GetFridgeMaintenanceStatus()
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            var maintenanceStatus = _db.tblFridgeInStocks
                .GroupBy(f => f.LastMaintenanceDate <= thirtyDaysAgo || f.LastMaintenanceDate == null ? "Due" : "Current")
                .Select(g => new ChartData
                {
                    Label = g.Key,
                    Value = g.Count()
                })
                .ToList();

            return maintenanceStatus;
        }

        private List<RecentRequestVM> GetRecentRequests()
        {
            return _db.tblRequestHeaders
                .Include(r => r.Customer.ApplicationUser)
                .Include(r => r.RequestFridges)
                .OrderByDescending(r => r.RequestDate)
                .Take(5)
                .Select(r => new RecentRequestVM
                {
                    RequestId = r.RequestHeaderId,
                    CustomerName = $"{r.Customer.ApplicationUser.FirstName} {r.Customer.ApplicationUser.LastName}",
                    RequestDate = r.RequestDate,
                    Status = r.Status,
                    TotalAmount = (decimal)r.RequestFridges.Sum(rf => rf.Price * rf.Count)
                })
                .ToList();
        }

        private List<RecentVisitVM> GetRecentVisits()
        {
            return _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .ThenInclude(r => r.Customer.ApplicationUser)
                .OrderByDescending(v => v.VisitDate)
                .Take(5)
                .Select(v => new RecentVisitVM
                {
                    VisitId = v.VisitId,
                    CustomerName = $"{v.RequestHeader.Customer.ApplicationUser.FirstName} {v.RequestHeader.Customer.ApplicationUser.LastName}",
                    VisitDate = v.VisitDate,
                    Status = v.CheckupStatus ?? "Unknown",
                    TechnicianNotes = v.Notes
                })
                .ToList();
        }

        private List<RecentUserVM> GetRecentUsers()
        {
            var users = _db.AppUser
                .OrderByDescending(u => u.Id)
                .Take(5)
                .ToList();

            var recentUsers = users.Select(u => new RecentUserVM
            {
                UserId = u.Id,
                Name = $"{u.FirstName} {u.LastName}",
                Email = u.Email,
                Role = GetUserRole(u.Id),
                RegistrationDate = DateTime.Now
            }).ToList();

            return recentUsers;
        }

        private List<RecentStockUpdateVM> GetRecentStockUpdates()
        {
            var recentStock = _db.tblFridgeInStocks
                .Include(f => f.Fridge)
                .OrderByDescending(f => f.FridgeInStockId)
                .Take(5)
                .Select(f => new RecentStockUpdateVM
                {
                    FridgeNo = f.FridgeNo,
                    FridgeModel = $"{f.Fridge.Brand} {f.Fridge.Model}",
                    Condition = f.Condition,
                    Location = f.Location,
                    IsAvailable = f.IsAvailable,
                    LastMaintenanceDate = f.LastMaintenanceDate
                })
                .ToList();

            return recentStock;
        }

        // Helper Methods
        private string GetUserRole(string userId)
        {
            var userRole = _db.UserRoles.FirstOrDefault(ur => ur.UserId == userId);
            if (userRole != null)
            {
                var role = _db.Roles.FirstOrDefault(r => r.Id == userRole.RoleId);
                return role?.Name ?? "Customer";
            }
            return "Customer";
        }

        private decimal CalculateAvailabilityRate(int fridgeId)
        {
            var totalInstances = _db.tblFridgeInStocks.Count(f => f.FridgeId == fridgeId);
            var availableInstances = _db.tblFridgeInStocks.Count(f => f.FridgeId == fridgeId && f.IsAvailable);

            if (totalInstances == 0) return 0;

            return (decimal)availableInstances / totalInstances * 100;
        }

        private string GetStockLevelStatus(int fridgeId)
        {
            var availableInstances = _db.tblFridgeInStocks.Count(f => f.FridgeId == fridgeId && f.IsAvailable);

            if (availableInstances == 0) return "Out of Stock";
            if (availableInstances <= 2) return "Low Stock";
            if (availableInstances <= 5) return "Medium Stock";
            return "High Stock";
        }

        private string GetOverallStockLevel(int availableStock)
        {
            if (availableStock == 0) return "Out of Stock";
            if (availableStock <= 2) return "Low Stock";
            if (availableStock <= 5) return "Medium Stock";
            return "High Stock";
        }
    }
}