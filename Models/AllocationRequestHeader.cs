using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Project.Utilities.Enums;
using Project.Helpers;

namespace Project.Models
{
    public class AllocationRequestHeader
    {
        public AllocationRequestHeader()
        {
            RequestDate = DateTime.UtcNow;
            Status = AllocationRequestStatus.Draft;
            RequestDetails = new List<AllocationRequestDetail>();
            Allocations = new List<FridgeAllocation>();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            RequestNumber = GenerateRequestNumber();
        }

        [Key]
        [Display(Name = "Request ID")]
        public int Id { get; set; }

        // Request Information
        [Required]
        [StringLength(20)]
        [Display(Name = "Request Number")]
        public string RequestNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Request date is required.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Request Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "Request type is required.")]
        [Display(Name = "Request Type")]
        public CustomerRequestType RequestType { get; set; } = CustomerRequestType.NewAllocation;

        [Required(ErrorMessage = "Priority is required.")]
        [Display(Name = "Priority")]
        public CustomerRequestPriority Priority { get; set; } = CustomerRequestPriority.Medium;

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public AllocationRequestStatus Status { get; set; }

        // Customer Information
        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public virtual Customer Customer { get; set; } = null!;

        // Contact Information (Added missing ContactPerson field for consistency with VM)
        [Required(ErrorMessage = "Contact person is required.")]
        [StringLength(100, ErrorMessage = "Contact person cannot exceed 100 characters.")]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact phone number is required.")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters.")]
        [Phone]
        [Display(Name = "Contact Phone Number")]
        public string ContactPhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [Display(Name = "Contact Email")]
        public string? ContactEmail { get; set; }

        // Delivery Information
        [Required(ErrorMessage = "Delivery location is required.")]
        [Display(Name = "Delivery Location")]
        public int DeliveryLocationId { get; set; }

        [ForeignKey(nameof(DeliveryLocationId))]
        [ValidateNever]
        public virtual Location DeliveryLocation { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Delivery instructions cannot exceed 500 characters.")]
        [Display(Name = "Delivery Instructions")]
        public string? DeliveryInstructions { get; set; }

        [Display(Name = "Preferred Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DateGreaterThan("RequestDate", ErrorMessage = "Preferred delivery date must be after request date.")]
        public DateTime? PreferredDeliveryDate { get; set; }

        // Pricing and Discount
        [Display(Name = "Discount Percentage")]
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100 percent.")]
        public decimal DiscountPercentage { get; set; }

        [Display(Name = "Special Notes")]
        [StringLength(1000, ErrorMessage = "Special notes cannot exceed 1000 characters.")]
        public string? SpecialNotes { get; set; }

        // Navigation Properties
        [ValidateNever]
        [Display(Name = "Request Details")]
        public virtual ICollection<AllocationRequestDetail> RequestDetails { get; set; }

        [ValidateNever]
        [Display(Name = "Fridge Allocations")]
        public virtual ICollection<FridgeAllocation> Allocations { get; set; }

        // Audit Fields
        [Display(Name = "Created Date")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedAt { get; set; }

        [StringLength(450)]
        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [StringLength(450)]
        [Display(Name = "Updated By")]
        public string? UpdatedBy { get; set; }

        // Approval Information
        [Display(Name = "Approved By")]
        public string? ApprovedBy { get; set; }

        [Display(Name = "Approval Date")]
        public DateTime? ApprovalDate { get; set; }

        [StringLength(1000, ErrorMessage = "Approval notes cannot exceed 1000 characters.")]
        [Display(Name = "Approval Notes")]
        public string? ApprovalNotes { get; set; }

        // Computed Properties
        [NotMapped]
        [Display(Name = "Total Monthly Rental")]
        [DataType(DataType.Currency)]
        public decimal TotalMonthlyRental => RequestDetails.Sum(d => d.MonthlyTotal);

        [NotMapped]
        [Display(Name = "Total Contract Value")]
        [DataType(DataType.Currency)]
        public decimal TotalContractValue => RequestDetails.Sum(d => d.LineTotal);

        [NotMapped]
        [Display(Name = "Final Amount")]
        [DataType(DataType.Currency)]
        public decimal FinalAmount => TotalContractValue * (1 - DiscountPercentage / 100);

        [NotMapped]
        [Display(Name = "Total Quantity")]
        public int TotalQuantity => RequestDetails.Sum(d => d.Quantity);

        [NotMapped]
        [Display(Name = "Is Approved")]
        public bool IsApproved => Status == AllocationRequestStatus.Approved;

        [NotMapped]
        [Display(Name = "Can Be Edited")]
        public bool CanBeEdited => Status == AllocationRequestStatus.Draft;

        [NotMapped]
        [Display(Name = "Is Completed")]
        public bool IsCompleted => Status == AllocationRequestStatus.Completed;

        [NotMapped]
        [Display(Name = "Has Allocations")]
        public bool HasAllocations => Allocations.Any(a => a.IsActive);

        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"Request #{Id:00000} - {Customer?.TradingName ?? "Unknown Customer"}";

        // Business Logic Methods
        private static string GenerateRequestNumber()
        {
            return $"REQ-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}";
        }

        // Soft delete implementation
        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Deleted Date")]
        public DateTime? DeletedAt { get; set; }

        [StringLength(450)]
        [Display(Name = "Deleted By")]
        public string? DeletedBy { get; set; }


        public bool CanTransitionTo(AllocationRequestStatus newStatus)
        {
            return Status switch
            {
                AllocationRequestStatus.Draft => newStatus == AllocationRequestStatus.Submitted,
                AllocationRequestStatus.Submitted => newStatus == AllocationRequestStatus.UnderReview || newStatus == AllocationRequestStatus.Rejected,
                AllocationRequestStatus.UnderReview => newStatus == AllocationRequestStatus.Approved || newStatus == AllocationRequestStatus.Rejected,
                AllocationRequestStatus.Approved => newStatus == AllocationRequestStatus.Approved || newStatus == AllocationRequestStatus.Cancelled,
                _ => false
            };
        }

        public void UpdateStatus(AllocationRequestStatus newStatus, string updatedBy, string? notes = null)
        {
            if (CanTransitionTo(newStatus))
            {
                Status = newStatus;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = updatedBy;

                if (newStatus == AllocationRequestStatus.Approved)
                {
                    ApprovalDate = DateTime.UtcNow;
                    ApprovedBy = updatedBy;
                    ApprovalNotes = notes;
                }
            }
        }

        public (bool isValid, List<string> errors) ValidateForSubmission()
        {
            var errors = new List<string>();

            if (CustomerId <= 0)
                errors.Add("Valid customer is required");

            if (DeliveryLocationId <= 0)
                errors.Add("Delivery location is required");

            if (string.IsNullOrWhiteSpace(ContactPerson))
                errors.Add("Contact person is required");

            if (string.IsNullOrWhiteSpace(ContactPhoneNumber))
                errors.Add("Contact phone number is required");

            if (!RequestDetails.Any())
                errors.Add("At least one fridge item is required");

            // Business rule: Maximum total quantity
            if (TotalQuantity > 100)
                errors.Add("Total quantity cannot exceed 100 units per request");

            // Business rule: Maximum contract value
            if (TotalContractValue > 100000)
                errors.Add("Total contract value cannot exceed R100,000");

            return (!errors.Any(), errors);
        }

        public bool HasSufficientStock()
        {
            return RequestDetails.All(detail =>
            {
                var availableStock = GetAvailableStockForModel(detail.FridgeModelId);
                return detail.IsQuantityAvailable(availableStock);
            });
        }

        public int GetAvailableStockForModel(int fridgeModelId)
        {
            // This would typically call a service to get current stock levels
            // For now, returning a placeholder - would be implemented with proper inventory service
            return 10; // Placeholder
        }

    }
}
