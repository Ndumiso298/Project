using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class DeallocationVM
    {
        public int AllocationId { get; set; }

        [Display(Name = "Fridge Serial Number")]
        public string FridgeSerialNumber { get; set; } = string.Empty;

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        [Display(Name = "Allocation Date")]
        public DateTime AllocationDate { get; set; }

        [Required]
        [Display(Name = "Deallocation Date")]
        public DateTime DeallocationDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Deallocation Reason")]
        public string DeallocationReason { get; set; } = string.Empty;
    }
}
