using System;
using System.Collections.Generic;  // For List<T>
using System.ComponentModel.DataAnnotations;  // For the Required and Range attributes
using SHNgms.Models;  // Ensure correct namespace for Application and Milestone models

namespace SHNgms.Models
{
    public class Grant
{
    public int Id { get; set; }                // Primary Key
    public required string GrantTitle { get; set; }     // Title of the Grant
    public required string Funder { get; set; }         // The Funder providing the Grant
    public decimal AllocatedFunds { get; set; } // Total funds allocated for the grant
    public decimal FundsSpent { get; set; }    // Funds that have been spent
    public decimal FundsRemaining => AllocatedFunds - FundsSpent; // Remaining funds
    public DateTime AwardedDate { get; set; }  // The date the grant was awarded
    public DateTime CompletionDate { get; set; } // The expected completion date for the grant

    // Relationships
    public required ICollection<Application> Applications { get; set; } // Related applications
    public required ICollection<Milestone> Milestones { get; set; }     // Related milestones
}


}
