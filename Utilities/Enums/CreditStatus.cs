using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum CreditStatus
    {
        [Display(Name = "Good Standing")]
        Good,

        [Display(Name = "Credit Watch")]
        Watch,

        [Display(Name = "Account Hold")]
        Hold,

        [Display(Name = "Blocked (No Transactions)")]
        Blocked
    }
}
