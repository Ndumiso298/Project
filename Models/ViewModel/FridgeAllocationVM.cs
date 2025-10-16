namespace Project.Models.ViewModel
{
    public class FridgeAllocationVM
    {
        public int RequestHeaderId { get; set; }
        public string CustomerName { get; set; }
        public List<int> SelectedFridgeIds { get; set; }
        public List<AvailableFridgeVM> AvailableFridges { get; set; }
    }
}