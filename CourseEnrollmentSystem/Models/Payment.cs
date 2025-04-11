using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseEnrollmentSystem.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int EnrollmentId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }

        public required Enrollment Enrollment { get; set; } // ✅ Fixed (Required property)
    }
}
