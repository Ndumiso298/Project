using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Models.FridgeManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class CustomerSupport : Employee
    {
        // Customers managed by this liaison
        [Display(Name = "Customers")]
        [ValidateNever]
        public virtual ICollection<Customer> ManagedCustomers { get; set; } = new List<Customer>();

        // Allocations created/overseen
        [Display(Name = "Fridge Allocations")]
        [ValidateNever]
        public virtual ICollection<FridgeAllocation> FridgeAllocations { get; set; } = new List<FridgeAllocation>();
    }
}
