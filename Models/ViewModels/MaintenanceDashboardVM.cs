using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class MaintenanceDashboardVM
    {
        [Display(Name = "Total Visits")]
        public int TotalVisits { get; set; }

        [Display(Name = "Scheduled Visits")]
        public int ScheduledVisits { get; set; }

        [Display(Name = "Completed Visits")]
        public int CompletedVisits { get; set; }

        [Display(Name = "In Progress Visits")]
        public int InProgressVisits { get; set; }

        [Display(Name = "Upcoming Visits")]
        public List<MaintenanceVisit> UpcomingVisits { get; set; } = new();

        [Display(Name = "Overdue Visits")]
        public List<MaintenanceVisit> OverdueVisits { get; set; } = new();
    }
}
