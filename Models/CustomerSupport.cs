using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class CustomerSupport
{
    // Customers managed by this liaison
    [Display(Name = "Customers")]
    [ValidateNever]
    public virtual ICollection<Customer> ManagedCustomers { get; set; } = new List<Customer>();

    // Allocations created/overseen
    [Display(Name = "Fridge Allocations")]
    [ValidateNever]
    public virtual ICollection<Allocation> FridgeAllocations { get; set; } = new List<Allocation>();
}
