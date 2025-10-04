using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum ServicingType
    {
        [Display(Name = "Preventive Maintenance")]
        PreventiveMaintenance,

        [Display(Name = "Corrective Repair")]
        CorrectiveRepair,

        [Display(Name = "Installation")]
        Installation,

        [Display(Name = "Inspection")]
        Inspection
    }
}
