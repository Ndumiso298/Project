using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum CustomerRequestStatus
    {
        [Display(Name = "Draft")]
        Draft, // Customer is still composing the request

        [Display(Name = "Submitted")]
        Submitted, // Customer has submitted the request for review

        [Display(Name = "Under Review")]
        UnderReview, // Customer liaison is reviewing the request

        [Display(Name = "Additional Info Required")]
        AdditionalInfoRequired, // More details needed from customer

        [Display(Name = "Approved")]
        Approved, // Request has been approved, replacement being processed

        [Display(Name = "Replacement Scheduled")]
        ReplacementScheduled, // AssignedTechnician visit scheduled

        [Display(Name = "In Progress")]
        InProgress, // Replacement process has begun

        [Display(Name = "Completed")]
        Completed, // Replacement successfully fulfilled

        [Display(Name = "Partially Completed")]
        PartiallyCompleted, // Some but not all items replaced

        [Display(Name = "Rejected")]
        Rejected, // Request was denied

        [Display(Name = "Cancelled")]
        Cancelled, // Customer cancelled the request

        [Display(Name = "On Hold")]
        OnHold // Request paused temporarily
    }
}
