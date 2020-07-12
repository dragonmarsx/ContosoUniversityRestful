using System;
using System.Collections.Generic;

namespace ContosoUniversity.Core.Entities
{
    public partial class Course
    {
        public Course()
        {
            CourseAssignment = new HashSet<CourseAssignment>();
            Enrollment = new HashSet<Enrollment>();
        }

        public int CourseId { get; set; }
        public int Credits { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<CourseAssignment> CourseAssignment { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
