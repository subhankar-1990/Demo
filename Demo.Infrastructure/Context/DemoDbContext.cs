using System;
using System.Collections.Generic;
using Demo.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Context;

public partial class DemoDbContext : DbContext
{
    public DemoDbContext()
    {
    }

    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthMaster> AuthMasters { get; set; }

    public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthMaster>(entity =>
        {
            entity.HasKey(e => e.AuthId);

            entity.ToTable("AuthMaster");

            entity.Property(e => e.AuthId).HasDefaultValueSql("(newid())", "DF_AuthMaster_AuthId");
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeMaster>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("EmployeeMaster");

            entity.Property(e => e.EmpId).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmpName).HasMaxLength(50);
            entity.Property(e => e.EmpNo).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_EmployeeMaster_IsActive");
            entity.Property(e => e.Mobile).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
