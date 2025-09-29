using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum CustomerRequestType
    {
        [Display(Name = "New Allocation")]
        NewAllocation,

        [Display(Name = "Replacement")]
        Replacement,

        [Display(Name = "Additional Units")]
        AdditionalUnits,

        [Display(Name = "Temporary Allocation")]
        TemporaryAllocation
    }
}
