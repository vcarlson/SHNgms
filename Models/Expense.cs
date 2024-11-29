using System;
using System.ComponentModel.DataAnnotations;  // For attributes like Required, Range, etc.

namespace SHNgms.Models
{
    public class Expense
    {
        public int Id { get; set; }                  // Primary Key
        
        [Required] // Ensures Amount is required
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public decimal Amount { get; set; }          // Amount spent
        
        [Required] // Ensures Description is required
        [StringLength(500)] // Optional: Limiting the description to 500 characters
        public required string Description { get; set; }      // Description of the expense
        
        [Required] // Ensures Date is required
        public DateTime Date { get; set; }           // Date of the expense
        
        [Required] // Ensures Category is required
        [StringLength(100)] // Optional: Limiting the category length to 100 characters
        public required string Category { get; set; }         // Category for the expense (e.g., "Office Supplies")

        // Foreign Key Relationship
        public int GrantId { get; set; }             // Foreign Key to Grant
        public required Grant Grant { get; set; }             // Navigation property to Grant
    }
}
