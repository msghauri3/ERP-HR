using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace HR_10.Models
{
    public partial class HRContext : DbContext
    {
        public HRContext()
        {
        }
        public HRContext(DbContextOptions<HRContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Configurations> Configurations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; } // Add this line


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configurations>(entity =>
            {
                entity.HasKey(e => e.Uid)
                      .HasName("PK_Configuration_UID");

                entity.ToTable("Configuration");
            });


            // Add Employee configuration
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.uid);
                entity.Property(e => e.EmployeeID).IsRequired().HasMaxLength(250);
                entity.HasIndex(e => e.EmployeeID).IsUnique();
                entity.Property(e => e.BasicSalary).HasDefaultValue(0.00m);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}
