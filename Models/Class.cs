using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Project.Models
{
    public class FridgeReplacementRequest
    {
        [Key]
        public int ReplacementId { get; set; }

        [Required]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [ValidateNever]
        public Customer Customer { get; set; }

        [Required]
        public int FaultId { get; set; }
        [ForeignKey("FaultId")]
        [ValidateNever]
        public Employee FaultTechnician { get; set; }

        [Required]
        [Display(Name = "Fridge Type Requested")]
        public string FridgeType { get; set; }

        [Required]
        [Display(Name = "Fridge Brand Requested")]
        public string FridgeBrand { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Delivered
    }
}
