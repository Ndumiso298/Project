using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Suburb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; } = null!;

        [Required]
        [StringLength(10)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
    }
}