using System;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContosoUniversity.Infrastructure.Data
{
    public partial class AcademicsDbContext : DbContext
    {
        public AcademicsDbContext()
        {
        }

        public AcademicsDbContext(DbContextOptions<AcademicsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public virtual DbSet<CourseAssignment> CourseAssignments { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}


/*  Annotation:
 *  Consider adding these domain entities: Student and Instructor deriving from Person and
 *  utilizing the Person.Discriminator field to determine either type of person.
 *  This will require 2 additional sets:
 *  
 *  public virtual DbSet<Student> Students { get; set; }
 *  public virtual DbSet<Instructor> Instructors { get; set; }
 * 
 */
