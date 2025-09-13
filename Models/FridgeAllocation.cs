using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Models.FridgeManagementSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FridgeAllocation
    {
        // Constructor to set default values
        public FridgeAllocation()
        {
            Status = "Pending"; // Start as pending rather than approved
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }
        [Key]
        public int Id { get; set; }
        //Foreign key to Fridge
        //[Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "FridgeId")]
        public int FridgeId { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; } = null!;
        // Foreign key to Customer
        //[Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "CustomerId")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public virtual Customer Customer { get; set; } = null!;

        // Foreign key to Customer Liaison (Employee)
        //[Required(ErrorMessage = "Customer Liaison is required.")]
        [Display(Name = "CustomerLiaisonId*")]
        public int? CustomerLiaisonId { get; set; }

        [ForeignKey(nameof(CustomerLiaisonId))]
        [ValidateNever]
        public virtual CustomerSupport? CustomerLiaison { get; set; } = null!;

        [Display(Name = "Status")]
        public string Status { get; set; } = "Pending";

        [Required(ErrorMessage = "Allocation date is required.")]
        [Display(Name = "Allocation Date*")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime AllocationDate { get; set; }

        [Display(Name = "Expected Return Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ExpectedReturnDate { get; set; }

        [Display(Name = "Actual Return Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ActualReturnDate { get; set; }

        [Display(Name = "Service Interval (Months)")]
        [Range(1, 24, ErrorMessage = "Service Interval must be between 1 and 24 months.")]
        public int ServiceIntervalMonths { get; set; } = 6;

        [Display(Name = "Last Service Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? LastServiceDate { get; set; }

        [Display(Name = "Next Service Due")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NextServiceDue { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        [Display(Name = "Allocation Notes")]
        public string? Notes { get; set; }

        // Audit fields
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; }
    }
}

