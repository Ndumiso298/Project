using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = "South Africa";

        [Required]
        public string Code { get; set; } = string.Empty; // e.g., "EC", "WC"
        public bool IsDeleted { get; set; } = false;
    }
}
