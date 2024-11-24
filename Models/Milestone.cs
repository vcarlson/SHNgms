using System;  // For DateTime
using System.ComponentModel.DataAnnotations;  // For validation attributes
using SHNgms.Models;  // For the Grant model (ensure this is the correct namespace for your models)

namespace SHNgms.Models
{
    public class Milestone
    {
        public int Id { get; set; }

        [Required]  // Ensures GrantId is provided
        public int GrantId { get; set; }

        // Navigation property for related Grant
        public virtual Grant Grant { get; set; }

        [Required]  // Ensures Description is provided
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required]  // Ensures DueDate is provided
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
