using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum EmployeeType
    {
        [Display(Name = "Administrator")]
        Administrator,

        [Display(Name = "Customer Support")]
        CustomerSupport,

        [Display(Name = "Stock Controller")]
        StockController,

        [Display(Name = "Fault Technician")]
        FaultTechnician,

        [Display(Name = "Maintenance Technician")]
        MaintenanceTechnician
    }
}