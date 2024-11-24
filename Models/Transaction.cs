using System;  // For DateTime
using System.ComponentModel.DataAnnotations;  // For validation attributes
using SHNgms.Models;  // For the Grant model

namespace SHNgms.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]  // Ensure GrantId is required
        public int GrantId { get; set; }

        // Navigation property for related Grant
        public virtual Grant Grant { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required]  // Ensure TransactionDate is provided
        public DateTime TransactionDate { get; set; }

        [Required]  // Ensure Type is provided
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        public string Type { get; set; } // Disbursement, Expense

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; }
    }
}
