using HR.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    public virtual DbSet<Employee> Employees { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=172.20.229.2\\SQLEXPRESS;Database=Payroll;User Id=Admin;Password=Pakistan@786;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_Configuration_UID");
        });


        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__Employee__DD701264105802DC");
            entity.HasIndex(e => e.EmployeeID).IsUnique();
        });



        OnModelCreatingPartial(modelBuilder);
    }






    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
