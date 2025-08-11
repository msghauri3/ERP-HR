using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HR.Models;

public partial class PayrollContext : DbContext
{
    public PayrollContext()
    {
    }

    public PayrollContext(DbContextOptions<PayrollContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Configuration> Configurations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=172.20.229.2\\SQLEXPRESS;Database=Payroll;User Id=Admin;Password=Pakistan@786;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_Configuration_UID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
