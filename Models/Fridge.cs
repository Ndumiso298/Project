using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Fridge
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serial Number is required.")]
        [StringLength(100, ErrorMessage = "Serial Number cannot exceed 100 characters.")]
        [Display(Name = "Serial Number")]
        [RegularExpression(@"^[A-Z0-9\-]+$", ErrorMessage = "Serial number can only contain uppercase letters, numbers, and hyphens.")]
        public string SerialNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Manufacturer is required.")]
        [StringLength(100, ErrorMessage = "Manufacturer name cannot exceed 100 characters.")]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(50, ErrorMessage = "Model name cannot exceed 50 characters.")]
        [Display(Name = "Model")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1000 liters.")]
        [Display(Name = "Capacity (Liters)")]
        public int CapacityLiters { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        [Display(Name = "Type")]
        public string Type { get; set; } = string.Empty; // e.g., "Single Door", "Double Door", etc

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Rental price is required.")]
        [Range(0, 10000, ErrorMessage = "Rental price must be a positive value.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Rental Price (R/month)")]
        public decimal RentalPricePerMonth { get; set; }

        [Required(ErrorMessage = "Last maintenance date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Last Maintenance Date")]
        public DateTime LastMaintenanceDate { get; set; }

        [Required(ErrorMessage = "Current Location is required.")]
        [Display(Name = "Current Location")]
        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        [ValidateNever]
        public virtual Location CurrentLocation { get; set; } = null!;

        [Required(ErrorMessage = "Condition is required.")]
        [Display(Name = "Condition")]
        public FridgeCondition Condition { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Availability Status")]
        public FridgeStatus Status { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL for the image.")]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        // Additional properties for better tracking
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Purchase Price")]
        [Range(0, 100000, ErrorMessage = "Purchase price must be a positive value.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PurchasePrice { get; set; }

        [Display(Name = "Warranty Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? WarrantyExpiryDate { get; set; }

        [Display(Name = "Energy Rating")]
        [StringLength(10, ErrorMessage = "Energy rating cannot exceed 10 characters.")]
        public string? EnergyRating { get; set; } // e.g., "A++", "B", etc.

        [Display(Name = "Dimensions (HxWxD in cm)")]
        [StringLength(50, ErrorMessage = "Dimensions cannot exceed 50 characters.")]
        public string? Dimensions { get; set; }

        [Display(Name = "Weight (kg)")]
        [Range(0, 500, ErrorMessage = "Weight must be a positive value.")]
        public decimal? Weight { get; set; }

        [Display(Name = "Color")]
        [StringLength(30, ErrorMessage = "Color cannot exceed 30 characters.")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Service interval is required.")]
        [Range(1, 24, ErrorMessage = "Service interval must be between 1 and 24 months.")]
        [Display(Name = "Service Interval (Months)")]
        public int ServiceIntervalMonths { get; set; } = 6;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Last Service Date")]
        public DateTime? LastServiceDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Next Service Due")]
        public DateTime? NextServiceDue { get; set; }

        // Audit fields
        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Last Modified")]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ValidateNever]
        [Display(Name = "Maintenance Records")]
        public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

        [ValidateNever]
        [Display(Name = "Allocation History")]
        public virtual ICollection<FridgeAllocation> AllocationHistory { get; set; } = new List<FridgeAllocation>();

        [ValidateNever]
        [Display(Name = "Fault Reports")]
        public virtual ICollection<FaultRecord> FaultReports { get; set; } = new List<FaultRecord>();

        // Computed properties
        [NotMapped]
        [Display(Name = "Requires Maintenance")]
        public bool RequiresMaintenance
        {
            get
            {
                // If maintenance is overdue by more than 6 months
                return LastMaintenanceDate < DateTime.UtcNow.AddMonths(-6);
            }
        }

        [NotMapped]
        [Display(Name = "Under Warranty")]
        public bool UnderWarranty
        {
            get
            {
                return WarrantyExpiryDate.HasValue && WarrantyExpiryDate > DateTime.UtcNow;
            }
        }

        [NotMapped]
        [Display(Name = "Age (years)")]
        public double? AgeInYears
        {
            get
            {
                if (PurchaseDate.HasValue)
                {
                    return (DateTime.UtcNow - PurchaseDate.Value).TotalDays / 365.25;
                }
                return null;
            }
        }
    }
}

