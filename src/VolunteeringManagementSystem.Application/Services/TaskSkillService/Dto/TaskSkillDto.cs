using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;

namespace VolunteeringManagementSystem.Services.TaskSkillService.Dto
{
    [AutoMap(typeof(TaskSkill))]
    public class TaskSkillDto:EntityDto<Guid>
    {
        public Guid TaskItemId { get; set; }
        public Guid SkillId { get; set; }
    }
}
