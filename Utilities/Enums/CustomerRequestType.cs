using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum CustomerRequestType
    {
        [Display(Name = "New Allocation")]
        NewAllocation,   // Customer requests a new fridge (initial or additional)

        [Display(Name = "Replacement")]
        Replacement,  // Customer requests a replacement for a faulty fridge

        [Display(Name = "Additional Units")]
        AdditionalUnits,  // Customer requests more fridges of same type

        [Display(Name = "Temporary Loan")]
        Temporary     // Customer requests a temporary fridge while theirs is serviced
    } 
}
