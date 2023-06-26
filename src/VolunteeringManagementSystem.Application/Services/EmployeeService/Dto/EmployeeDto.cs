using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Authorization.Users;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Domain.Enum;
using VolunteeringManagementSystem.Services.DepartmentService.Dto;
using VolunteeringManagementSystem.Services.PersonService;

namespace VolunteeringManagementSystem.Services.EmployeeService.Dto
{
    [AutoMap(typeof(Employee))]
    public class EmployeeDto : PersonDto
    {
        public string EmployeeNo { get; set; }
        //public Guid DepartmentId { get; set; }
        //public DepartmentDto? Department { get; set; }

    }
}
