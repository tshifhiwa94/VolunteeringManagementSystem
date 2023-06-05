using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.VolunteerService.Dto;
using VolunteeringManagementSystem.Services.VolunteerSkillService.Dto;

namespace VolunteeringManagementSystem.Services.VolunteerSkillService
{
    public class VolunteerSkillMapping:Profile
    {
        public VolunteerSkillMapping()
        {
            CreateMap<VolunteerSkill, VolunteerSkillDto>()
                .ForMember(x => x.SkillId, m => m.MapFrom(x => x.Skill != null ? x.Skill.Id : (Guid?)null))
                .ForMember(x => x.VolunteerId, m => m.MapFrom(x => x.Volunteer != null ? x.Volunteer.Id : (Guid?)null));


            CreateMap<VolunteerSkillDto, VolunteerSkill>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
