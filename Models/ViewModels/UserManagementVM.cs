using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Project.Models.Employee;

namespace Project.Models.ViewModels
{
    public class UserManagementVM
    {
        // ===== BASIC USER INFO =====
        public string? UserId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        public string LastName { get; set; } = string.Empty;

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

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Range(typeof(DateTime), "01/01/1900", "01/01/2007", ErrorMessage = "Date of birth must be between 01/01/1900 and 01/01/2007.")]
        public DateTime? DOB { get; set; }

        // ===== ROLE & LOCATION =====
        [Required(ErrorMessage = "User role is required.")]
        [Display(Name = "User Role")]
        public string UserRole { get; set; } = string.Empty;
        public IEnumerable<SelectListItem>? RoleList { get; set; }

        [Display(Name = "Current Role")]
        public string? CurrentRole { get; set; }

        [Display(Name = "Primary Location")]
        public int? LocationId { get; set; }
        public IEnumerable<SelectListItem> LocationList { get; set; } = new List<SelectListItem>();

        // ===== PROFILE IMAGE =====
        [Display(Name = "Profile Picture")]
        [DataType(DataType.Upload)]
        public IFormFile? ProfileImage { get; set; }

        [Display(Name = "Profile Picture URL")]
        [DataType(DataType.ImageUrl)]
        [MaxLength(500, ErrorMessage = "URL cannot exceed 500 characters.")]
        [Url(ErrorMessage = "Please enter a valid URL starting with http:// or https://")]
        public string? ProfilePictureUrl { get; set; }

        // ===== EMPLOYEE SPECIFIC FIELDS =====
        [Display(Name = "Employee Number")]
        [StringLength(20, ErrorMessage = "Employee number cannot exceed 20 characters.")]
        [RequiredIfUserRole(new[] { SD.AdminRole, SD.CustomerSupportRole, SD.StockControllerRole, SD.FaultTechnicianRole, SD.MaintenanceTechnicianRole },
                ErrorMessage = "Employee number is required for employees.")]
        public string? EmployeeNumber { get; set; } = EmployeeNumberGenerator.GenerateEmployeeNumber();

        [Display(Name = "Employee Type")]
        [RequiredIfUserRole(new[] { SD.AdminRole, SD.CustomerSupportRole, SD.StockControllerRole, SD.FaultTechnicianRole, SD.MaintenanceTechnicianRole },
            ErrorMessage = "Employee type is required for employees.")]
        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Availability Status")]
        [RequiredIfUserRole(new[] { SD.AdminRole, SD.CustomerSupportRole, SD.StockControllerRole, SD.FaultTechnicianRole, SD.MaintenanceTechnicianRole },
            ErrorMessage = "Availability status is required for employees.")]
        public AvailabilityStatus? AvailabilityStatus { get; set; }

        [Display(Name = "Work Phone")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(15, ErrorMessage = "Work phone cannot exceed 15 characters.")]
        public string? WorkPhone { get; set; }

        [Display(Name = "Work Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(100, ErrorMessage = "Work email cannot exceed 100 characters.")]
        public string? WorkEmail { get; set; }

        // ===== CUSTOMER SPECIFIC FIELDS =====
        [Url(ErrorMessage = "Please enter a valid document URL.")]
        [Display(Name = "Business Document Path")]
        public string? BusinessDocumentPath { get; set; }

        [Display(Name = "Business Name")]
        [StringLength(200, ErrorMessage = "Business name cannot exceed 200 characters.")]
        [RequiredIfUserRole(SD.CustomerRole, ErrorMessage = "Business name is required for customers.")]
        public string? BusinessName { get; set; }

        [Display(Name = "Business Type")]
        [RequiredIfUserRole(SD.CustomerRole, ErrorMessage = "Business type is required for customers.")]
        public BusinessType? BusinessType { get; set; }

        [Display(Name = "VAT Number")]
        [StringLength(20, ErrorMessage = "VAT number cannot exceed 20 characters.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "VAT number must be 10 digits.")]
        public string? VATNumber { get; set; }

        [Display(Name = "Business Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid business email address.")]
        [StringLength(200, ErrorMessage = "Business email cannot exceed 200 characters.")]
        [RequiredIfUserRole(SD.CustomerRole, ErrorMessage = "Business email is required for customers.")]
        public string? BusinessEmail { get; set; }

        [Display(Name = "Business Phone")]
        [Phone(ErrorMessage = "Please enter a valid business phone number.")]
        [StringLength(20, ErrorMessage = "Business phone number cannot exceed 20 characters.")]
        [RequiredIfUserRole(SD.CustomerRole, ErrorMessage = "Business phone is required for customers.")]
        public string? BusinessPhoneNumber { get; set; }

        // ===== CUSTOMER ADDRESS FIELDS =====
        [Display(Name = "Street Address")]
        [StringLength(100, ErrorMessage = "Street Address cannot exceed 100 characters.")]
        [RequiredIfUserRole(SD.CustomerRole, ErrorMessage = "Street Address is required for customers.")]
        public string? StreetAddress { get; set; }

        [Display(Name = "Suburb")]
        [StringLength(50, ErrorMessage = "Suburb cannot exceed 50 characters.")]
        [RequiredIfUserRole(SD.CustomerRole, ErrorMessage = "Suburb is required for customers.")]
        public string? Suburb { get; set; }

        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        [RequiredIfUserRole(SD.CustomerRole, ErrorMessage = "City is required for customers.")]
        public string? City { get; set; }

        [Display(Name = "Province")]
        [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters.")]
        [RequiredIfUserRole(SD.CustomerRole, ErrorMessage = "Province is required for customers.")]
        public string? Province { get; set; }

        [Display(Name = "Postal Code")]
        [StringLength(10, ErrorMessage = "Postal code cannot exceed 10 characters.")]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Postal code must be 4 digits.")]
        [RequiredIfUserRole(SD.CustomerRole, ErrorMessage = "Postal code is required for customers.")]
        public string? PostalCode { get; set; }

        // ===== ACCOUNT MANAGEMENT =====
        [Display(Name = "Account Status")]
        public AccountStatus AccountStatus { get; set; } = AccountStatus.PendingApproval;

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        // ===== COMPUTED PROPERTIES =====
        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}".Trim();

        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => !string.IsNullOrEmpty(BusinessName) ? BusinessName : FullName;

        // ===== AUDIT FIELDS =====
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; } = string.Empty;

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; } = false;

        [Display(Name = "Updated By")]
        public string? UpdatedBy { get; set; } = string.Empty;

        [Display(Name = "Last Login")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? LastLoginDate { get; set; }

        // ===== CONTROLLER-POPULATED PROPERTIES =====
        [NotMapped]
        [Display(Name = "Current Fridge Count")]
        public int CurrentFridgeCount { get; set; }

        [NotMapped]
        [Display(Name = "Approved Allocations")]
        public int ActiveAllocations { get; set; }

        [NotMapped]
        public bool HasActiveFridgeAllocations { get; set; }

        [NotMapped]
        [Display(Name = "Has Overdue Payments")]
        public bool HasOverduePayments { get; set; }

        [NotMapped]
        [Display(Name = "Is Credit Limited")]
        public bool IsCreditLimited { get; set; }

        public static UserManagementVM FromEntity(Customer entity)
        {
            if (entity == null) return null;

            return new UserManagementVM
            {
                // Basic info (from UserAccount via Customer for consistency)
                FirstName = entity.UserAccount?.FirstName ?? string.Empty,
                LastName = entity.UserAccount?.LastName ?? string.Empty,
                Email = entity.UserAccount?.Email ?? entity.BusinessEmail,
                PhoneNumber = entity.UserAccount?.PhoneNumber ?? entity.BusinessPhoneNumber,

                // Customer-specific fields
                BusinessName = entity.BusinessName,
                BusinessType = entity.BusinessType,
                BusinessEmail = entity.BusinessEmail,
                BusinessPhoneNumber = entity.BusinessPhoneNumber,
                LocationId = entity.TradingLocationId,  // Maps to TradingLocation (business site/address)
                StreetAddress = entity.StreetAddress,
                Suburb = entity.Suburb,
                City = entity.City,
                Province = entity.Province,
                PostalCode = entity.PostalCode,

                // Account management
                AccountStatus = entity.AccountStatus,
                CreatedAt = entity.UserAccount?.CreatedAt ?? DateTime.UtcNow,
                UserRole = SD.CustomerRole  // Use constant for consistency
            };
        }

        public static UserManagementVM FromEntity(Employee entity)
        {
            if (entity == null) return null;

            var vm = new UserManagementVM
            {
                // Basic info (from UserAccount via Employee)
                FirstName = entity.UserAccount?.FirstName ?? string.Empty,
                LastName = entity.UserAccount?.LastName ?? string.Empty,
                Email = entity.UserAccount?.Email ?? entity.WorkEmail,
                PhoneNumber = entity.UserAccount?.PhoneNumber ?? entity.WorkPhone,

                // Employee-specific fields (ensure these properties exist on UserManagementVM)
                EmployeeNumber = entity.EmployeeNumber,
                AvailabilityStatus = entity.AvailabilityStatus,
                WorkEmail = entity.WorkEmail,
                WorkPhone = entity.WorkPhone,
                LocationId = entity.WorkLocationId,  // Maps to WorkLocation (work site/branch)

                // Account management
                AccountStatus = entity.UserAccount?.IsAccountActive == true ? AccountStatus.Approved : AccountStatus.PendingApproval,  // Derive from user status
                CreatedAt = entity.UserAccount?.CreatedAt ?? DateTime.UtcNow,
                UserRole = GetRoleFromEmployeeType(entity.EmployeeType)  // Maps EmployeeType to role string
            };

            // Set EmployeeType after initialization to avoid static context issues
            vm.EmployeeType = entity.EmployeeType;

            return vm;
        }

        // Helper method (add to your utilities or static class)
        private static string GetRoleFromEmployeeType(EmployeeType type)
        {
            switch (type)
            {
                case EmployeeType.Administrator:
                    return SD.AdminRole;
                case EmployeeType.CustomerSupport:
                    return SD.CustomerSupportRole;
                case EmployeeType.StockController:
                    return SD.StockControllerRole;
                case EmployeeType.FaultTechnician:
                    return SD.FaultTechnicianRole;
                case EmployeeType.MaintenanceTechnician:
                    return SD.MaintenanceTechnicianRole;
                default:
                    return "Employee";
            }
        }

        public static class EmployeeNumberGenerator
        {
            public static string GenerateEmployeeNumber()
            {
                return $"EMP-{DateTime.UtcNow:ddMMyyy}-{Guid.NewGuid().ToString("N")[..6].ToUpper()}";
            }
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
                _roles = roles ?? throw new ArgumentNullException(nameof(roles), "Roles array cannot be null.");
            }

            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                // Get the UserRole property from the validated object
                var roleProperty = validationContext.ObjectType.GetProperty("UserRole");
                if (roleProperty == null)
                {
                    return new ValidationResult("UserRole property not found on the object.");
                }

                var roleValue = roleProperty.GetValue(validationContext.ObjectInstance) as string;
                if (roleValue == null)
                {
                    return new ValidationResult("UserRole value cannot be null.");
                }

                // Check if the current role matches any in the defined roles
                if (_roles.Contains(roleValue))
                {
                    // Handle different value types appropriately
                    if (value == null || (value is string s && string.IsNullOrWhiteSpace(s)))
                    {
                        return new ValidationResult(ErrorMessage ?? $"This field is required when the role is {string.Join(", ", _roles)}.");
                    }
                }

                return ValidationResult.Success;
            }
        }
    }
}

