using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models.ViewModels
{
    public class UserManagementVM
    {
        // Basic User Information
        public string? UserId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email Address")]
        [StringLength(100, ErrorMessage = "Email address cannot exceed 100 characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters.")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Range(typeof(DateTime), "01/01/1900", "01/01/2007", ErrorMessage = "Date of birth must be between 01/01/1900 and 01/01/2007.")]
        public DateTime? DOB { get; set; }

        // Location Management (Required for all users)
        //[Required(ErrorMessage = "Primary location is required.")]
        [Display(Name = "Primary Location")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid location.")]
        public int? LocationId { get; set; }

        public IEnumerable<SelectListItem> LocationList { get; set; } = new List<SelectListItem>();

        // User Role Management
        [Required(ErrorMessage = "User role is required.")]
        [Display(Name = "User Role")]
        public string UserRole { get; set; } = string.Empty;

        public IEnumerable<SelectListItem>? RoleList { get; set; }

        // For display/readonly purposes
        [Display(Name = "Current Role")]
        public string? CurrentRole { get; set; }

        // Profile Management
        [Display(Name = "Profile Picture")]
        [DataType(DataType.Upload)]
        public IFormFile? ProfileImage { get; set; }

        [Display(Name = "Profile Picture URL")]
        [DataType(DataType.ImageUrl)]
        [MaxLength(500, ErrorMessage = "URL cannot exceed 500 characters.")]
        [Url(ErrorMessage = "Please enter a valid URL starting with http:// or https://")]
        public string? ProfilePictureUrl { get; set; }

        // Entity Relationships (Conditional based on role)
        [Display(Name = "Employee Profile")]
        public int? EmployeeId { get; set; }
        public IEnumerable<SelectListItem>? EmployeeList { get; set; }

        [Display(Name = "Customer Profile")]
        public int? CustomerId { get; set; }
        public IEnumerable<SelectListItem>? CustomerList { get; set; }

        // Employee-specific properties (Visible when role is employee type)
        [Display(Name = "Employee Number")]
        [StringLength(20, ErrorMessage = "Employee number cannot exceed 20 characters.")]
        [RequiredIfUserRole(new[] { "FaultTechnician", "MaintenanceTechnician", "CustomerLiaison", "InventoryLiaison", "PurchasingManager" },
            ErrorMessage = "Employee number is required for employees.")] // CHANGED: Specific role validation
        public string? EmployeeNumber { get; set; }

        [Display(Name = "Employee Type")]
        [RequiredIfUserRole(new[] { "FaultTechnician", "MaintenanceTechnician", "CustomerLiaison", "InventoryLiaison", "PurchasingManager" },
            ErrorMessage = "Employee type is required for employees.")]
        public EmployeeType? EmployeeType { get; set; }

        [Display(Name = "Availability Status")]
        public AvailabilityStatus? AvailabilityStatus { get; set; }

        // Customer-specific properties
        [Display(Name = "Trading Name")]
        [RequiredIfUserRole("Customer", ErrorMessage = "Trading name is required for customers.")]
        [StringLength(200, ErrorMessage = "Trading name cannot exceed 200 characters.")] // CHANGED: Increased to match model
        public string? TradingName { get; set; }

        [Display(Name = "Business Type")]
        [RequiredIfUserRole("Customer", ErrorMessage = "Business type is required for customers.")]
        public BusinessType? BusinessType { get; set; }

        [Display(Name = "VAT Number")]
        [StringLength(20, ErrorMessage = "VAT number cannot exceed 20 characters.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "VAT number must be 10 digits.")]
        public string? VATNumber { get; set; }

        [Display(Name = "Business Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid business email address.")]
        [StringLength(200, ErrorMessage = "Business email cannot exceed 200 characters.")] // CHANGED: Increased to match model
        [RequiredIfUserRole("Customer", ErrorMessage = "Business email is required for customers.")]
        public string? BusinessEmail { get; set; }

        [Display(Name = "Business Phone")]
        [Phone(ErrorMessage = "Please enter a valid business phone number.")]
        [StringLength(20, ErrorMessage = "Business phone number cannot exceed 20 characters.")] // CHANGED: Increased to match model
        [RequiredIfUserRole("Customer", ErrorMessage = "Business phone is required for customers.")]
        public string? BusinessPhoneNumber { get; set; }

        // Address Information (for Customers and Suppliers)
        [Display(Name = "Address Line 1")]
        [StringLength(100, ErrorMessage = "Address line 1 cannot exceed 100 characters.")]
        [RequiredIfUserRole("Customer", ErrorMessage = "Address line 1 is required for customers.")]
        public string? AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Address line 2 cannot exceed 100 characters.")]
        public string? AddressLine2 { get; set; }

        [Display(Name = "Suburb")]
        [StringLength(50, ErrorMessage = "Suburb cannot exceed 50 characters.")]
        [RequiredIfUserRole("Customer", ErrorMessage = "Suburb is required for customers.")]
        public string? Suburb { get; set; }

        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters.")]
        [RequiredIfUserRole("Customer", ErrorMessage = "City is required for customers.")]
        public string? City { get; set; }

        [Display(Name = "Province")]
        [StringLength(100, ErrorMessage = "Province cannot exceed 100 characters.")]
        [RequiredIfUserRole("Customer", ErrorMessage = "Province is required for customers.")]
        public string? Province { get; set; }

        [Display(Name = "Postal Code")]
        [StringLength(10, ErrorMessage = "Postal code cannot exceed 10 characters.")]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Postal code must be 4 digits.")]
        [RequiredIfUserRole("Customer", ErrorMessage = "Postal code is required for customers.")]
        public string? PostalCode { get; set; }

        // Status Management
        [Display(Name = "Account Status")]
        public AccountStatus AccountStatus { get; set; } = AccountStatus.PendingApproval;

        [Display(Name = "Email Verified")]
        public bool IsEmailVerified { get; set; } = false;

        [Display(Name = "Active Status")]
        public bool IsActive { get; set; } = true;

        // Display Helpers
        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => !string.IsNullOrEmpty(TradingName) ? TradingName : FullName;

        // Audit Information
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Last Updated")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Last Login")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? LastLoginDate { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }

    // Custom validation attribute for role-based required fields
    public class RequiredIfUserRoleAttribute : ValidationAttribute
    {
        private readonly string[] _roles;

        public RequiredIfUserRoleAttribute(string role)
        {
            _roles = new[] { role };
        }

        public RequiredIfUserRoleAttribute(string[] roles)
        {
            _roles = roles;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;
            var roleProperty = instance.GetType().GetProperty("UserRole");

            if (roleProperty != null)
            {
                var roleValue = roleProperty.GetValue(instance) as string;

                if (_roles.Contains(roleValue) && (value == null || string.IsNullOrWhiteSpace(value.ToString())))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}

