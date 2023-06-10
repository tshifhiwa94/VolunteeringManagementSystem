using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.TaskSkillService.Dto;
using VolunteeringManagementSystem.Services.VolunteerSkillService.Dto;

namespace VolunteeringManagementSystem.Services.TaskSkillService
{
    public class TaskSkillMapping : Profile
    {
        public TaskSkillMapping()
        {
            CreateMap<TaskSkill, TaskSkillDto>()
                .ForMember(x => x.SkillId, m => m.MapFrom(x => x.Skill != null ? x.Skill.Id : (Guid?)null))
                .ForMember(x => x.TaskItemId, m => m.MapFrom(x => x.TaskItem != null ? x.TaskItem.Id : (Guid?)null));


            CreateMap<TaskSkillDto, TaskSkill>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());


        }
    }
}
