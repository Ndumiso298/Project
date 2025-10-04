using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Data.SqlClient;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        // ===== USER ACCOUNT RELATIONSHIP =====
        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        public virtual ApplicationUser UserAccount { get; set; } = null!;

        // ===== BUSINESS INFORMATION =====
        [Required(ErrorMessage = "Business Name is required.")]
        [StringLength(200, ErrorMessage = "Business Name cannot exceed 200 characters.")]
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Business Type is required.")]
        [Display(Name = "Business Type")]
        public BusinessType BusinessType { get; set; }

        [Display(Name = "Registration Number")]
        [StringLength(30, ErrorMessage = "Registration number cannot exceed 30 characters.")]
        public string? RegistrationNumber { get; set; }

        [Display(Name = "VAT Number")]
        [StringLength(20, ErrorMessage = "VAT number cannot exceed 20 characters.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "VAT number must be 10 digits.")]
        public string? VATNumber { get; set; }

        [Display(Name = "Operating Hours")]
        [StringLength(100, ErrorMessage = "Operating hours cannot exceed 100 characters.")]
        public string? OperatingHours { get; set; }

        [Display(Name = "Customer Since")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CustomerSince { get; set; } = DateTime.UtcNow;

        // ===== CONTACT INFORMATION =====
        [Required(ErrorMessage = "Business Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(200, ErrorMessage = "Business Email cannot exceed 200 characters.")]
        [Display(Name = "Business Email")]
        public string BusinessEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Business Phone Number is required.")]
        [StringLength(20, ErrorMessage = "Business Phone Number cannot exceed 20 characters.")]
        [Display(Name = "Business Phone")]
        public string BusinessPhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Alternative Phone")]
        [StringLength(20, ErrorMessage = "Alternative phone cannot exceed 20 characters.")]
        public string? AlternativePhone { get; set; }

        // ===== ADDRESS INFORMATION =====
        [Required(ErrorMessage = "Street Address is required.")]
        [StringLength(100, ErrorMessage = "Street Address cannot exceed 100 characters.")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Suburb is required.")]
        [StringLength(50, ErrorMessage = "Suburb cannot exceed 50 characters.")]
        public string Suburb { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters.")]
        [Display(Name = "Province")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal Code is required.")]
        [StringLength(10, ErrorMessage = "Postal Code cannot exceed 10 characters.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Postal code must be 4 digits")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        // ===== COMPANY LOCATION RELATIONSHIP (Optional) =====
        [Display(Name = "Trading Location")]
        public int? TradingLocationId { get; set; }

        [ForeignKey(nameof(TradingLocationId))]
        [ValidateNever]
        public virtual Location? TradingLocation { get; set; }

        // ===== FINANCIAL INFORMATION =====
        [Display(Name = "Credit Limit")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 1000000, ErrorMessage = "Credit limit must be between 0 and 1,000,000.")]
        public decimal CreditLimit { get; set; } = 5000.00m;

        [Display(Name = "Outstanding Balance")]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        public decimal OutstandingBalance { get; set; } = 0.00m;

        [Display(Name = "Payment Terms (days)")]
        [Range(0, 90, ErrorMessage = "Payment terms must be between 0 and 90 days.")]
        public int PaymentTermsDays { get; set; } = 30;

        [Display(Name = "Discount Rate")]
        [Range(0, 100, ErrorMessage = "Discount rate must be between 0 and 100 percent.")]
        public decimal DiscountRate { get; set; } = 0.00m;

        [Display(Name = "Credit Status")]
        public CreditStatus CreditStatus { get; set; } = CreditStatus.Pending;

        // ===== CUSTOMER STATUS =====
        [Required(ErrorMessage = "Customer status is required.")]
        [Display(Name = "Customer Status")]
        public AccountStatus AccountStatus { get; set; } = AccountStatus.PendingApproval;

        [StringLength(500, ErrorMessage = "Rejection reason cannot exceed 500 characters.")]
        [Display(Name = "Rejection Reason")]
        public string? RejectionReason { get; set; }

        [Url(ErrorMessage = "Please enter a valid document URL.")]
        [Display(Name = "Business Document Path")]
        public string? BusinessDocumentPath { get; set; }

        [Display(Name = "Declined At")]
        public DateTime? DeclinedAt { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; } = false;

        // ===== EMPLOYEE ASSIGNMENT =====
        public int? AssignedEmployeeId { get; set; }

        [ForeignKey(nameof(AssignedEmployeeId))]
        [ValidateNever]
        public virtual Employee? AssignedEmployee { get; set; }

        // ===== COMPUTED PROPERTIES =====
        [NotMapped]
        [Display(Name = "Contact Person")]
        public string ContactPerson => UserAccount != null ? $"{UserAccount.FirstName} {UserAccount.LastName}" : "Not Specified";

        [NotMapped]
        [Display(Name = "Is Approved")]
        public bool IsActive => AccountStatus == AccountStatus.Approved;

        [NotMapped]
        public bool CanLogin => UserAccount?.IsAccountActive == true && AccountStatus == AccountStatus.Approved;

        [NotMapped]
        [Display(Name = "Full Address")]
        public string FullAddress => $"{StreetAddress}, {Suburb}, {City}, {Province}, {PostalCode}";

        [NotMapped]
        [Display(Name = "Available Credit")]
        [DataType(DataType.Currency)]
        public decimal AvailableCredit => CreditLimit - OutstandingBalance;

        // ===== NAVIGATION PROPERTIES =====
        [ValidateNever]
        public virtual ICollection<Fridge> Fridges { get; set; } = new List<Fridge>();

        [ValidateNever]
        [Display(Name = "Allocation History")]
        public virtual ICollection<FridgeAllocation> AllocationHistory { get; set; } = new List<FridgeAllocation>();

        [Display(Name = "Reported Faults")]
        [ValidateNever]
        public virtual ICollection<FaultRecord> ReportedFaults { get; set; } = new List<FaultRecord>();

        [Display(Name = "Maintenance Schedules")]
        [ValidateNever]
        public virtual ICollection<MaintenanceVisit> MaintenanceSchedules { get; set; } = new List<MaintenanceVisit>();
    }
}
