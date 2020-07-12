using System;
using System.Collections.Generic;

namespace ContosoUniversity.Core.Entities
{
    public partial class Person
    {
        public Person()
        {
            CourseAssignment = new HashSet<CourseAssignment>();
            Department = new HashSet<Department>();
            Enrollment = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public string LastName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Discriminator { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }
        public virtual ICollection<CourseAssignment> CourseAssignment { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
