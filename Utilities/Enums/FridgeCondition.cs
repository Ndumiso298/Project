using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FridgeCondition
    {
        [Display(Name = "Excellent")]
        Excellent,         // Like new, fully functional

        [Display(Name = "Good")]
        Good,              // Minor wear, fully functional

        [Display(Name = "Fair")]
        Fair,              // Visible wear, needs monitoring

        [Display(Name = "Poor")]
        Poor               // Needs repair or replacement
    }
}