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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configurations>(entity =>
            {
                entity.HasKey(e => e.Uid)
                      .HasName("PK_Configuration_UID");

                entity.ToTable("Configuration");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}
