using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Project.Models;

namespace Project.Models
{
    public class Customer
    {
        
            [Key]
            public int CustomerID { get; set; }

            [Required]
            public string ApplicationUserId { get; set; }

            [ForeignKey(nameof(ApplicationUserId))]
            public ApplicationUser ApplicationUser { get; set; }

            public string? CustomerNumber { get; set; }

            [NotMapped]
            [Display(Name = "Business Proof Document")]
            public IFormFile? BusinessDocument { get; set; }

            public string? BusinessDocumentPath { get; set; }
            public byte[]? BusinessDocumentData { get; set; }
        

    }
}
