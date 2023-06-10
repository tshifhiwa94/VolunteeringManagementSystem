using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringManagementSystem.Domain
{
    public class TaskSkill:FullAuditedEntity<Guid>
    {
        public virtual TaskItem TaskItem { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
