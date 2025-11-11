using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    namespace Project.Models
    {
        public class CustomerFridge
        {
            [Key]
            public int CustomerFridgeId { get; set; }
            [ForeignKey("FridgeId")]
            public int FridgeId { get; set; }
            [ValidateNever]
            public Fridge Fridge { get; set; } = null!;
            [ForeignKey("FridgeInStockId")]
            public int FridgeInStockId { get; set; }
            [ValidateNever]
            public FridgeInStock FridgeInStock { get; set; } = null!;
            [ForeignKey("CustomerID")]
            public int CustomerID { get; set; }
            [ValidateNever]
            public Customer Customer { get; set; } = null!;
            [Required]
            public DateTime ReservedDate { get; set; }
            public DateTime? AllocatedDate { get; set; }
            public bool IsActive { get; set; } = true;

            [ForeignKey("RequestDetailId")]
            public int RequestDetailId { get; set; }
            [ValidateNever]

            public RequestDetails RequestDetail { get; set; } = null!;
            public DateTime? ReplacementDate { get; set; }
            public string? ReasonForReplacement { get; set; }
            public string? ReplacementNotes { get; set; }
            [ForeignKey("ReplacementFridgeInStockId")]
            public int? ReplacementFridgeInStockId { get; set; }
            [ValidateNever]

            public FridgeInStock? ReplacementFridgeInStock { get; set; }
            public string? ReplacementStatus { get; set; }
            public string? DeclineReason { get; set; }
            public string? TechnicianNotes { get; set; }
        }
    }

