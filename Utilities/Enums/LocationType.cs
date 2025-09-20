using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum LocationType
    {
        [Display(Name = "Customer Site")]
        CustomerSite,

        [Display(Name = "Warehouse")]
        Warehouse,

        [Display(Name = "Service Centre")]
        ServiceCentre,

        [Display(Name = "Supplier")]
        Supplier,

        [Display(Name = "Office/Administrative")]
        Office,

        [Display(Name = "Retail Store")]
        RetailStore,

        [Display(Name = "Distribution Center")]
        DistributionCenter
    }
}
