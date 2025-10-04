using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum AvailabilityStatus
    {
        [Display(Name = "Available")]
        Available,

        [Display(Name = "Busy")]
        Busy,

        [Display(Name = "On Leave")]
        OnLeave,

        [Display(Name = "Unavailable")]
        Unavailable
    }
}
