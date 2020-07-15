using System.Threading.Tasks;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Core.Interfaces;
using ContosoUniversity.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            //var departments = new DepartmentRepository().GetDepartments();
            var departments = await _departmentRepository.GetDepartments();
            return Ok(departments);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _departmentRepository.GetDepartment(id);
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Department(Department department)
        {
            await _departmentRepository.InsertDepartment(department);
            return Ok(department);
        }

    }
}


/*
 * 
Sample POST department json
{
  "budget": 450000.0000,
  "instructorId": 104,
  "name": "French",
  "startDate": "0001-01-01T00:00:00"
}
 */
