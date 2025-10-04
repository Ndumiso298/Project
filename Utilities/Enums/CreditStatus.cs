using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum CreditStatus
    {
        [Display(Name = "Pending Assessment")]
        Pending,

        [Display(Name = "Good Standing")]
        Good,

        [Display(Name = "Limited Credit")]
        Limited,

        [Display(Name = "Suspended Credit")]
        Suspended,

        [Display(Name = "Overdue Account")]
        Overdue,

        [Display(Name = "Blacklisted")]
        Blacklisted
    }
}
