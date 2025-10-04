using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum PurchaseRequestUrgency
    {
        [Display(Name = "Low")]
        Low,
        [Display(Name = "Normal")]
        Normal,
        [Display(Name = "High")]
        High,
        [Display(Name = "Critical")]
        Critical
    }
}
