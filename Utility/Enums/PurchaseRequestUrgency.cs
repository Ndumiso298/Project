using System.ComponentModel.DataAnnotations;

namespace Project.Utility.Enums
{
    public enum PurchaseRequestUrgency
    {
        [Display(Name = "Low")]
        Low,              // Nice to have, no rush

        [Display(Name = "Medium")]
        Medium,           // Normal business need

        [Display(Name = "High")]
        High,             // Needed soon, priority

        [Display(Name = "Urgent")]
        Urgent,           // Needed within 1-2 days

        [Display(Name = "Critical")]
        Critical          // Emergency, immediate attention
    }
}
