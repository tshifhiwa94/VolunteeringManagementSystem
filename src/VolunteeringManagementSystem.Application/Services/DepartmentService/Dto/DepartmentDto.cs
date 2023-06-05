using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;

namespace VolunteeringManagementSystem.Services.DepartmentService.Dto
{
    [AutoMap(typeof(Department))]
    public class DepartmentDto:EntityDto<Guid>
    {
        public  string Name { get; set; }
        public string Description { get; set; }
    }
}
