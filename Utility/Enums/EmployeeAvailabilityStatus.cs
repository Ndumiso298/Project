using System.ComponentModel.DataAnnotations;

namespace Project.Utility.Enums
{
    public enum EmployeeAvailabilityStatus
    {
        [Display(Name = "Available")]
        Available,

        [Display(Name = "On Duty")]
        OnDuty,

        [Display(Name = "On Break")]
        OnBreak,

        [Display(Name = "On Leave")]
        OnLeave,

        [Display(Name = "Sick Leave")]
        SickLeave,

        [Display(Name = "Training")]
        Training,

        [Display(Name = "Unavailable")]
        Unavailable
    }
}
