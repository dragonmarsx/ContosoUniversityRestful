using System;

namespace ContosoUniversity.Core.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public decimal Budget { get; set; }
        public int? InstructorId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public byte[] RowVersion { get; set; }

    }
}
