using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  // For validation attributes

namespace SHNgms.Models
{
    public enum ApplicationStatus
    {
        Pending,
        UnderReview,
        Approved,
        Rejected
    }

    public class Application
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Applicant Name cannot be longer than 200 characters.")]
        public string ApplicantName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Organization name cannot be longer than 200 characters.")]
        public string Organization { get; set; }

        [Range(1000, 1000000, ErrorMessage = "Funding requested must be between 1,000 and 1,000,000.")]
        public decimal FundingRequested { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Project description cannot be longer than 1000 characters.")]
        public string ProjectDescription { get; set; }

        [Required]
        public DateTime DateSubmitted { get; set; }

        [Required]
        public ApplicationStatus Status { get; set; } // Enum for status

        // Foreign keys and navigation properties
        public virtual List<Review> Reviews { get; set; }
        public virtual List<Document> Documents { get; set; }

        // Additional fields for dashboard calculations (if needed)
        [Range(0, 1000000, ErrorMessage = "Allocated funds must be between 0 and 1,000,000.")]
        public decimal FundsAllocated { get; set; }

        [Range(0, 1000000, ErrorMessage = "Spent funds must be between 0 and 1,000,000.")]
        public decimal FundsSpent { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        // Constructor to set default status
        public Application()
        {
            Status = ApplicationStatus.Pending;
        }
    }
}
