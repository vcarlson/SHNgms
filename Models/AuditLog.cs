using System;
using System.ComponentModel.DataAnnotations;  // For validation attributes
using SHNgms.Models;  // Ensure the correct namespace for User model

namespace SHNgms.Models
{
    public class AuditLog
    {
        public int Id { get; set; }

        [Required]  // Ensuring that a user is always assigned to the audit log
        public int UserId { get; set; }

        // Navigation property for related User
        public virtual User User { get; set; }

        [Required]  // Ensuring that a timestamp is provided
        public DateTime Timestamp { get; set; } = DateTime.Now;  // Default to current time if not provided

        [Required]
        [StringLength(100, ErrorMessage = "Action must be less than 100 characters.")]
        public string Action { get; set; }

        [StringLength(1000, ErrorMessage = "Details must be less than 1000 characters.")]
        public string Details { get; set; }
    }
}
