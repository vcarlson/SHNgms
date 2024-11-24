using System;  // For DateTime
using System.ComponentModel.DataAnnotations;  // For validation attributes
using SHNgms.Models;  // For the User model (ensure this is the correct namespace for your models)

namespace SHNgms.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]  // Ensures UserId is provided
        public int UserId { get; set; }

        // Navigation property for related User
        public virtual User User { get; set; }

        [Required]  // Ensures Message is provided
        [MaxLength(1000, ErrorMessage = "Message cannot exceed 1000 characters.")]
        public string Message { get; set; }

        public bool IsRead { get; set; }

        [Required]  // Ensures DateCreated is provided
        public DateTime DateCreated { get; set; }

        // New fields:
        public bool IsUrgent { get; set; }  // Boolean to indicate if the notification is urgent
        public string Status { get; set; }  // You can use this for 'Pending', 'Approved', etc.

        // Optionally add a DueDate if you want to compare dates for urgency
        public DateTime? DueDate { get; set; }  // Nullable to handle cases where there's no due date
    }
}
