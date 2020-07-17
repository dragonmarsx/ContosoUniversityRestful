using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Core.Dtos;
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
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            //var departments = new DepartmentRepository().GetDepartments();
            var departments = await _departmentRepository.GetDepartments();
            var departmentsDto = _mapper.Map <IEnumerable<DepartmentDto>>(departments);
            return Ok(departmentsDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _departmentRepository.GetDepartment(id);
            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return Ok(departmentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Department(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);

            await _departmentRepository.InsertDepartment(department);
            return Ok(departmentDto);
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
