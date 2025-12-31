namespace Project.Models.ViewModel
{
    public class UserVM
    {
        public string? Id { get; set; }
        public string? Role { get; set; }
        public bool IsApproved { get; set; }
        public string? RejectionReason { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? CellNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

        public string? CustomerNumber { get; set; }
        public string? BusinessDocumentPath { get; set; }

        public string? EmployeeNumber { get; set; }

        // ADD THESE MISSING PROPERTIES:
        public string? Status { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public DateTime? DeclinedAt { get; set; }

        // Helper properties for user type detection - FIXED: Made them computed properties
        public bool IsCustomer => !string.IsNullOrEmpty(Role) && Role.Contains("Customer");
        public bool IsEmployee => !string.IsNullOrEmpty(Role) && !Role.Contains("Customer");

        // For forms
        public string? RejectionReasonInput { get; set; }
    }
}