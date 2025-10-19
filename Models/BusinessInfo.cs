using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Project.Models
{
    public class BusinessInfo
    {
        [Key]
        public int BusinessID { get; set; }

        [Required]
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        [Required]
        [Display(Name = "Business Registration Number")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Business Type")]
        public string? BusinessType { get; set; }

        [Display(Name = "Industry")]
        public string? Industry { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Contact Number")]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Website URL")]
        [Url]
        public string? Website { get; set; }

        [Display(Name = "Physical Address")]
        public string? Address { get; set; }

        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "Country")]
        public string? Country { get; set; }

        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }

        [Display(Name = "Logo")]
        [NotMapped]
        public IFormFile? BusinessLogo { get; set; }

        public string? LogoPath { get; set; }

        public byte[]? LogoData { get; set; }

        [Display(Name = "Date Registered")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
