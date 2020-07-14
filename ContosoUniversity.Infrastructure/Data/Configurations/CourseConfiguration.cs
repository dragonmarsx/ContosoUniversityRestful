using System;
using System.Collections.Generic;
using System.Text;
using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasIndex(e => e.DepartmentId);

            builder.Property(e => e.CourseId)
                .HasColumnName("CourseID")
                .ValueGeneratedNever();

            builder.Property(e => e.DepartmentId)
                .HasColumnName("DepartmentID")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.Title).HasMaxLength(50);

            builder.HasOne(d => d.Department)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId);
        }
    }
}
