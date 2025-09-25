using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class FridgeAllocationVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }
        public IEnumerable<SelectListItem>? FridgeList { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public IEnumerable<SelectListItem>? CustomerList { get; set; }

        [Required]
        [Display(Name = "Allocation Date")]
        public DateTime AllocationDate { get; set; }

        [Required]
        [Display(Name = "Allocation Location")]
        public int AllocationLocationId { get; set; }
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        [Display(Name = "Deallocation Date")]
        public DateTime? DeallocationDate { get; set; }

        [Display(Name = "Deallocation Reason")]
        public string? DeallocationReason { get; set; }

        [Display(Name = "Allocated By")]
        public int? AllocatedByEmployeeId { get; set; }
        public IEnumerable<SelectListItem>? EmployeeList { get; set; }

        [Display(Name = "Processed By")]
        public int? ProcessedByEmployeeId { get; set; }

        public AllocationRequestHeader RequestHeader { get; set; }
        public AllocationRequestDetail RequestFridgeNo { get; set; }
        public IEnumerable<AllocationRequestDetail> RequestDetails { get; set; }
        public IEnumerable<FridgeAllocation> AllocationList { get; set; }
        //[ValidateNever]
        //public IEnumerable<SelectListItem> FridgeList { get; set; }
    }
}
