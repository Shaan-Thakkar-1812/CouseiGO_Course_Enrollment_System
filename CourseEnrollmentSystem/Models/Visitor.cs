using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseEnrollmentSystem.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        // ✅ Foreign key linking to ASP.NET Identity User
        public string IdentityUserId { get; set; } = string.Empty;

        [ForeignKey("IdentityUserId")]
        public ApplicationUser? IdentityUser { get; set; }
    }
}
