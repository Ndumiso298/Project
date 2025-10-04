using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class MaintenanceDashboardVM
    {
        [Display(Name = "Total Maintenance Visits")]
        public int TotalVisits { get; set; }

        [Display(Name = "Scheduled Maintenance")]
        public int ScheduledVisits { get; set; }

        [Display(Name = "Completed Services")]
        public int CompletedVisits { get; set; }

        [Display(Name = "Services In Progress")]
        public int InProgressVisits { get; set; }

        [Display(Name = "Pending Fault Reports")]
        public int PendingFaults { get; set; }

        [Display(Name = "Upcoming Maintenance")]
        public List<MaintenanceVisit> UpcomingVisits { get; set; } = new();

        [Display(Name = "Overdue Maintenance")]
        public List<MaintenanceVisit> OverdueVisits { get; set; } = new();

        [Display(Name = "Recent Fault Reports")]
        public List<FaultRecord> RecentFaults { get; set; } = new();
    }
}
