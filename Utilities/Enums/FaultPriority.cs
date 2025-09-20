using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FaultPriority
    {
        [Display(Name = "Low")]
        Low,                // Minor issue, no immediate impact

        [Display(Name = "Medium")]
        Medium,             // Moderate issue, some impact on operation

        [Display(Name = "High")]
        High,               // Significant issue, major impact on operation

        [Display(Name = "Critical")]
        Critical,           // Emergency situation, complete failure
    }
}
