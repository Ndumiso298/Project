using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum BusinessType
    {
        // Retail & Food Service
        [Display(Name = "Supermarket / Grocery Store")]
        GroceryRetail = 1,

        [Display(Name = "Small Retail Outlet (Butchery, Bakery, Bottle Store)")]
        SmallRetail = 2,

        [Display(Name = "Restaurant / Café / Takeaway")]
        FoodService = 3,

        // Hospitality
        [Display(Name = "Hospitality (Hotel, Lodge, B&B)")]
        Hospitality = 4,

        [Display(Name = "Catering / Events")]
        Catering = 5,

        // Institutional
        [Display(Name = "Healthcare Facility")]
        Healthcare = 6,

        [Display(Name = "Educational Institution")]
        Education = 7,

        // Business-to-Business
        [Display(Name = "Supplier / Distributor")]
        Supplier = 8,

        // Consumer
        [Display(Name = "Household / Residential")]
        Household = 9,

        // Other
        [Display(Name = "Other")]
        Other = 99
    }
}
