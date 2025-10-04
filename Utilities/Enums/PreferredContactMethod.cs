using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum ContactMethod
    {
        [Display(Name = "Phone Call")]
        Phone,

        [Display(Name = "Email")]
        Email,

        [Display(Name = "SMS")]
        SMS
    }
}
