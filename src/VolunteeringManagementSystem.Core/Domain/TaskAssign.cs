using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain.Attributes;
using VolunteeringManagementSystem.Domain.Enum;

namespace VolunteeringManagementSystem.Domain
{
 
    public class TaskAssign: FullAuditedEntity<Guid>
    {
        public virtual DateTime StartDate { get; set; }
        public virtual RefListStatus Status { get; set; }
        public DateTime Deadline { get; set; }
        public virtual DateTime? CompletedDate { get; set; }
        public virtual string? Submission { get; set; }


        public virtual TaskItem TaskItem { get; set; }
        public virtual Volunteer Volunteer { get; set;}

        public virtual List<TaskSkill> RequiredSkills { get; set; }
        public virtual List<VolunteerSkill> VolunteerSkills { get; set; }
    }
}
