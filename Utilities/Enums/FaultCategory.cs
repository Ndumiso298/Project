using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FaultCategory
    {
        [Display(Name = "Cooling Issue")]
        Cooling,            // Problems with refrigeration or temperature control

        [Display(Name = "Electrical")]
        Electrical,         // Electrical faults like wiring, fuses, or power issues

        [Display(Name = "Mechanical")]
        Mechanical,         // Mechanical failures such as motors, fans, compressors

        [Display(Name = "Noise")]
        Noise,              // Excessive or abnormal noise issues

        [Display(Name = "Door/Seal")]
        DoorSeal,           // Faults with door alignment, gaskets, or seals

        [Display(Name = "Display/Controls")]
        DisplayControls,    // Problems with panels, buttons, or digital controls

        [Display(Name = "Water Dispenser")]
        WaterDispenser,     // Issues with water dispensing mechanism

        [Display(Name = "Ice Maker")]
        IceMaker,           // Ice production issues

        [Display(Name = "Other")]
        Other               // Any other fault not categorized above
    }
}
