namespace Project.Models.ViewModel
{
    public class FridgeStockVM
    {
        public Fridge FridgeModel { get; set; }
        public int TotalInstances { get; set; }
        public int AvailableInstances { get; set; }
        public int RentedInstances { get; set; }
        public List<FridgeInStock> FridgeInstances { get; set; }
    }

    public class DashboardVM
    {
        public int TotalFridgeModels { get; set; }
        public int TotalFridgeInstances { get; set; }
        public int TotalAvailableInstances { get; set; }
        public int TotalRentedInstances { get; set; }
        public List<FridgeStockVM> FridgeStock { get; set; }
    }
}