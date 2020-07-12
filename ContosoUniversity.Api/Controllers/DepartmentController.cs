using ContosoUniversity.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Getdepartments()
        {
            var departments = new DepartmentRepository().GetDepartments();
            return Ok(departments);
        }
    }
}
