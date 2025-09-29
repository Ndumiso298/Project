using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FridgeStatus
    {
        [Display(Name = "Available (Warehouse Stock)")]
        Available,            // In a Location/Warehouse, ready for allocation

        [Display(Name = "Pending Allocation")]
        PendingAllocation,    // Requested by customer, awaiting Inventory Liaison approval

        [Display(Name = "Allocated (Customer Site)")]
        Allocated,            // Currently with a customer

        [Display(Name = "In Service / Repair")] // Clearer name for technician work
        InService,            // Repair or maintenance (used by Fault/Maintenance Techs)

        [Display(Name = "In Transit")]
        InTransit,            // Being moved between locations or to/from customer

        [Display(Name = "Quality Control")]
        QualityControl,       // Being inspected after service/repair

        [Display(Name = "Quarantined (Blocked)")]
        Quarantined,          // Temporarily held for investigation (e.g., failed QC)

        [Display(Name = "Scrapped")]
        Scrapped,             // Marked for disposal (Soft Delete equivalent for Inventory)

        [Display(Name = "Lost/Stolen")]
        LostStolen            // Missing inventory
    }
}
