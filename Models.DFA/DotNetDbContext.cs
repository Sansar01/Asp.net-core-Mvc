using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_core_Mvc.Models.DFA;

public partial class DotNetDbContext : DbContext
{
    public DotNetDbContext()
    {
    }

    public DotNetDbContext(DbContextOptions<DotNetDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Branch).HasDefaultValue("");
            entity.Property(e => e.StudentGender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teacher");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Salary).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.TeacherAddress)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TeacherName)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
