using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.TaskService.Dto;
using VolunteeringManagementSystem.Services.VolunteerSkillService.Dto;

namespace VolunteeringManagementSystem.Services.TaskService
{
    public class TaskMapping:Profile
    {
        public TaskMapping()
        {
            CreateMap<TaskItem, TaskItemDto>()
                .ForMember(x => x.EmployeeId, m => m.MapFrom(x => x.Employee != null ? x.Employee.Id : (Guid?)null));


            CreateMap<TaskItemDto, TaskItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
