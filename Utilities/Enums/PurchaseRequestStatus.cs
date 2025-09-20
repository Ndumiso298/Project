using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum PurchaseRequestStatus
    {
        [Display(Name = "Draft")]
        Draft,
        [Display(Name = "Submitted")]
        Submitted,
        [Display(Name = "Under Review")]
        UnderReview,
        [Display(Name = "Approved")]
        Approved,
        [Display(Name = "Rejected")]
        Rejected,
        [Display(Name = "Ordered")]
        Ordered,
        [Display(Name = "Partially Fulfilled")]
        PartiallyFulfilled,
        [Display(Name = "Fulfilled")]
        Fulfilled,
        [Display(Name = "Cancelled")]
        Cancelled
    }
}
