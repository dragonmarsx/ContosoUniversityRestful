using System;
using System.Collections.Generic;
using System.Text;
using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.Data.Configurations
{
    public class OfficeAssignmentConfiguration : IEntityTypeConfiguration<OfficeAssignment>
    {
        public void Configure(EntityTypeBuilder<OfficeAssignment> builder)
        {
            builder.ToTable("OfficeAssignment");
            builder.HasKey(e => e.InstructorId);

            builder.Property(e => e.InstructorId)
                .HasColumnName("InstructorID")
                .ValueGeneratedNever();

            builder.Property(e => e.Location).HasMaxLength(50);

            builder.HasOne(d => d.Instructor)
                .WithOne(p => p.OfficeAssignment)
                .HasForeignKey<OfficeAssignment>(d => d.InstructorId)
                .HasConstraintName("FK_OfficeAssignment_Instructor_InstructorID");
        }
    }
}
