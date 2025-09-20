using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum RequestPriority
    {
        [Display(Name = "Low")]
        Low,

        [Display(Name = "Medium")]
        Medium,

        [Display(Name = "High")]
        High,

        [Display(Name = "Critical")]
        Critical
    }
}
