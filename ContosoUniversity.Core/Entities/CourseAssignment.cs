﻿using System;
using System.Collections.Generic;

namespace ContosoUniversity.Core.Entities
{
    public partial class CourseAssignment
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Instructor { get; set; }
    }
}
