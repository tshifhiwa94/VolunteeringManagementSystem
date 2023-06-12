using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain.Enum;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.TaskSkillService.Dto;

namespace VolunteeringManagementSystem.Services.TaskService.Dto
{
    [AutoMap(typeof(TaskItem))]
    public class TaskItemDto:EntityDto<Guid>
    {
        public  string Title { get; set; }
        public  string Description { get; set; }
        public string RequiredSkills { get; set; }
        public DateTime DeadLine { get; set; }
        public  RefListStatus Status { get; set; }
        public  Guid EmployeeId { get; set; }
    }
}
