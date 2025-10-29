using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class AdminVM
    {
        // User Statistics
        public int TotalUsers { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalEmployees { get; set; }
        public int PendingApprovals { get; set; }

        // Fridge Statistics
        public int TotalFridgeModels { get; set; }
        public int TotalFridgeInstances { get; set; }
        public int AvailableFridges { get; set; }
        public int RentedFridges { get; set; }

        // Fridge Stock Details
        public List<LowStockFridgeVM> LowStockFridges { get; set; } = new();
        public List<ChartData> FridgeStockStatus { get; set; } = new();
        public List<ChartData> FridgeMaintenanceStatus { get; set; } = new();

        // Request Statistics
        public int TotalRequests { get; set; }
        public int ApprovedRequests { get; set; }
        public int PendingRequests { get; set; }
        public int RejectedRequests { get; set; }

        // Maintenance Statistics
        public int TotalVisits { get; set; }
        public int CompletedVisits { get; set; }
        public int FailedVisits { get; set; }
        public int PendingRepairs { get; set; }

        // Financial Statistics
        public decimal MonthlyRevenue { get; set; }
        public int ActiveRentals { get; set; }
        public int ReplacementRequests { get; set; }

        // Chart Data
        public List<ChartData> RequestsByStatus { get; set; } = new();
        public List<ChartData> FridgeBrandDistribution { get; set; } = new();
        public List<ChartData> MonthlyRequestTrend { get; set; } = new();
        public List<ChartData> VisitStatusDistribution { get; set; } = new();
        public List<TopFridgeVM> TopPerformingFridges { get; set; } = new();
        public List<ChartData> RevenueByFridgeType { get; set; } = new();
        public List<ChartData> FridgeStockLevels { get; set; } = new();
        public List<MaintenanceDueVM> MaintenanceDueFridges { get; set; } = new();

        // Recent Activities
        public List<RecentRequestVM> RecentRequests { get; set; } = new();
        public List<RecentVisitVM> RecentVisits { get; set; } = new();
        public List<RecentUserVM> RecentUsers { get; set; } = new();
        public List<RecentStockUpdateVM> RecentStockUpdates { get; set; } = new();
    }

    public class ChartData
    {
        public string Label { get; set; }
        public int Value { get; set; }
    }

    public class TopFridgeVM
    {
        public string FridgeModel { get; set; }
        public int TotalRentals { get; set; }
        public decimal Revenue { get; set; }
        public decimal AvailabilityRate { get; set; }
        public string StockLevel { get; set; }
    }

    public class LowStockFridgeVM
    {
        public string FridgeModel { get; set; }
        public int AvailableStock { get; set; }
        public int TotalStock { get; set; }
        public string StockLevel { get; set; }
    }

    public class MaintenanceDueVM
    {
        public string FridgeNo { get; set; }
        public string FridgeModel { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
    }

    public class RecentRequestVM
    {
        public int RequestId { get; set; }
        public string CustomerName { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class RecentVisitVM
    {
        public int VisitId { get; set; }
        public string CustomerName { get; set; }
        public DateTime VisitDate { get; set; }
        public string Status { get; set; }
        public string TechnicianNotes { get; set; }
    }

    public class RecentUserVM
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    public class RecentStockUpdateVM
    {
        public string FridgeNo { get; set; }
        public string FridgeModel { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
    }
}