using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum AllocationStatus
    {
        [Display(Name = "Pending")]
        Pending,           // Allocation created but not yet active

        [Display(Name = "Active")]
        Active,            // Fridge is currently allocated to customer

        [Display(Name = "Suspended")]
        Suspended,         // Temporary suspension of allocation

        [Display(Name = "Completed")]
        Completed,         // Allocation period ended successfully

        [Display(Name = "Cancelled")]
        Cancelled,         // Allocation was cancelled before activation

        [Display(Name = "Terminated")]
        Terminated,        // Allocation ended prematurely

        [Display(Name = "Expired")]
        Expired
    }
}
