using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Core.Interfaces;
using ContosoUniversity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ContosoUniversityContext _context;

        public DepartmentRepository(ContosoUniversityContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departments = await _context.Department.ToListAsync() as IEnumerable<Department>;
            return departments;
        }
    }
}
