using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class FaultDashboardVM
    {
        [Display(Name = "Total Faults")]
        public int TotalFaults { get; set; }

        [Display(Name = "Open Faults")]
        public int OpenFaults { get; set; }

        [Display(Name = "Resolved Faults")]
        public int ResolvedFaults { get; set; }

        [Display(Name = "High Priority Faults")]
        public int HighPriorityFaults { get; set; }

        [NotMapped]
        [Display(Name = "High Priority %")]
        public double HighPriorityPercentage =>
            TotalFaults == 0 ? 0 : (double)HighPriorityFaults / TotalFaults * 100;

        [Display(Name = "Recent Faults")]
        public List<FaultSummaryVM> RecentFaults { get; set; } = new();

        [Display(Name = "Faults This Week")]
        public int FaultsThisWeek { get; set; }

        [Display(Name = "Faults Last Week")]
        public int FaultsLastWeek { get; set; }

        [Display(Name = "Average Resolution Time (hrs)")]
        public double AverageResolutionTimeHours { get; set; }

        [Display(Name = "Unassigned Faults")]
        public int UnassignedFaults { get; set; }
    }
}
