using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class MaintenanceTechnician : Employee
    {

        [Display(Name = "Maintenance Management")]
        public virtual ICollection<FridgeMaintenance> ScheduledMaintenances { get; set; } = new List<FridgeMaintenance>();

        [Display(Name = "Fault Management")]
        public virtual ICollection<FridgeFault> FaultReports { get; set; } = new List<FridgeFault>();
    }
}
