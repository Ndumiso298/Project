using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum CustomerRequestStatus
    {
        [Display(Name = "Draft")]
        Draft,

        [Display(Name = "Submitted")]
        Submitted,

        [Display(Name = "Under Review")]
        UnderReview,

        [Display(Name = "Additional Info Required")]
        AdditionalInfoRequired,

        [Display(Name = "Approved")]
        Approved,

        [Display(Name = "In Progress")]
        InProgress,

        [Display(Name = "Completed")]
        Completed,

        [Display(Name = "Rejected")]
        Rejected,

        [Display(Name = "Cancelled")]
        Cancelled
    }
}
