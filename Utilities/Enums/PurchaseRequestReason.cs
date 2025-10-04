using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum PurchaseRequestReason
    {
        [Display(Name = "Low Stock")]
        LowStock,
        [Display(Name = "New Customer Demand")]
        NewCustomer,
        [Display(Name = "Replace Faulty Units")]
        Replacement,
        [Display(Name = "Seasonal Demand Increase")]
        Seasonal,
        [Display(Name = "Upgrade Inventory")]
        Upgrade,
        [Display(Name = "Other")]
        Other
    }
}
