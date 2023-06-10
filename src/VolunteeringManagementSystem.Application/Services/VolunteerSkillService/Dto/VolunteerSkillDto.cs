using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.SkillService.Dto;
using VolunteeringManagementSystem.Services.VolunteerService.Dto;

namespace VolunteeringManagementSystem.Services.VolunteerSkillService.Dto
{


    [AutoMap(typeof(VolunteerSkill))]
    public class VolunteerSkillDto : EntityDto<Guid>
    {
        public Guid SkillId { get; set; }

        public Guid VolunteerId { get; set; }

    }


}
