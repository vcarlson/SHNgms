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
    public int Id { get; set; }              // Primary Key
    public required string Title { get; set; }        // Application title
    public required string Description { get; set; }  // Description of the application
    public decimal RequestedAmount { get; set; } // The amount requested by the applicant
    public ApplicationStatus Status { get; set; } // The current status of the application (e.g., Pending, Approved)

    // Foreign Key Relationship
    public int GrantId { get; set; }         // Foreign Key to Grant
    public required Grant Grant { get; set; }         // Navigation property to Grant
}

}
