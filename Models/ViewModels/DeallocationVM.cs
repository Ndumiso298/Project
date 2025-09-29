using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Helpers;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class DeallocationVM
    {
        public int AllocationId { get; set; }

        // Allocation Information
        [Display(Name = "Fridge Serial Number")]
        public string FridgeSerialNumber { get; set; } = string.Empty;

        [Display(Name = "Fridge Model")]
        public string FridgeModel { get; set; } = string.Empty;

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; } = string.Empty;

        [Display(Name = "Business Type")]
        public BusinessType CustomerBusinessType { get; set; }

        [Display(Name = "Allocation Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime AllocationDate { get; set; }

        [Display(Name = "Monthly Rental (R)")]
        [DataType(DataType.Currency)]
        public decimal MonthlyRental { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; } = 1;

        // Deallocation Information
        [Required(ErrorMessage = "Deallocation date is required.")]
        [Display(Name = "Deallocation Date *")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [DateGreaterThan("AllocationDate", ErrorMessage = "Deallocation date must be after allocation date.")]
        public DateTime DeallocationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Deallocation reason is required.")]
        [Display(Name = "Deallocation Reason *")]
        public DeallocationReason DeallocationReason { get; set; }

        [Display(Name = "Other Reason Description")]
        [StringLength(500, ErrorMessage = "Reason description cannot exceed 500 characters.")]
        public string? OtherReasonDescription { get; set; }

        [Required(ErrorMessage = "Fridge condition is required.")]
        [Display(Name = "Fridge Condition on Return *")]
        public FridgeCondition ReturnCondition { get; set; }

        [Display(Name = "Condition Notes")]
        [StringLength(1000, ErrorMessage = "Condition notes cannot exceed 1000 characters.")]
        public string? ConditionNotes { get; set; }

        [Display(Name = "Requires Maintenance")]
        public bool RequiresMaintenance { get; set; }

        [Display(Name = "Maintenance Required")]
        [StringLength(500, ErrorMessage = "Maintenance description cannot exceed 500 characters.")]
        public string? MaintenanceRequired { get; set; }

        [Display(Name = "Additional Notes")]
        [StringLength(1000, ErrorMessage = "Additional notes cannot exceed 1000 characters.")]
        public string? AdditionalNotes { get; set; }

        // Processing Information
        [Display(Name = "Processed By")]
        public string? ProcessedByName { get; set; }

        [Display(Name = "Processed By ID")]
        public int? ProcessedById { get; set; }

        [Display(Name = "Processed At")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ProcessedAt { get; set; }

        // Dropdown Lists
        [ValidateNever]
        public IEnumerable<SelectListItem>? DeallocationReasonList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? FridgeConditionList { get; set; }

        // Computed Properties
        [Display(Name = "Original Duration")]
        public string OriginalDuration
        {
            get
            {
                var duration = (DateTime.Now - AllocationDate).Days;
                return $"{duration} days";
            }
        }

        [Display(Name = "Actual Duration")]
        public string ActualDuration
        {
            get
            {
                var duration = (DeallocationDate - AllocationDate).Days;
                return $"{duration} days";
            }
        }

        [Display(Name = "Total Revenue (R)")]
        [DataType(DataType.Currency)]
        public decimal TotalRevenue
        {
            get
            {
                var months = Math.Ceiling((DeallocationDate - AllocationDate).TotalDays / 30.0);
                return MonthlyRental * Quantity * (decimal)Math.Max(1, months);
            }
        }

        [Display(Name = "Is Early Return")]
        public bool IsEarlyReturn
        {
            get
            {
                // Consider return within 30 days as early (adjustable threshold)
                return (DeallocationDate - AllocationDate).Days < 30;
            }
        }

        [Display(Name = "Requires Damage Assessment")]
        public bool RequiresDamageAssessment => ReturnCondition == FridgeCondition.Poor;

        [Display(Name = "Can Be Reallocated")]
        public bool CanBeReallocated => ReturnCondition == FridgeCondition.New ||  ReturnCondition == FridgeCondition.Refurbished;

        [Display(Name = "Should Be Scrapped")]
        public bool ShouldBeScrapped => ReturnCondition == FridgeCondition.Poor;

        // Validation Methods
        public bool IsValid()
        {
            return DeallocationDate >= AllocationDate &&
                   DeallocationReason != DeallocationReason.None &&
                   (DeallocationReason != DeallocationReason.Other ||
                    !string.IsNullOrEmpty(OtherReasonDescription));
        }

        public List<string> GetValidationErrors()
        {
            var errors = new List<string>();

            if (DeallocationDate < AllocationDate)
                errors.Add("Deallocation date cannot be before allocation date");

            if (DeallocationReason == DeallocationReason.None)
                errors.Add("Deallocation reason is required");

            if (DeallocationReason == DeallocationReason.Other && string.IsNullOrEmpty(OtherReasonDescription))
                errors.Add("Other reason description is required when selecting 'Other'");

            if ((ReturnCondition == FridgeCondition.Poor &&
                string.IsNullOrEmpty(ConditionNotes)))
                errors.Add("Condition notes are required when fridge condition is poor or damaged");

            if (RequiresMaintenance && string.IsNullOrEmpty(MaintenanceRequired))
                errors.Add("Maintenance description is required when maintenance is needed");

            return errors;
        }

        public void SetProcessedBy(string processedBy, int processedById)
        {
            ProcessedByName = processedBy;
            ProcessedById = processedById;
            ProcessedAt = DateTime.Now;
        }

        // Mapping method to update allocation entity
        public void ApplyToAllocation(FridgeAllocation allocation)
        {
            allocation.Status = AllocationStatus.Completed;
            allocation.ActualReturnDate = DeallocationDate;
            allocation.IsActive = false;

            // Add deallocation notes
            var deallocationNote = $"\n[Deallocation - {DateTime.Now:dd/MM/yyyy HH:mm}] " +
                                  $"Reason: {DeallocationReason.GetDisplayName()}, " +
                                  $"Condition: {ReturnCondition}, " +
                                  $"Processed by: {ProcessedByName}";

            if (!string.IsNullOrEmpty(AdditionalNotes))
            {
                deallocationNote += $", Notes: {AdditionalNotes}";
            }

            allocation.Notes += deallocationNote;
        }
    }
}
