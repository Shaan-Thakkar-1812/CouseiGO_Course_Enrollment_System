using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CourseEnrollmentSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public required string FullName { get; set; }

        [StringLength(500)]
        public string? Address { get; set; } // Nullable to avoid constructor errors

        public DateTime? DateOfBirth { get; set; } // Nullable to prevent forced input

        public string? ProfilePictureUrl { get; set; } // Nullable for optional profile picture

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
