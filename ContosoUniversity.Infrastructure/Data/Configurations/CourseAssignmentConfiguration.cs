using System;
using System.Collections.Generic;
using System.Text;
using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.Data.Configurations
{
    public class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> builder)
        {
            builder.ToTable("CourseAssignment");
            builder.HasKey(e => new { e.CourseId, e.InstructorId });

            builder.HasIndex(e => e.InstructorId);

            builder.Property(e => e.CourseId).HasColumnName("CourseID");

            builder.Property(e => e.InstructorId).HasColumnName("InstructorID");

            builder.HasOne(d => d.Course)
                .WithMany(p => p.CourseAssignments)
                .HasForeignKey(d => d.CourseId);

            builder.HasOne(d => d.Instructor)
                .WithMany(p => p.CourseAssignments)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK_CourseAssignment_Instructor_InstructorID");
        }
    }
}
