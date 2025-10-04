using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project.Utilities.Enums;

namespace Project.Models.ViewModels
{
    public class FaultDashboardVM
    {
        // ===== OVERVIEW STATISTICS =====
        [Display(Name = "Total Faults")]
        public int TotalFaults { get; set; }

        [Display(Name = "Open Faults")]
        public int OpenFaults { get; set; }

        [Display(Name = "Resolved Faults")]
        public int ResolvedFaults { get; set; }

        [Display(Name = "High Priority Faults")]
        public int HighPriorityFaults { get; set; }

        [Display(Name = "Critical Severity Faults")]
        public int CriticalSeverityFaults { get; set; }

        // ===== REPLACEMENT METRICS =====
        [Display(Name = "Faults Requiring Replacement")]
        public int FaultsRequiringReplacement { get; set; }

        [Display(Name = "Replacement Requests Created")]
        public int ReplacementRequestsCreated { get; set; }

        [Display(Name = "Pending Replacements")]
        public int PendingReplacements { get; set; }

        // ===== PERFORMANCE METRICS =====
        [Display(Name = "Unassigned Faults")]
        public int UnassignedFaults { get; set; }

        [Display(Name = "Faults This Week")]
        public int FaultsThisWeek { get; set; }

        [Display(Name = "Faults Last Week")]
        public int FaultsLastWeek { get; set; }

        [Display(Name = "Week-over-Week Change")]
        public int WeekOverWeekChange => FaultsThisWeek - FaultsLastWeek;

        [Display(Name = "Average Resolution Time (hrs)")]
        public double AverageResolutionTimeHours { get; set; }

        [Display(Name = "Average Response Time (hrs)")]
        public double AverageResponseTimeHours { get; set; }

        // ===== COMPUTED PROPERTIES =====
        [NotMapped]
        [Display(Name = "Resolution Rate")]
        public double ResolutionRate => TotalFaults == 0 ? 0 : (double)ResolvedFaults / TotalFaults * 100;

        [NotMapped]
        [Display(Name = "High Priority %")]
        public double HighPriorityPercentage => TotalFaults == 0 ? 0 : (double)HighPriorityFaults / TotalFaults * 100;

        [NotMapped]
        [Display(Name = "Critical Severity %")]
        public double CriticalSeverityPercentage => TotalFaults == 0 ? 0 : (double)CriticalSeverityFaults / TotalFaults * 100;

        [NotMapped]
        [Display(Name = "Replacement Rate")]
        public double ReplacementRate => TotalFaults == 0 ? 0 : (double)FaultsRequiringReplacement / TotalFaults * 100;

        [NotMapped]
        [Display(Name = "Week-over-Week Trend")]
        public string WeekOverWeekTrend => WeekOverWeekChange > 0 ? "up" : WeekOverWeekChange < 0 ? "down" : "stable";

        [NotMapped]
        [Display(Name = "Trend Badge Class")]
        public string TrendBadgeClass => WeekOverWeekTrend switch
        {
            "up" => "bg-danger",
            "down" => "bg-success",
            _ => "bg-secondary"
        };

        // ===== RECENT DATA =====
        [Display(Name = "Recent Faults")]
        public List<FaultSummaryVM> RecentFaults { get; set; } = new();

        [Display(Name = "Critical Faults")]
        public List<FaultSummaryVM> CriticalFaults { get; set; } = new();

        [Display(Name = "Faults by Category")]
        public Dictionary<FaultCategory, int> FaultsByCategory { get; set; } = new();

        [Display(Name = "Faults by Priority")]
        public Dictionary<FaultPriority, int> FaultsByPriority { get; set; } = new();

        [Display(Name = "Technician Performance")]
        public List<TechnicianPerformanceVM> TechnicianPerformance { get; set; } = new();

        // ===== CHART DATA =====
        [Display(Name = "Weekly Trends")]
        public List<WeeklyTrendVM> WeeklyTrends { get; set; } = new();
    }

    public class TechnicianPerformanceVM
    {
        public string TechnicianName { get; set; } = string.Empty;
        public int AssignedFaults { get; set; }
        public int ResolvedFaults { get; set; }
        public double AverageResolutionTime { get; set; }
        public double ResolutionRate => AssignedFaults == 0 ? 0 : (double)ResolvedFaults / AssignedFaults * 100;
    }

    public class WeeklyTrendVM
    {
        public string Week { get; set; } = string.Empty;
        public int ReportedFaults { get; set; }
        public int ResolvedFaults { get; set; }
        public int ReplacementFaults { get; set; }
    }
}
