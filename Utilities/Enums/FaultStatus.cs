using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FaultStatus
    {
        [Display(Name = "Reported")]
        Reported,           // Initial fault report from customer

        [Display(Name = "Assigned")]
        Assigned,           // Assigned to technician for investigation

        [Display(Name = "In Progress")]
        InProgress,         // Technician actively working on resolution

        [Display(Name = "Parts Required")]
        PartsRequired,      // Waiting for replacement parts

        [Display(Name = "Resolved")]
        Resolved,           // Fault has been successfully repaired

        [Display(Name = "Reopened")]
        Reopened,           // Fault recurred after resolution

        [Display(Name = "Closed")]
        Closed              // Case completed and verified
    }
}
