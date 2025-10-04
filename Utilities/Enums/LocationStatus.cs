using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum LocationStatus
    {
        [Display(Name = "Approved")]
        Active,

        [Display(Name = "Inactive")]
        Inactive,

        [Display(Name = "Decommissioned")]
        Decommissioned
    }
}
