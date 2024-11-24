using System;
using System.Collections.Generic;  // For List<T>
using System.ComponentModel.DataAnnotations;  // For the Required and Range attributes
using SHNgms.Models;  // Ensure correct namespace for Application and Milestone models

namespace SHNgms.Models
{
    public class Grant
{
    public int Id { get; set; }

    [Required]  // Ensures GrantApplicationId is provided
    public int GrantApplicationId { get; set; }

    // Navigation property for related GrantApplication
    public virtual Application? GrantApplication { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "TotalFundsAllocated must be a positive value.")]
    public decimal TotalFundsAllocated { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "FundsSpent must be a positive value.")]
    public decimal FundsSpent { get; set; }

    // Status validation with a custom range
    [Required]
    [RegularExpression("^(On Track|Delayed|Completed)$", ErrorMessage = "Status must be one of: 'On Track', 'Delayed', or 'Completed'.")]
    public string? Status { get; set; }

    public DateTime AwardedDate { get; set; }

    public DateTime CompletionDate { get; set; }

    // Ensure Milestones is initialized
    public List<Milestone> Milestones { get; set; } = new List<Milestone>();

    // Add Title property here
    public string? Title { get; set; }  // You can adjust the data type and validation as needed
}

}
