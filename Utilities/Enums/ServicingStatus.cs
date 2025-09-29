using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum ServicingStatus
    {
        [Display(Name = "Pending Assignment")]
        PendingAssignment,

        [Display(Name = "Scheduled")]
        Scheduled,

        [Display(Name = "In Progress")]
        InProgress,

        [Display(Name = "On Hold")]
        OnHold,

        [Display(Name = "Rescheduled")]
        Rescheduled,

        [Display(Name = "Follow-up Required")]
        FollowUpRequired,

        [Display(Name = "Completed")]
        Completed,

        [Display(Name = "Cancelled")]
        Cancelled,

        [Display(Name = "Closed")]
        Closed
    }
}
