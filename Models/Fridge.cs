using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Models.FridgeManagementSystem.Models;
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

        // Managed by Stock Controller
        [Display(Name = "Managed By")]
        public int? StockControllerId { get; set; }

        [ForeignKey("StockControllerId")]
        [ValidateNever]
        public virtual StockController? StockController { get; set; }

        [Required(ErrorMessage = "SKU is required.")]
        [StringLength(100, ErrorMessage = "SKU cannot exceed 100 characters.")]
        [Display(Name = "Serial Number*")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Manufacturer is required.")]
        [StringLength(100, ErrorMessage = "Manufacturer cannot exceed 100 characters.")]
        [Display(Name = "Manufacturer*")]
        public string Manufacturer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fridge Model is required.")]
        [Display(Name = "Fridge Model*")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Capacity is required.")]
        [Display(Name = "Capacity (Liters)*")]
        [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1000 liters.")]
        public int CapacityLiters { get; set; }

        [Display(Name = "Energy Rating")]
        [StringLength(10, ErrorMessage = "Energy Rating cannot exceed 10 characters.")]
        public string? EnergyRating { get; set; }

        [Required(ErrorMessage = "Condition is required.")]
        [Display(Name = "Condition*")]
        public string Condition { get; set; }// Could be an enum, but using string for flexibility

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status*")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Purchase Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Purchase Date*")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Warranty Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? WarrantyExpiryDate { get; set; }
        //[Required]
        public string? ImageUrl { get; set; } = string.Empty;

        [NotMapped]
        [Display(Name = "Under Warranty")]
        public bool UnderWarranty => WarrantyExpiryDate.HasValue && WarrantyExpiryDate.Value > DateTime.UtcNow;

        [ValidateNever]
        public virtual ICollection<FridgeAllocation> AllocationHistory { get; set; } = new List<FridgeAllocation>();

        [ValidateNever]
        public virtual ICollection<FridgeFault> FaultHistory { get; set; } = new List<FridgeFault>();

        [ValidateNever]
        public virtual ICollection<FridgeMaintenance> MaintenanceHistory { get; set; } = new List<FridgeMaintenance>();
    }
}
