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

        public string? UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        public virtual ApplicationUser? UserAccount { get; set; } = null!;

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => UserAccount != null ? $"{UserAccount.FirstName} {UserAccount.LastName}" : TradingName;

        [NotMapped]
        [Display(Name = "Contact Person")]
        public string ContactPerson => UserAccount != null ? $"{UserAccount.FirstName} {UserAccount.LastName}" : "Not Specified";

        public int? AssignedEmployeeId { get; set; }

        [ForeignKey(nameof(AssignedEmployeeId))]
        [ValidateNever]
        public virtual Employee? AssignedEmployee { get; set; } = null!;

        [Required(ErrorMessage = "Trading Name is required.")]
        [StringLength(200, ErrorMessage = "Trading Name cannot exceed 200 characters.")]
        [Display(Name = "Trading Name")]
        public string TradingName { get; set; } = string.Empty;

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

        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        [ValidateNever]
        [Display(Name = "Trading Location")]
        public virtual Location TradingLocation { get; set; } = null!;

        [Required(ErrorMessage = "Address line 1 is required.")]
        [StringLength(100, ErrorMessage = "Address line 1 cannot exceed 100 characters.")]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Address line 2 cannot exceed 100 characters.")]
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "Suburb is required.")]
        [StringLength(50, ErrorMessage = "Suburb cannot exceed 50 characters.")]
        public string Suburb { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(200, ErrorMessage = "City cannot exceed 200 characters.")]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(200, ErrorMessage = "Province cannot exceed 200 characters.")]
        [Display(Name = "Province")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal Code is required.")]
        [StringLength(10, ErrorMessage = "Postal Code cannot exceed 10 characters.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;


        [Display(Name = "Credit Limit")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 1000000, ErrorMessage = "Credit limit must be between 0 and 1,000,000.")]
        public decimal CreditLimit { get; set; } = 5000.00m;

        [Display(Name = "Current Balance")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentBalance { get; set; } = 0.00m;

        [Display(Name = "Payment Terms (days)")]
        [Range(0, 90, ErrorMessage = "Payment terms must be between 0 and 90 days.")]
        public int PaymentTermsDays { get; set; } = 30;

        [Display(Name = "Discount Rate")]
        [Range(0, 100, ErrorMessage = "Discount rate must be between 0 and 100 percent.")]
        public decimal DiscountRate { get; set; } = 0.00m;

        [Display(Name = "Active Status")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Credit Status")]
        public CreditStatus CreditStatus { get; set; } = CreditStatus.Good;

        [Display(Name = "Customer Since")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CustomerSince { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; } = string.Empty;

        [Display(Name = "Last Updated")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Updated By")]
        public string? UpdatedBy { get; set; } = string.Empty;

        [Display(Name = "Operating Hours")]
        [StringLength(100, ErrorMessage = "Operating hours cannot exceed 100 characters.")]
        public string? OperatingHours { get; set; }

        // Navigation properties
        [ValidateNever]
        public virtual ICollection<Fridge> Fridges { get; set; } = new List<Fridge>();

        [ValidateNever]
        [Display(Name = "RelatedAllocation History")]
        public virtual ICollection<FridgeAllocation> AllocationHistory { get; set; } = new List<FridgeAllocation>();

        [Display(Name = "Reported Faults")]
        [ValidateNever]
        public virtual ICollection<FaultRecord>? ReportedFaults { get; set; } = new List<FaultRecord>();

        [Display(Name = "Fridge Requests")]
        [ValidateNever]
        public virtual ICollection<ReplacementRequest> FridgeRequests { get; set; } = new List<ReplacementRequest>();

        [Display(Name = "Maintenance Schedules")]
        [ValidateNever]
        public virtual ICollection<MaintenanceVisit> MaintenanceSchedules { get; set; } = new List<MaintenanceVisit>();

        [NotMapped]
        [Display(Name = "Full Address")]
        public string FullAddress
        {
            get
            {
                var address = AddressLine1;
                if (!string.IsNullOrEmpty(AddressLine2)) address += $", {AddressLine2}";
                address += $", {Suburb}, {City}, {Province}, {PostalCode}";
                return address;
            }
        }

        [NotMapped]
        [Display(Name = "Current Fridge Count")]
        public int CurrentFridgeCount => Fridges?.Count(f => f.IsActive) ?? 0;

        [NotMapped]
        [Display(Name = "Active Allocations")]
        public int ActiveAllocations => AllocationHistory?.Count(a => a.IsActive) ?? 0;

        [NotMapped]
        [Display(Name = "Outstanding Balance")]
        [DataType(DataType.Currency)]
        public decimal OutstandingBalance => CurrentBalance;

        [NotMapped]
        [Display(Name = "Available Credit")]
        [DataType(DataType.Currency)]
        public decimal AvailableCredit => CreditLimit - OutstandingBalance;

        [NotMapped]
        public bool HasActiveFridgeAllocations => ActiveAllocations > 0;

        [NotMapped]
        [Display(Name = "Has Overdue Payments")]
        public bool HasOverduePayments => OutstandingBalance > 0 && CreditStatus == CreditStatus.Blacklisted;

        [NotMapped]
        [Display(Name = "Is Credit Limited")]
        public bool IsCreditLimited => AvailableCredit <= CreditLimit * 0.1m; // Less than 10% credit available
    }
}
