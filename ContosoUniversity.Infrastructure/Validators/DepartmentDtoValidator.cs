using System;
using System.Collections.Generic;
using System.Text;
using ContosoUniversity.Core.Dtos;
using FluentValidation;

namespace ContosoUniversity.Infrastructure.Validators
{
    public class DepartmentDtoValidator : AbstractValidator<DepartmentDto>
    {
        public DepartmentDtoValidator()
        {
            RuleFor(e => e.Name).Length(3,50);
            RuleFor(e => e.StartDate).GreaterThan(DateTime.Now);

        }

    }
}

/* 
#1) Part 7 - min37: Web Api Configuration and Fluent Validation 
 
min47:
POST on "/api/department" 
{
    "budget":99.0000,
    "instructorId":101,
    "name":"Ec",
    "startDate":"2007-09-01T00:00:00",
}
response:
{
    "Name": [
        "'Name' must be between 3 and 50 characters. You entered 2 characters."
    ],
    "StartDate": [
        "'Start Date' must be greater than '7/27/2020 9:07:19 AM'."
    ]
}
 
 
 
 
 
 
 
 
 
 
 */
