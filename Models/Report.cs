using System;  // For DateTime
using System.ComponentModel.DataAnnotations;  // For validation attributes
using SHNgms.Models;  // For the Grant model (ensure this matches the correct namespace for your models)

namespace SHNgms.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Required]  // Ensures GrantId is provided
        public int GrantId { get; set; }

        // Navigation property for related Grant
        public virtual Grant Grant { get; set; }

        [Required]  // Ensures ReportType is provided
        [StringLength(50, ErrorMessage = "Report type cannot exceed 50 characters.")]
        public string ReportType { get; set; }  // Financial, Performance, etc.

        [Required]  // Ensures DateCreated is provided
        public DateTime DateCreated { get; set; }

        [Required]  // Ensures FilePath is provided
        [StringLength(500, ErrorMessage = "File path cannot exceed 500 characters.")]
        public string FilePath { get; set; }
    }
}
