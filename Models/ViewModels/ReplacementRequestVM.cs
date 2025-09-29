using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models.ViewModels
{
    public class ReplacementRequestVM
    {
        public int Id { get; set; }

        // Core Replacement Information
        [Required(ErrorMessage = "Fridge allocation is required.")]
        [Display(Name = "Faulty Fridge Allocation *")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid fridge allocation.")]
        public int FridgeAllocationId { get; set; }

        [Display(Name = "Related Fault Record")]
        public int? FaultRecordId { get; set; }

        [Display(Name = "Maintenance Record")]
        public int? MaintenanceRecordId { get; set; }

        [Required(ErrorMessage = "Request type is required.")]
        [Display(Name = "Request Type *")]
        public CustomerRequestType RequestType { get; set; }

        [Required(ErrorMessage = "Replacement reason is required.")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
        [Display(Name = "Replacement Reason *")]
        public string Reason { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        [Display(Name = "Quantity *")]
        public int Quantity { get; set; } = 1;

        [Required(ErrorMessage = "Priority is required.")]
        [Display(Name = "Priority *")]
        public CustomerRequestPriority Priority { get; set; } = CustomerRequestPriority.Medium;

        [Required(ErrorMessage = "Requested date is required.")]
        [Display(Name = "Requested Date *")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime RequestedDate { get; set; } = DateTime.Now;

        // Status Tracking
        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status *")]
        public CustomerRequestStatus Status { get; set; } = CustomerRequestStatus.Draft;

        // Replacement Fridge Information
        [Display(Name = "Replacement Fridge")]
        public int? ReplacementFridgeId { get; set; }

        [Display(Name = "Preferred Replacement Model")]
        public int? PreferredReplacementModelId { get; set; }

        [Display(Name = "Urgent Replacement Required")]
        public bool IsUrgent { get; set; }

        [Display(Name = "Customer Notified")]
        public bool CustomerNotified { get; set; }

        [Display(Name = "Notification Date")]
        [DataType(DataType.DateTime)]
        public DateTime? NotificationDate { get; set; }

        // Resolution Information
        [Display(Name = "Replacement Date")]
        [DataType(DataType.DateTime)]
        public DateTime? ReplacementDate { get; set; }

        [Display(Name = "Faulty Fridge Returned")]
        public bool FaultyFridgeReturned { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.DateTime)]
        public DateTime? ReturnDate { get; set; }

        [StringLength(500, ErrorMessage = "Response notes cannot exceed 500 characters.")]
        [Display(Name = "Response Notes")]
        public string? ResponseNotes { get; set; }

        // Assignment Information
        [Display(Name = "Assigned Technician")]
        public int? AssignedTechnicianId { get; set; }

        [Display(Name = "Assigned Date")]
        [DataType(DataType.DateTime)]
        public DateTime? AssignedDate { get; set; }

        // Dropdown Lists
        [ValidateNever]
        public IEnumerable<SelectListItem>? FridgeAllocationList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? FaultRecordList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? MaintenanceRecordList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? EmployeeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? TechnicianList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? ReplacementFridgeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? FridgeModelList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? RequestTypeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? PriorityList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        // Display Properties
        [Display(Name = "Faulty Fridge")]
        public string FaultyFridgeSerial { get; set; } = string.Empty;

        [Display(Name = "Customer")]
        public string CustomerName { get; set; } = string.Empty;

        [Display(Name = "Customer Contact")]
        public string CustomerContact { get; set; } = string.Empty;

        [Display(Name = "Current Location")]
        public string CurrentLocation { get; set; } = string.Empty;

        [Display(Name = "Fault Description")]
        public string FaultDescription { get; set; } = string.Empty;

        [Display(Name = "Fault Reported Date")]
        public DateTime? FaultReportedDate { get; set; }

        // Computed Properties
        [Display(Name = "Days Since Request")]
        public int DaysSinceRequest => (int)(DateTime.Now - RequestedDate).TotalDays;

        [Display(Name = "Days Since Fault Report")]
        public int DaysSinceFaultReport => FaultReportedDate.HasValue ?
            (int)(DateTime.Now - FaultReportedDate.Value).TotalDays : 0;

        [Display(Name = "Replacement Urgency")]
        public string UrgencyLevel
        {
            get
            {
                if (IsUrgent) return "Critical";
                if (DaysSinceFaultReport > 7) return "High";
                if (DaysSinceFaultReport > 3) return "Medium";
                return "Normal";
            }
        }

        [Display(Name = "Requires Approval")]
        public bool RequiresApproval => Priority == CustomerRequestPriority.High ||
                                       Priority == CustomerRequestPriority.Critical ||
                                       PreferredReplacementModelId.HasValue;

        [Display(Name = "Can Be Processed")]
        public bool CanBeProcessed => Status == CustomerRequestStatus.Draft ||
                                     Status == CustomerRequestStatus.Approved;

        [Display(Name = "Requires Technician Visit")]
        public bool RequiresTechnicianVisit => Priority == CustomerRequestPriority.High ||
                                              Priority == CustomerRequestPriority.Critical ||
                                              !string.IsNullOrEmpty(FaultDescription);

        [Display(Name = "Is Completed")]
        public bool IsCompleted => Status == CustomerRequestStatus.Completed;

        [Display(Name = "Can Edit")]
        public bool CanEdit => Status == CustomerRequestStatus.Draft;

        // Validation Methods
        public bool IsValidForSubmission()
        {
            return FridgeAllocationId > 0 &&
                   !string.IsNullOrWhiteSpace(Reason) &&
                   Quantity > 0 &&
                   RequestedDate <= DateTime.Now;
        }

        public IEnumerable<string> GetValidationErrors()
        {
            var errors = new List<string>();

            if (FridgeAllocationId <= 0) errors.Add("Faulty fridge allocation is required");
            if (string.IsNullOrWhiteSpace(Reason)) errors.Add("Replacement reason is required");
            if (Quantity <= 0) errors.Add("Quantity must be greater than 0");
            if (RequestedDate > DateTime.Now) errors.Add("Requested date cannot be in the future");
            if (IsUrgent && !CustomerNotified) errors.Add("Customer must be notified for urgent replacements");

            return errors;
        }

        // Mapping Methods
        public ReplacementRequest ToEntity()
        {
            return new ReplacementRequest
            {
                Id = Id,
                FridgeAllocationId = FridgeAllocationId,
                FaultRecordId = FaultRecordId,
                MaintenanceRecordId = MaintenanceRecordId,
                RequestType = RequestType,
                Reason = Reason,
                Quantity = Quantity,
                Priority = Priority,
                RequestedDate = RequestedDate,
                Status = Status,
                ReplacementFridgeId = ReplacementFridgeId,
                ReplacementDate = ReplacementDate,
                FaultyFridgeReturned = FaultyFridgeReturned,
                ReturnDate = ReturnDate,
                ResponseNotes = ResponseNotes,
                AssignedEmployeeId = AssignedTechnicianId,
                AssignedDate = AssignedDate
            };
        }

        public static ReplacementRequestVM FromEntity(ReplacementRequest entity)
        {
            return new ReplacementRequestVM
            {
                Id = entity.Id,
                FridgeAllocationId = entity.FridgeAllocationId,
                FaultRecordId = entity.FaultRecordId,
                MaintenanceRecordId = entity.MaintenanceRecordId,
                RequestType = entity.RequestType,
                Reason = entity.Reason,
                Quantity = entity.Quantity,
                Priority = entity.Priority,
                RequestedDate = entity.RequestedDate,
                Status = entity.Status,
                ReplacementFridgeId = entity.ReplacementFridgeId,
                IsUrgent = entity.IsUrgent,
                ReplacementDate = entity.ReplacementDate,
                FaultyFridgeReturned = entity.FaultyFridgeReturned,
                ReturnDate = entity.ReturnDate,
                ResponseNotes = entity.ResponseNotes,
                AssignedTechnicianId = entity.AssignedEmployeeId,
                AssignedDate = entity.AssignedDate,
                FaultyFridgeSerial = entity.FaultyFridge?.SerialNumber ?? "Unknown",
                CustomerName = entity.RequestingCustomer?.TradingName ?? "Unknown Customer",
                CurrentLocation = entity.FridgeAllocation?.DeliveryLocation?.ToString() ?? "Unknown Location",
                FaultDescription = entity.FaultRecord?.Description ?? "No fault description",
                FaultReportedDate = entity.FaultRecord?.ReportedDate
            };
        }
    }
}
