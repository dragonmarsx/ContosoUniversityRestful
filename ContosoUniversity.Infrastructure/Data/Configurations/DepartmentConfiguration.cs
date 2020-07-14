using System;
using System.Collections.Generic;
using System.Text;
using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.Data.Configurations
{

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
            builder.ToTable("Department");
            builder.HasIndex(e => e.InstructorId);

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            builder.Property(e => e.Budget).HasColumnType("money");

            builder.Property(e => e.InstructorId).HasColumnName("InstructorID");

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.HasOne(d => d.Instructor)
                .WithMany(p => p.Departments)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK_Department_Instructor_InstructorID");
        }
}
}
