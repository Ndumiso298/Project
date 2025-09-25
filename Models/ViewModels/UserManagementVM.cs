using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class UserManagementVM
    {
        public ApplicationUser ApplicationUser { get; set; }

        public string? UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Location")]
        public int? LocationId { get; set; }
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        [Display(Name = "User Role")]
        [Required(ErrorMessage = "User role is required.")]
        public string UserRole { get; set; } = string.Empty;
        public IEnumerable<SelectListItem>? RoleList { get; set; }

        // Employee dropdown support
        [Display(Name = "Employee")]
        public int? EmployeeId { get; set; }
        public IEnumerable<SelectListItem>? EmployeeList { get; set; }

        // Customer dropdown support
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        public IEnumerable<SelectListItem>? CustomerList { get; set; }

        // For display/readonly purposes
        public string? CurrentRole { get; set; }

        // Employee-specific properties
        [Display(Name = "Employee Number")]
        public string? EmployeeNumber { get; set; }

        [Display(Name = "Employee Type")]
        public EmployeeType? EmployeeType { get; set; }

        [Display(Name = "Availability Status")]
        public AvailabilityStatus? AvailabilityStatus { get; set; }

        // Customer-specific properties  
        [Display(Name = "Trading Name")]
        public string? TradingName { get; set; }

        [Display(Name = "Business Type")]
        public BusinessType? BusinessType { get; set; }

        [Display(Name = "Business Email")]
        [EmailAddress]
        public string? BusinessEmail { get; set; }

        [Display(Name = "Business Phone")]
        public string? BusinessPhoneNumber { get; set; }

        [Display(Name = "Address Line 1")]
        public string? AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "Province")]
        public string? Province { get; set; }

        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }

        [Display(Name = "Profile Picture URL")]
        public string? ProfilePictureUrl { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        // For display purposes
        public string? FullName => $"{FirstName} {LastName}";
    }
}

