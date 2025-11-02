
using System.Collections.Generic;

namespace Project.Models.ViewModel
{
    public class CustomerSupportDashboardViewModel
    {
        public int TotalRequests { get; set; }
        public int PendingRequests { get; set; }
        public int ApprovedRequests { get; set; }
        public int RejectedRequests { get; set; }
        public int TotalCustomers { get; set; }
        public int RelaunchedRequests { get; set; }
        public int RequestsToday { get; set; }
        public List<KeyValuePair<string, int>> RequestsByDate { get; set; }
        public List<KeyValuePair<string, int>> RequestStatusDistribution { get; set; }
        public List<KeyValuePair<string, int>> TopRequestedFridges { get; set; }
        public List<KeyValuePair<string, int>> RecentActivity { get; set; }
    }
}