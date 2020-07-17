using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Core.Dtos
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public decimal Budget { get; set; }
        public int? InstructorId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
