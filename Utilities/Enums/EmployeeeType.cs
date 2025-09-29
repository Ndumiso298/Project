using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum EmployeeType
    {
        [Display(Name = "Administrator")]
        Admin,

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