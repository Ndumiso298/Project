using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project.Models.FridgeManagementSystem.Models;

namespace Project.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "FridgeId")]
        public int FridgeId { get; set; }
        [ForeignKey("FridgeId")]
        [ValidateNever]
        public Fridge Fridge { get; set; }

        [Display(Name = "CustomerId")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [ValidateNever]
        public Customer Customer { get; set; }

        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
