using System;  // For DateTime
using System.ComponentModel.DataAnnotations;  // For validation attributes
using SHNgms.Models;  // For the Grant model (ensure this is the correct namespace for your models)

namespace SHNgms.Models
{
    public class Milestone
{
    public int Id { get; set; }                // Primary Key
    public required string Name { get; set; }           // Milestone name (e.g., "Phase 1")
    public decimal Budget { get; set; }        // The budget allocated for this milestone
    public decimal Spent { get; set; }         // Amount spent on the milestone
    public DateTime TargetDate { get; set; }   // The target date for this milestone

    // Foreign Key Relationship
    public int GrantId { get; set; }           // Foreign Key to Grant
    public required Grant Grant { get; set; }           // Navigation property to Grant
}

}
