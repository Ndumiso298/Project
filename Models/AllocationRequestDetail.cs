using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class AllocationRequestDetail
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Request header ID is required.")]
        [Display(Name = "Request Header ID")]
        public int RequestHeaderId { get; set; }

        [ForeignKey("RequestHeaderId")]
        [ValidateNever]
        [Display(Name = "Request Header")]
        public AllocationRequestHeader RequestHeader { get; set; }

        [Required(ErrorMessage = "Fridge ID is required.")]
        [Display(Name = "Fridge ID")]
        public int FridgeId { get; set; }

        [ForeignKey("FridgeId")]
        [ValidateNever]
        [Display(Name = "Fridge")]
        public Fridge Fridge { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Unit Price")]
        public decimal Price { get; set; }

        // Calculated property for total price (not mapped to database)
        [NotMapped]
        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice => Quantity * Price;
    }
}
