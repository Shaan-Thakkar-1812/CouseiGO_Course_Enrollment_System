using System.ComponentModel.DataAnnotations.Schema;

namespace CourseEnrollmentSystem.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("VisitorId")]
        public required Visitor Visitor { get; set; } // ✅ Fixed

        [ForeignKey("CourseId")]
        public required Course Course { get; set; } // ✅ Fixed
    }
}
