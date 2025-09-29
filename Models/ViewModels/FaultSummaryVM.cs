using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class FaultSummaryVM
    {
        public int Id { get; set; }

        [Display(Name = "Description")]
        public string FaultDescription { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public FaultStatus FaultStatus { get; set; }

        [Display(Name = "Priority")]
        public FaultPriority Priority { get; set; }

        [Display(Name = "Reported Date")]
        public DateTime ReportedDate { get; set; }
    }
}
