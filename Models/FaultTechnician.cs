using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FaultTechnician : Employee
    {
        [Display(Name = "Assigned Faults")]
        [ValidateNever]
        public virtual ICollection<FridgeFault> AssignedFaults { get; set; } = new List<FridgeFault>();
    }
}
