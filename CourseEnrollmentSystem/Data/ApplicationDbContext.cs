using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseEnrollmentSystem.Models;

namespace CourseEnrollmentSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Ensure Identity setup

            // Decimal precision for financial fields
            modelBuilder.Entity<Course>()
                .Property(c => c.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 4);

            // ✅ Foreign key link from Visitor to Identity User
            modelBuilder.Entity<Visitor>()
                .HasOne(v => v.IdentityUser)
                .WithMany()
                .HasForeignKey(v => v.IdentityUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
