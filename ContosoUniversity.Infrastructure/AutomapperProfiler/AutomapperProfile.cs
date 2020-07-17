using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ContosoUniversity.Core.Dtos;
using ContosoUniversity.Core.Entities;

namespace ContosoUniversity.Infrastructure.AutomapperProfiler
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Department, DepartmentDto>();
        }
    }
}
