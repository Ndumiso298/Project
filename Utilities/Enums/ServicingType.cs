using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum ServicingType
    {
        [Display(Name = "Preventive Maintenance")]
        PreventiveMaintenance,

        [Display(Name = "Corrective Maintenance")]
        CorrectiveMaintenance,

        [Display(Name = "Installation")]
        Installation,

        [Display(Name = "Inspection")]
        Inspection
    }
}
