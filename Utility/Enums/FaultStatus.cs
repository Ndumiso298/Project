using System.ComponentModel.DataAnnotations;

namespace Project.Utility.Enums
{
    public enum FaultStatus
    {
        [Display(Name = "Reported")]
        Reported,           // Customer has reported the fault

        [Display(Name = "Acknowledged")]
        Acknowledged,       // Support team has acknowledged the report

        [Display(Name = "Diagnosing")]
        Diagnosing,         // Assigned technician is diagnosing the issue

        [Display(Name = "Scheduled")]
        Scheduled,          // Repair has been scheduled

        [Display(Name = "In Progress")]
        InProgress,         // Repair work has started

        [Display(Name = "Parts Required")]
        PartsRequired,      // Waiting for parts to arrive

        [Display(Name = "Resolved")]
        Resolved,           // Fault has been fixed

        [Display(Name = "Cannot Repair")]
        CannotRepair,       // Fault cannot be repaired; replacement needed

        [Display(Name = "Closed")]
        Closed,             // Case is fully closed (after customer confirmation)

        [Display(Name = "Reopened")]
        Reopened            // Customer reported issue after resolution

    }
}
