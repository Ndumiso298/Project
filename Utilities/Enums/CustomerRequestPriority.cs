using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum CustomerRequestPriority
    {
        [Display(Name = "Low")]
        Low,          // Minor urgency

        [Display(Name = "Medium")]
        Medium,       // Normal urgency

        [Display(Name = "High")]
        High,         // Urgent

        [Display(Name = "Critical")]
        Critical      // Immediate attention required
    }
}
