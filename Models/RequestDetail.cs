using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class RequestDetail
    {
        [Key]
        public int RequestDetailId { get; set; }
        [Required]
        public int RequestHeaderId { get; set; }
        [Required]
        [ForeignKey("Id")]
        [ValidateNever]
        public RequestHeader RequestHeader { get; set; }

        [Required]
        public int FridgeId { get; set; }
        [ForeignKey("Id")]
        [ValidateNever]
        public Fridge Fridge { get; set; }

        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
