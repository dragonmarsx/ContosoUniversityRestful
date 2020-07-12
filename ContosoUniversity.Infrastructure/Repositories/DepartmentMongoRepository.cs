using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Core.Interfaces;
using ContosoUniversity.Infrastructure.Data;

namespace ContosoUniversity.Infrastructure.Repositories
{
    public class DepartmentMongoRepository : IDepartmentRepository
    {
        private readonly ContosoUniversityContext _dbContext;

        public DepartmentMongoRepository(ContosoUniversityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departments = Enumerable.Range(1, 10).Select(x => new Department
            {
                DepartmentId = x,
                InstructorId = x * 2,
                Name = $"Mongo hongo Deptartment#000{x}",
                Budget = 1000 + x * 2,
                StartDate = DateTime.Now,
                RowVersion = new byte[x + 1]
            });
            await Task.Delay(10);
            return departments;
        }
    }
}
