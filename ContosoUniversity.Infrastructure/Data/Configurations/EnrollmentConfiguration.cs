using System;
using System.Collections.Generic;
using System.Text;
using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.Data.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");
            builder.HasIndex(e => e.CourseId);

            builder.HasIndex(e => e.StudentId);

            builder.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

            builder.Property(e => e.CourseId).HasColumnName("CourseID");

            builder.Property(e => e.StudentId).HasColumnName("StudentID");

            builder.HasOne(d => d.Course)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId);

            builder.HasOne(d => d.Student)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId);
        }
    }
}
