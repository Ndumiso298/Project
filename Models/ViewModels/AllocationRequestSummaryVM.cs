using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationRequestSummaryVM
    {
        public int Id { get; set; }

        [Display(Name = "Request Number")]
        public string RequestNumber => $"REQ-{Id:00000}";

        [Display(Name = "Request Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime RequestDate { get; set; }

        [Display(Name = "Status")]
        public AllocationRequestStatus Status { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; } = string.Empty;

        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; } = string.Empty;

        [Display(Name = "Business Type")]
        public BusinessType BusinessType { get; set; }

        [Display(Name = "Total Items")]
        public int TotalItems { get; set; }

        [Display(Name = "Total Monthly Rental")]
        [DataType(DataType.Currency)]
        public decimal TotalMonthlyRental { get; set; }

        [Display(Name = "Total Value")]
        [DataType(DataType.Currency)]
        public decimal TotalValue { get; set; }

        [Display(Name = "Priority")]
        public CustomerRequestPriority Priority { get; set; }

        [Display(Name = "Request Type")]
        public CustomerRequestType RequestType { get; set; }

        // Status Flags
        [Display(Name = "Can Edit")]
        public bool CanEdit => Status == AllocationRequestStatus.Draft;

        [Display(Name = "Can Process")]
        public bool CanProcess => Status == AllocationRequestStatus.Draft ||
                                Status == AllocationRequestStatus.Submitted;

        [Display(Name = "Can Approve")]
        public bool CanApprove => Status == AllocationRequestStatus.UnderReview;

        [Display(Name = "Is Urgent")]
        public bool IsUrgent => Priority == CustomerRequestPriority.Critical;

        [Display(Name = "Is Approved")]
        public bool IsApproved => Status == AllocationRequestStatus.Approved;

        [Display(Name = "Is Completed")]
        public bool IsCompleted => Status == AllocationRequestStatus.Completed;

        // UI Helper Properties
        [Display(Name = "Status Badge Class")]
        public string StatusBadgeClass => Status switch
        {
            AllocationRequestStatus.Draft => "bg-secondary",
            AllocationRequestStatus.Submitted => "bg-info",
            AllocationRequestStatus.UnderReview => "bg-warning",
            AllocationRequestStatus.Approved => "bg-success",
            AllocationRequestStatus.Rejected => "bg-danger",
            AllocationRequestStatus.Completed => "bg-dark",
            AllocationRequestStatus.Cancelled => "bg-dark",
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

        [Display(Name = "Status Display Text")]
        public string StatusDisplayText => Status.ToString();

        [Display(Name = "Priority Display Text")]
        public string PriorityDisplayText => Priority switch
        {
            CustomerRequestPriority.Low => "Low",
            CustomerRequestPriority.Medium => "Medium",
            CustomerRequestPriority.High => "High",
            CustomerRequestPriority.Critical => "Critical",
            _ => "Unknown"
        };

        // Formatting Methods
        public string FormatCurrency(decimal amount) => amount.ToString("C2");
        public string FormatDate(DateTime date) => date.ToString("dd/MM/yyyy HH:mm");
    }
}
