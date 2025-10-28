using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Fridge
    {
        [Key]
        public int FridgeId { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int CapacityLiters { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double RentalPricePerMonth { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public string AvailabilityStatus { get; set; }

        public string? Location { get; set; }
        [NotMapped] // EF will ignore this field in the database
        public string FridgeNo { get; set; }
        [ValidateNever]
        public virtual ICollection<FridgeInStock> FridgeInstances { get; set; }
    }
}