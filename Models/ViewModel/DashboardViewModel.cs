using System.Collections.Generic;

namespace Project.ViewModel
{
    public class DashboardViewModel
    {
        // Summary metrics
        public int TotalRequests { get; set; }
        public int ApprovedRequests { get; set; }
        public int PendingRequests { get; set; }
        public int CompletedVisits { get; set; }
        public int VisitsToday { get; set; }

        // Chart data
        public List<KeyValuePair<string, int>> VisitsByDate { get; set; } = new();
        public List<KeyValuePair<string, int>> FridgeTypeDistribution { get; set; } = new();
        public List<KeyValuePair<string, int>> CheckupStatusCounts { get; set; } = new();
        public List<KeyValuePair<string, int>> TopCustomers { get; set; } = new();
    }
}
