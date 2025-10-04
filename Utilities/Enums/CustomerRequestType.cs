using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum CustomerRequestType
    {
        [Display(Name = "Full Replacement")]
        FullReplacement,

        [Display(Name = "Partial Replacement")]
        PartialReplacement,

        [Display(Name = "Temporary Replacement")]
        TemporaryReplacement,

        [Display(Name = "Upgrade")]
        Upgrade,

        [Display(Name = "Emergency Replacement")]
        EmergencyReplacement
    }
}
