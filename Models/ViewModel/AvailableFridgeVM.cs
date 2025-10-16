namespace Project.Models.ViewModel
{
    public class AvailableFridgeVM
    {
        public int FridgeInStockId { get; set; }
        public string FridgeNo { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int CapacityLiters { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double RentalPricePerMonth { get; set; }
        public string ImageUrl { get; set; }
        public string Condition { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public string Location { get; set; }
    }
}