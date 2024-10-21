using Microsoft.EntityFrameworkCore; // Adjust the namespace based on where your models are defined

namespace HRMS.Areas.HRMS.Models
{
    public class HRMSContext : DbContext
    {
        public HRMSContext(DbContextOptions<HRMSContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Payroll> Payroll { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

        // Add other DbSet properties as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configurations can be added here if necessary
            base.OnModelCreating(modelBuilder);
        }
    }
}