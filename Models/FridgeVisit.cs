using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FridgeVisit
    {
        [Key]
        public int FridgeVisitId { get; set; }

        [Required]
        public int AllocationId { get; set; } // Link to FridgeAllocation or RequestDetail

        [ForeignKey("AllocationId")]
        [ValidateNever] 
        public FridgeAllocation Allocation { get; set; } // use RequestDetail if that's what tracks fridges

        [Required]
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }

        [StringLength(500)]
        public string Notes { get; set; } // optional
    }
}
