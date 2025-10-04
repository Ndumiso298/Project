using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FridgeModelStatus
    {
        [Display(Name = "Active")]
        Active,            // Available for allocation and purchase

        [Display(Name = "Inactive")]
        Inactive,          // Not available for new allocations

        [Display(Name = "Discontinued")]
        Discontinued       // No longer supported or manufactured
    }
}
