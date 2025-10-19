namespace Project.Models.ViewModel
{
    public class FridgeAssignmentVM
    {
        public int RequestDetailId { get; set; }
        public int FridgeId { get; set; }
        public string FridgeModel { get; set; }
        public int RequestedQuantity { get; set; }
        public List<FridgeInStock> AvailableFridges { get; set; }
        public List<int> SelectedFridgeIds { get; set; }
        //public string? Notes { get; set; } 
    }
}