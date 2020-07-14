using System;
using System.Collections.Generic;

namespace ContosoUniversity.Core.Entities
{
    public partial class Person
    {
        public Person()
        {
            CourseAssignments = new HashSet<CourseAssignment>();
            Departments = new HashSet<Department>();
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public string LastName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Discriminator { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }
        public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
