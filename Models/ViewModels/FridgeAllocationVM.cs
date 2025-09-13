using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models.FridgeManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class FridgeAllocationVM
    {
        public int Id { get; set; }  // For edit scenarios

        [Required(ErrorMessage = "Fridge selection is required")]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }

        [Required(ErrorMessage = "Customer selection is required")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer Liaison selection is required")]
        [Display(Name = "Customer Liaison")]
        public int CustomerLiaisonId { get; set; }

        [Required(ErrorMessage = "Allocation date is required")]
        [Display(Name = "Allocation Date")]
        [DataType(DataType.Date)]
        public DateTime AllocationDate { get; set; } = DateTime.Today;

        [Display(Name = "Expected Return Date")]
        [DataType(DataType.Date)]
        [DateRangeValidation(ErrorMessage = "Expected return date must be after allocation date")]
        public DateTime? ExpectedReturnDate { get; set; }

        [Required(ErrorMessage = "Service interval is required")]
        [Display(Name = "Service Interval (months)")]
        [Range(1, 24, ErrorMessage = "Service interval must be between 1 and 24 months")]
        public int ServiceIntervalMonths { get; set; } = 6;  // Default value

        [Display(Name = "Notes")]
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string Notes { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Pending";  // Default status

        // For dropdowns
        public List<SelectListItem> AvailableFridges { get; set; }
        public List<SelectListItem> ActiveCustomers { get; set; }
        public List<SelectListItem> CustomerLiaisons { get; set; }

        // Navigation properties for display purposes (optional)
        public Fridge Fridge { get; set; }
        public Customer Customer { get; set; }
        public Employee CustomerLiaison { get; set; }
    }

    // Custom validation attribute for date range
    public class DateRangeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (FridgeAllocationVM)validationContext.ObjectInstance;

            if (value is DateTime expectedReturnDate && expectedReturnDate <= model.AllocationDate)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}

