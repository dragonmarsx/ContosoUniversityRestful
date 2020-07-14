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
        private readonly AcademicsDbContext _context;

        public DepartmentRepository(AcademicsDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync() as IEnumerable<Department>;
            return departments;
        }

        public async Task<Department> GetDepartment(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync( x => x.DepartmentId == id);
            return department;
        }
    }
}
