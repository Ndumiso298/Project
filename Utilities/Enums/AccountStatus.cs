using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Project.Utilities.Enums
{
    public enum AccountStatus
    {
        [Display(Name = "Pending Approval")]
        PendingApproval,

        [Display(Name = "Approved")]
        Approved,

        [Display(Name = "Rejected")]
        Rejected,

        [Display(Name = "Deactivated")]
        Deactivated,

        [Display(Name = "Locked")]
        Locked
    }
}
