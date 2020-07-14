using System;
using System.Collections.Generic;

namespace ContosoUniversity.Core.Entities
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public partial class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public Grade? Grade { get; set; }
        public int StudentId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Student { get; set; }
    }
}
