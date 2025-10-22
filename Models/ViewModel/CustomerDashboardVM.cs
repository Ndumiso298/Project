using Project.Models;

namespace Project.Models.ViewModel
{
    public class CustomerDashboardVM
    {
        public Customer Customer { get; set; }
        public List<CustomerFridge> ActiveFridges { get; set; }
        public List<FaultReport> RecentFaults { get; set; }
        public int PendingRequests { get; set; }
    }
}