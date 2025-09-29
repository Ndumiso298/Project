using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Project.Utilities.Enums
{
    public enum AccountStatus
    {
        [Display(Name = "Pending Approval")]
        PendingApproval,

        [Display(Name = "Active")]
        Active,

        [Display(Name = "Suspended")]
        Suspended,

        [Display(Name = "Deactivated")]
        Deactivated,

        [Display(Name = "Locked")]
        Locked
    }
}
