using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class StockController : Employee
    {
        // Capability: Receive new fridges, Scrap fridges
        [InverseProperty("StockController")]
        [Display(Name = "Managed Fridges")]
        [ValidateNever]
        public virtual ICollection<Fridge> ManagedFridges { get; set; } = new List<Fridge>();

        // Capability: Process customer fridge allocation
        [Display(Name = "Processed Fridge Allocations")]
        [ValidateNever]
        public virtual ICollection<FridgeAllocation> ProcessedFridgeAllocations { get; set; } = new List<FridgeAllocation>();

        // Capability: Create purchase request
        [Display(Name = "Created Purchase Requests")]
        [ValidateNever]
        public virtual ICollection<PurchaseRequest> CreatedPurchaseRequests { get; set; } = new List<PurchaseRequest>();
    }
}
