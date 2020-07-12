using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContosoUniversity.Core.Entities;

namespace ContosoUniversity.Infrastructure.Repositories
{
    public class DepartmentRepository
    {
        public IEnumerable<Department> GetDepartments()
        {
            var departments = Enumerable.Range(1, 3).Select(x => new Department
            {
                Id = x,
                InstructorId = x * 2,
                Name = $"Social Studies Dept0{x}",
                Budget = 1000 + x*2,
                StartDate = DateTime.Now,
                RowVersion = new byte[x+1]
            });
            return departments;
        }
    }
}
