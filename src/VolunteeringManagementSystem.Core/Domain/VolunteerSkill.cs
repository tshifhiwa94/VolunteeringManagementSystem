using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain.Attributes;

namespace VolunteeringManagementSystem.Domain
{
    [Entity(TypeShortAlias = "Vms.VolunteerSkill")]
    public class VolunteerSkill:FullAuditedEntity<Guid>
    {
        public virtual Skill Skill { get; set; }
        public virtual Volunteer Volunteer { get; set; }
    }
}
