using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationRequestSummaryVM
    {
        public int Id { get; set; }

        [Display(Name = "Request Number")]
        public string RequestNumber { get; set; } = string.Empty;

        [Display(Name = "Request Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime RequestDate { get; set; }

        [Display(Name = "Status")]
        public AllocationRequestStatus Status { get; set; }

        [Display(Name = "Request Type")]
        public CustomerRequestType RequestType { get; set; }

        [Display(Name = "Priority")]
        public CustomerRequestPriority Priority { get; set; }

        // ===== REPLACEMENT-SPECIFIC PROPERTIES =====
        [Display(Name = "Is Replacement Request")]
        public bool IsReplacementRequest => RequestType == CustomerRequestType.Replacement;

        [Display(Name = "Replacement Reason")]
        public string? ReplacementReason { get; set; }

        [Display(Name = "Is Urgent Replacement")]
        public bool IsUrgentReplacement { get; set; }

        // ===== CUSTOMER INFORMATION =====
        [Display(Name = "Customer")]
        public string CustomerName { get; set; } = string.Empty;

        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; } = string.Empty;

        [Display(Name = "Business Type")]
        public BusinessType BusinessType { get; set; }

        // ===== REQUEST SUMMARY =====
        [Display(Name = "Total Items")]
        public int TotalItems { get; set; }

        [Display(Name = "Total Monthly Rental")]
        [DataType(DataType.Currency)]
        public decimal TotalMonthlyRental { get; set; }

        [Display(Name = "Total Value")]
        [DataType(DataType.Currency)]
        public decimal TotalValue { get; set; }

        // ===== STATUS FLAGS =====
        [Display(Name = "Can Edit")]
        public bool CanEdit => Status == AllocationRequestStatus.Draft;

        [Display(Name = "Can Process")]
        public bool CanProcess => Status == AllocationRequestStatus.Draft ||
                                Status == AllocationRequestStatus.Submitted;

        [Display(Name = "Can Approve")]
        public bool CanApprove => Status == AllocationRequestStatus.UnderReview;

        [Display(Name = "Is Urgent")]
        public bool IsUrgent => Priority == CustomerRequestPriority.High ||
                               Priority == CustomerRequestPriority.Critical;

        [Display(Name = "Is Approved")]
        public bool IsApproved => Status == AllocationRequestStatus.Approved;

        [Display(Name = "Is Completed")]
        public bool IsCompleted => Status == AllocationRequestStatus.Completed;

        // ===== UI HELPER PROPERTIES =====
        [Display(Name = "Status Badge Class")]
        public string StatusBadgeClass => Status switch
        {
            AllocationRequestStatus.Draft => "bg-secondary",
            AllocationRequestStatus.Submitted => "bg-info",
            AllocationRequestStatus.UnderReview => "bg-warning",
            AllocationRequestStatus.Approved => "bg-success",
            AllocationRequestStatus.InProgress => "bg-primary",
            AllocationRequestStatus.Completed => "bg-dark",
            AllocationRequestStatus.Rejected => "bg-danger",
            AllocationRequestStatus.Cancelled => "bg-secondary",
            _ => "bg-secondary"
        };

        [Display(Name = "Priority Badge Class")]
        public string PriorityBadgeClass => Priority switch
        {
            CustomerRequestPriority.Low => "bg-success",
            CustomerRequestPriority.Medium => "bg-info",
            CustomerRequestPriority.High => "bg-warning",
            CustomerRequestPriority.Critical => "bg-danger",
            _ => "bg-secondary"
        };

        [Display(Name = "Request Type Badge Class")]
        public string RequestTypeBadgeClass => RequestType switch
        {
            CustomerRequestType.NewAllocation => "bg-primary",
            CustomerRequestType.Replacement => "bg-warning",
            CustomerRequestType.AdditionalUnits => "bg-info",
            _ => "bg-secondary"
        };

        [Display(Name = "Status Display Text")]
        public string StatusDisplayText => Status.ToString();

        [Display(Name = "Priority Display Text")]
        public string PriorityDisplayText => Priority.ToString();

        [Display(Name = "Request Type Display Text")]
        public string RequestTypeDisplayText => RequestType switch
        {
            CustomerRequestType.NewAllocation => "New Allocation",
            CustomerRequestType.Replacement => "Replacement",
            CustomerRequestType.AdditionalUnits => "Additional Units",
            _ => RequestType.ToString()
        };

        // ===== FORMATTING METHODS =====
        public string FormatCurrency(decimal amount) => amount.ToString("C2");
        public string FormatDate(DateTime date) => date.ToString("dd/MM/yyyy HH:mm");

        // ===== FACTORY METHODS =====
        public static AllocationRequestSummaryVM FromEntity(AllocationRequestHeader entity)
        {
            if (entity == null) return new AllocationRequestSummaryVM();

            return new AllocationRequestSummaryVM
            {
                Id = entity.Id,
                RequestNumber = entity.RequestNumber,
                RequestDate = entity.RequestDate,
                Status = entity.Status,
                RequestType = entity.RequestType,
                Priority = entity.Priority,
                CustomerName = entity.Customer?.BusinessName ?? "Unknown Customer",
                ContactPerson = entity.ContactPerson,
                BusinessType = entity.Customer?.BusinessType ?? BusinessType.SpazaShop,
                TotalItems = entity.RequestDetails.Sum(d => d.Quantity),
                TotalMonthlyRental = entity.TotalMonthlyRental,
                TotalValue = entity.TotalContractValue,
                ReplacementReason = entity.ReplacementReason,
                IsUrgentReplacement = entity.IsUrgentReplacement
            };
        }
    }
}
