using System.ComponentModel.DataAnnotations;

namespace CourseEnrollmentSystem.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public required string CourseName { get; set; } // ✅ Fixed (Non-nullable)

        public decimal Price { get; set; }
    }
}
