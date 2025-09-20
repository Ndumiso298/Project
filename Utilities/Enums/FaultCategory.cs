using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FaultCategory
    {
        [Display(Name = "Cooling Issue")]
        Cooling,

        [Display(Name = "Electrical")]
        Electrical,

        [Display(Name = "Mechanical")]
        Mechanical,

        [Display(Name = "Noise")]
        Noise,

        [Display(Name = "Door/Seal")]
        DoorSeal,

        [Display(Name = "Display/Controls")]
        DisplayControls,

        [Display(Name = "Water Dispenser")]
        WaterDispenser,

        [Display(Name = "Ice Maker")]
        IceMaker,

        [Display(Name = "Other")]
        Other
    }
}
