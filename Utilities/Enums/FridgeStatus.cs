using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FridgeStatus
    {
        [Display(Name = "Available")]
        Available,           // In warehouse, ready for allocation

        [Display(Name = "Allocated")]
        Allocated,           // Currently with a customer

        [Display(Name = "In Transit")]
        InTransit,           // Being moved between locations

        [Display(Name = "In Repair")]
        InRepair,            // At service center for repairs

        [Display(Name = "Under Maintenance")]
        UnderMaintenance,    // Scheduled maintenance/service

        [Display(Name = "Quality Control")]
        QualityControl,      // Being inspected after repair/service

        [Display(Name = "Quarantined")]
        Quarantined,         // Temporarily held for investigation

        [Display(Name = "Reserved")]
        Reserved,            // Allocated but not yet deployed

        [Display(Name = "Scrapped")]
        Scrapped,            // Decommissioned and ready for disposal

        [Display(Name = "Lost/Stolen")]
        LostStolen           // Missing inventory
    }
}
