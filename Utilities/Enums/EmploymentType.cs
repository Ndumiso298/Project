using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum EmploymentType
    {
        [Display(Name = "Full Time")]
        FullTime,

        [Display(Name = "Part Time")]
        PartTime,

        [Display(Name = "Contract")]
        Contract,

        [Display(Name = "Temporary")]
        Temporary
    }
}
