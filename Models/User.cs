using System;  // For DateTime, if needed in future
using System.Collections.Generic;  // For List<T>
using System.ComponentModel.DataAnnotations;  // For validation attributes

namespace SHNgms.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [StringLength(20, ErrorMessage = "Role cannot exceed 20 characters.")]
        public string Role { get; set; } // Applicant, Reviewer, Admin, Finance

        [Required(ErrorMessage = "Password is required.")]
        public string PasswordHash { get; set; }

        // Relationships
        public List<Review> Reviews { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
