using System.Threading.Tasks;
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
    }
}
