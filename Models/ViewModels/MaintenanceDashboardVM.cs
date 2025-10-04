namespace Project.Models.ViewModels
{
    public class MaintenanceDashboardVM
    {
        public int TotalVisits { get; set; }
        public int ScheduledVisits { get; set; }
        public int CompletedVisits { get; set; }
        public int InProgressVisits { get; set; }
        public List<MaintenanceVisit> UpcomingVisits { get; set; } = new List<MaintenanceVisit>();
        public List<MaintenanceVisit> OverdueVisits { get; set; } = new List<MaintenanceVisit>();
    }
}
