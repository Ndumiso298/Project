using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum LocationType
    {
        [Display(Name = "Warehouse")]
        Warehouse,

        [Display(Name = "Distribution Center")]
        DistributionCenter,

        [Display(Name = "Service Center")]
        ServiceCenter,

        [Display(Name = "Office")]
        Office,

        [Display(Name = "Retail Store")]
        RetailStore,

        [Display(Name = "Customer Site")]
        CustomerSite,

        [Display(Name = "Supplier Site")]
        SupplierSite,
    }
}
