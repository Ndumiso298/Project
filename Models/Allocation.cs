using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Allocation
    {
        public int AllocationId { get; set; } // Unique ID for each allocation



        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }


        [ForeignKey("FridgeId")]
        public string FridgeId { get; set; }
        [ValidateNever]
        public Fridge Fridge { get; set; }
        // Rental Period

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Status { get; set; }
   
        public string? Notes { get; set; }


        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? CellNumber { get; set; }

    }
}
