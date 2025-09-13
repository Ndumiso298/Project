using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using Project.Models.FridgeManagementSystem.Models;

namespace Project.Models.ViewModels
{
    public class CustomerManagementVM
    {
        public Customer Customer { get; set; }
        public string CurrentRole { get; set; }

        // Additional properties for comprehensive management
        public List<FridgeAllocation> ActiveAllocations { get; set; }
        public List<FridgeFault> RecentFaults { get; set; }
        public List<FridgeMaintenance> UpcomingMaintenance { get; set; }

        // For role management (if needed)
        public IEnumerable<SelectListItem> AvailableRoles { get; set; }
        public string SelectedRole { get; set; }

        // For statistics/overview
        public int TotalAllocations { get; set; }
        public int ActiveFridges { get; set; }
        public int ResolvedFaults { get; set; }
    }
}
