using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum AllocationRequestStatus
    {
        [Display(Name = "Draft")]
        Draft,

        [Display(Name = "Submitted")]
        Submitted,

        [Display(Name = "Under Review")]
        UnderReview,

        [Display(Name = "Approved")]
        Approved,

        [Display(Name = "Waiting For Payment")]
        WaitingForPayment,

        [Display(Name = "Paid")]
        Paid,

        [Display(Name = "Completed")]
        Completed,

        [Display(Name = "Rejected")]
        Rejected,

        [Display(Name = "Cancelled")]
        Cancelled
    }
}
