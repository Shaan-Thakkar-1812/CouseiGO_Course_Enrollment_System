using System.ComponentModel.DataAnnotations;

namespace CourseEnrollmentSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(100)]
        public required string FullName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public required string ConfirmPassword { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; } = "Student"; // Default to Student
    }
}
