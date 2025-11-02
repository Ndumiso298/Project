using System.Collections.Generic;

namespace Project.ViewModel
{
    public class FaultTechnicianDashboardViewModel
    {
        public int TotalFaults { get; set; }
        public int PendingAssignment { get; set; }
        public int InProgress { get; set; }
        public int Completed { get; set; }
        public int TodaysBookings { get; set; }
        public List<KeyValuePair<string, int>> FaultsByDate { get; set; } = new List<KeyValuePair<string, int>>();
        public List<KeyValuePair<string, int>> FaultTypeDistribution { get; set; } = new List<KeyValuePair<string, int>>();
        public List<KeyValuePair<string, int>> RepairStatusDistribution { get; set; } = new List<KeyValuePair<string, int>>();
        public List<KeyValuePair<string, int>> TopTechnicians { get; set; } = new List<KeyValuePair<string, int>>();
        public List<KeyValuePair<string, int>> RecentActivities { get; set; } = new List<KeyValuePair<string, int>>();
    }
}