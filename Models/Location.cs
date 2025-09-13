using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Suburb is required")]
        [Display(Name = "Suburb*")]
        public int SuburbId { get; set; }

        [ForeignKey("SuburbId")]
        [ValidateNever]
        public virtual Suburb Suburb { get; set; } = null!;

        [Required(ErrorMessage = "Address Line 1 is required")]
        [StringLength(100, ErrorMessage = "Address Line 1 cannot exceed 100 characters")]
        [Display(Name = "Address Line 1*")]
        public string AddressLine1 { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Address Line 2 cannot exceed 100 characters")]
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
