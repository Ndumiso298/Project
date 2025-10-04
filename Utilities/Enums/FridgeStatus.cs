using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FridgeStatus
    {
        [Display(Name = "Available")]
        Available,            // In warehouse, ready for allocation

        [Display(Name = "Allocated")]
        Allocated,            // Currently with a customer

        [Display(Name = "Under Maintenance")]
        UnderMaintenance,     // Being serviced or repaired

        [Display(Name = "Faulty")]
        Faulty,               // Has reported fault, needs attention

        [Display(Name = "In Transit")]
        InTransit,            // Being moved between locations

        [Display(Name = "Quarantined")]
        Quarantined,          // Temporarily held for inspection

        [Display(Name = "Scrapped")]
        Scrapped,             // Marked for disposal

        [Display(Name = "Lost/Stolen")]
        LostStolen            // Missing inventory
    }
}
