using System;
using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContosoUniversity.Infrastructure.Data
{
    public partial class ContosoUniversityContext : DbContext
    {
        public ContosoUniversityContext()
        {
        }

        public ContosoUniversityContext(DbContextOptions<ContosoUniversityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseAssignment> CourseAssignment { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignment { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId);

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.DepartmentId);
            });

            modelBuilder.Entity<CourseAssignment>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.InstructorId });

                entity.HasIndex(e => e.InstructorId);

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseAssignment)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.CourseAssignment)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("FK_CourseAssignment_Instructor_InstructorID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.InstructorId);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Budget).HasColumnType("money");

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("FK_Department_Instructor_InstructorID");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasIndex(e => e.CourseId);

                entity.HasIndex(e => e.StudentId);

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<OfficeAssignment>(entity =>
            {
                entity.HasKey(e => e.InstructorId);

                entity.Property(e => e.InstructorId)
                    .HasColumnName("InstructorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.HasOne(d => d.Instructor)
                    .WithOne(p => p.OfficeAssignment)
                    .HasForeignKey<OfficeAssignment>(d => d.InstructorId)
                    .HasConstraintName("FK_OfficeAssignment_Instructor_InstructorID");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(N'Instructor')");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

 partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
