using System.ComponentModel.DataAnnotations;

namespace Project.Utility.Enums
{
    public enum PurchaseRequestStatus
    {
        [Display(Name = "Draft")]
        Draft,                 // Being prepared, not yet submitted

        [Display(Name = "Submitted")]
        Submitted,             // Sent for review but not yet processed

        [Display(Name = "Under Review")]
        UnderReview,           // Currently being reviewed

        [Display(Name = "Approved")]
        Approved,              // Approved and ready to order

        [Display(Name = "Rejected")]
        Rejected,              // Denied, won’t move forward

        [Display(Name = "On Hold")]
        OnHold,                // Paused temporarily

        [Display(Name = "Ordered")]
        Ordered,               // Order placed with supplier

        [Display(Name = "Partially Fulfilled")]
        PartiallyFulfilled,    // Some items delivered

        [Display(Name = "Fulfilled")]
        Fulfilled,             // Fully delivered

        [Display(Name = "Cancelled")]
        Cancelled,             // Cancelled before order/fulfillment

        [Display(Name = "Closed")]
        Closed                 // Archived/finalized state
    }
}
