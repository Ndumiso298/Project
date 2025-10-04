using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class ReplacementRequestVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fridge allocation is required.")]
        [Display(Name = "Fridge Allocation *")]
        public int FridgeAllocationId { get; set; }
        public IEnumerable<SelectListItem>? FridgeAllocationList { get; set; }

        [Display(Name = "Related Fault Record")]
        public int? FaultRecordId { get; set; }
        public IEnumerable<SelectListItem>? FaultRecordList { get; set; }

        [Required(ErrorMessage = "Request type is required.")]
        [Display(Name = "Request Type *")]
        public CustomerRequestType RequestType { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
        [Display(Name = "Reason *")]
        public string Reason { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        [Display(Name = "Quantity *")]
        public int Quantity { get; set; } = 1;

        [Required(ErrorMessage = "Priority is required.")]
        [Display(Name = "Priority *")]
        public RequestPriority Priority { get; set; } = RequestPriority.Medium;

        [Required(ErrorMessage = "Requested date is required.")]
        [Display(Name = "Requested Date *")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Status")]
        public CustomerRequestStatus Status { get; set; } = CustomerRequestStatus.Draft;

        [Display(Name = "Assigned Employee")]
        public int? AssignedEmployeeId { get; set; }
        public IEnumerable<SelectListItem>? EmployeeList { get; set; }

        [StringLength(500, ErrorMessage = "Response notes cannot exceed 500 characters.")]
        [Display(Name = "Response Notes")]
        public string? ResponseNotes { get; set; }

        // For dropdowns
        public IEnumerable<SelectListItem>? RequestTypeList { get; set; }
        public IEnumerable<SelectListItem>? PriorityList { get; set; }
        public IEnumerable<SelectListItem>? StatusList { get; set; }
    }
}
