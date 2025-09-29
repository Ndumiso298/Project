using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum DeallocationReason
    {
        [Display(Name = "Select a reason...")]
        None,

        [Display(Name = "Contract Completed")]
        ContractCompleted,

        [Display(Name = "Customer Request")]
        CustomerRequest,

        [Display(Name = "Fridge Faulty")]
        FridgeFaulty,

        [Display(Name = "Customer Business Closed")]
        BusinessClosed,

        [Display(Name = "Relocation")]
        Relocation,

        [Display(Name = "Non-Payment")]
        NonPayment,

        [Display(Name = "Upgrade to New Model")]
        Upgrade,

        [Display(Name = "Seasonal Requirements Ended")]
        Seasonal,

        [Display(Name = "Other")]
        Other
    }
}
