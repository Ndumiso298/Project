using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Fridge
    {
        [Key]
        public int FridgeId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string FridgeNo { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int CapacityLiters { get; set; }
        [Required]
        public string Type { get; set; } // e.g., "Single Door", "Double Door", etc
        [Required]
        public string Description { get; set; }
        [Required]
        public double RentalPricePerMonth { get; set; }
        
        [Required]
        public DateTime LastMaintenanceDate { get; set; }
        [Required]
        public string Condition { get; set; }
        //[Required]
        public string? ImageUrl { get; set; }
        [Required]
        public string AvailabilityStatus { get; set; } // e.g., "Available", "Rented", "Under Maintenance"
        public string? Location { get; set; }
    }

}
