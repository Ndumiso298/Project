using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FridgeCondition
    {
        [Display(Name = "New (Unused)")]
        New,

        [Display(Name = "Pre-Owned")]
        PreOwned,

        [Display(Name = "Refurbished")]
        Refurbished,

        [Display(Name = "Poor (Needs Replacement)")]
        Poor // A state that triggers attention but is not a functional status
    }
}