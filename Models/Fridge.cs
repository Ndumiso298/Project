using Project.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Fridge
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serial Number is required.")]
        [StringLength(100, ErrorMessage = "Serial Number cannot exceed 100 characters.")]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fridge Manufacturer is required.")]
        [Display(Name = "Fridge Manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }
        [Required]
        public int CapacityLiters { get; set; }
        [Required]
        public string Type { get; set; } // e.g., "Single Door", "Double Door", etc
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal RentalPricePerMonth { get; set; }
        
        [Required]
        public DateTime LastMaintenanceDate { get; set; }

        public string? Location { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public FridgeCondition Condition { get; set; }

        [Required]
        [Display(Name = "Availability Status")]
        public FridgeStatus Status { get; set; }

        //[Required]
        public string? ImageUrl { get; set; }
    }
}
