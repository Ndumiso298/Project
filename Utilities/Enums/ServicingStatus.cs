using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum ServicingStatus
    {
        [Display(Name = "Scheduled")]
        Scheduled,

        [Display(Name = "In Progress")]
        InProgress,

        [Display(Name = "Completed")]
        Completed,

        [Display(Name = "Rescheduled")]
        Rescheduled,

        [Display(Name = "On Hold")]
        OnHold,

        [Display(Name = "Follow-up Required")]
        FollowUpRequired
    }
}
