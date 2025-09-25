namespace Project.Models.ViewModels
{
    public class AllocationCartVM
    {
            public List<FridgeAllocation> Allocations { get; set; } = new();
            public Customer Customer { get; set; } = null!;
            public decimal Total => Allocations.Sum(a => a.Fridge?.RentalPricePerMonth ?? 0);
    }
}
