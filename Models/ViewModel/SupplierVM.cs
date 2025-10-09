using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class SupplierVM
    {
        public int SupplierId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // For dropdowns
        public int LocationId { get; set; }
        public string LocationDisplay { get; set; }

        // Optional: list of fridge models they supply
        public List<int> SelectedFridgeIds { get; set; }
        public IEnumerable<SelectListItem> AvailableFridges { get; set; }
    }
}