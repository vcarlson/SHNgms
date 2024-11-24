using System;  // For DateTime
using System.ComponentModel.DataAnnotations;  // For validation attributes
using SHNgms.Models;  // For Application and User models

namespace SHNgms.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]  // Ensure GrantApplicationId is required
        public int GrantApplicationId { get; set; }

        // Navigation property for related GrantApplication
        public virtual Application GrantApplication { get; set; }

        [Required]  // Ensure ReviewerId is required
        public int ReviewerId { get; set; }

        // Navigation property for related Reviewer (User)
        public virtual User Reviewer { get; set; }

        [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters.")]
        public string Notes { get; set; }

        [Range(1, 5, ErrorMessage = "Feasibility Score must be between 1 and 5.")]
        public int FeasibilityScore { get; set; }

        [Range(1, 5, ErrorMessage = "Impact Score must be between 1 and 5.")]
        public int ImpactScore { get; set; }

        [Range(1, 5, ErrorMessage = "Budget Score must be between 1 and 5.")]
        public int BudgetScore { get; set; }

        [Required]  // Ensure ReviewDate is provided
        public DateTime ReviewDate { get; set; }
    }
}
