using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum AllocationStatus
    {
        [Display(Name = "Pending")]
        Pending,           // Request submitted, awaiting approval

        [Display(Name = "Active")]
        Active,            // Fridge is currently allocated to customer

        [Display(Name = "Suspended")]
        Suspended,         // Temporary suspension (non-payment, maintenance)

        [Display(Name = "Completed")]
        Completed,         // Allocation ended successfully

        [Display(Name = "Cancelled")]
        Cancelled,          // Allocation was cancelled

        [Display(Name = "Faulty")]
        Faulty
    }
}
