using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class PurchaseRequestVM
    {
        public int Id { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? FridgeModelList { get; set; }

        [Required]
        [Display(Name = "Requested By")]
        public int RequestedById { get; set; }

        public IEnumerable<SelectListItem>? EmployeeList { get; set; }

        [Required]
        [Display(Name = "Status")]
        public PurchaseRequestStatus Status { get; set; } = PurchaseRequestStatus.Draft;
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        [Required]
        [Display(Name = "Reason")]
        public PurchaseRequestReason Reason { get; set; } = PurchaseRequestReason.LowStock;
        public IEnumerable<SelectListItem>? ReasonList { get; set; }

        [Display(Name = "Custom Reason")]
        [StringLength(200)]
        public string? CustomReason { get; set; }

        [Required]
        [Display(Name = "Urgency")]
        public PurchaseRequestUrgency Urgency { get; set; } = PurchaseRequestUrgency.Medium;
        public IEnumerable<SelectListItem>? UrgencyList { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Required By Date")]
        public DateTime RequiredByDate { get; set; } = DateTime.UtcNow.AddDays(7);

        [Display(Name = "Estimated Total Cost (R)")]
        [DataType(DataType.Currency)]
        public decimal? EstimatedTotalCost { get; set; }

        [Display(Name = "Approved Budget (R)")]
        [DataType(DataType.Currency)]
        public decimal? ApprovedBudget { get; set; }

        public List<PurchaseRequestItemVM> Items { get; set; } = new();
    }
}
