using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum PurchaseRequestReason
    {
        [Display(Name = "Low Stock")]
        LowStock,

        [Display(Name = "New Customer Demand")]
        NewCustomerDemand,

        [Display(Name = "Replace Faulty Units")]
        ReplacementFaulty,

        [Display(Name = "Replace Obsolete Units")]
        ReplacementObsolete,

        [Display(Name = "Seasonal Demand Increase")]
        Seasonal,

        [Display(Name = "Expansion (New Branch/Market)")]
        Expansion,

        [Display(Name = "Upgrade Inventory")]
        Upgrade,

        [Display(Name = "Emergency Request")]
        Emergency,

        [Display(Name = "Other")]
        Other
    }
}
