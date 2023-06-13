using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.RefListHelper;
using VolunteeringManagementSystem.Services.TaskService.Dto;
using VolunteeringManagementSystem.Services.VolunteerSkillService.Dto;

namespace VolunteeringManagementSystem.Services.TaskService
{
    public class TaskMapping:Profile
    {
        public TaskMapping()
        {
            CreateMap<TaskItem, TaskItemDto>()
                .ForMember(dto => dto.StatusName, opt => opt.MapFrom(src => src.Status != null && src.Status != 0 ? src.Status.GetnumDescription() : null))
                .ForMember(x => x.EmployeeId, m => m.MapFrom(x => x.Employee != null ? x.Employee.Id : (Guid?)null));


            CreateMap<TaskItemDto, TaskItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
