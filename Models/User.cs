using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class User
    {
        // Core User Attributes
        public int UserId { get; set; } // Unique identifier
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // Used for login/communication
        public string PhoneNumber { get; set; }

        // Address Information
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        // Account Information
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store hashed password, not plain text
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Rentals
       
    }
}
