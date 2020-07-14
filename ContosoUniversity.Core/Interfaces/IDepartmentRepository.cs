using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversity.Core.Entities;

namespace ContosoUniversity.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
    }
}
