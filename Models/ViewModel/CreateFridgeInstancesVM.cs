using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class CreateFridgeInstancesVM
    {
        public int FridgeId { get; set; }
        public string FridgeModel { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Last maintenance date is required")]
        public DateTime LastMaintenanceDate { get; set; }

        [Required(ErrorMessage = "Condition is required")]
        public string Condition { get; set; }

        public string Location { get; set; }
    }
}