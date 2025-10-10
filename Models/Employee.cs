using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        // Link to Identity user (employees must have accounts)
        [Required]
        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }

        public string? EmployeeNumber { get; set; }
    }
}
