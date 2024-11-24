using System;
using System.ComponentModel.DataAnnotations;  // For validation attributes
using SHNgms.Models;  // Ensure correct namespace for Application model

namespace SHNgms.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Required]  // Ensure GrantApplicationId is always provided
        public int GrantApplicationId { get; set; }

        // Navigation property for related GrantApplication
        public virtual Application GrantApplication { get; set; }

        [Required]  // Ensure FileName is provided
        [StringLength(200, ErrorMessage = "File name must be less than 200 characters.")]
        public string FileName { get; set; }

        [Required]  // Ensure FilePath is provided
        [StringLength(500, ErrorMessage = "File path must be less than 500 characters.")]
        public string FilePath { get; set; }

        // Automatically set the upload date to the current date if not provided
        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}
