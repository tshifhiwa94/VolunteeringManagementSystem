using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain.Attributes;

namespace VolunteeringManagementSystem.Domain
{
    [Entity(TypeShortAlias = "Vms.TaskAssign")]
    public class TaskAssign: FullAuditedEntity<Guid>
    {
        public virtual DateTime StartDate { get; set; }
        public virtual bool IsSubmitted { get; set; }
        public virtual DateTime? CompletedDate { get; set; }
        public virtual string? FileAttachment { get; set; }

        public virtual TaskItem TaskItem { get; set; }
        public virtual Volunteer Volunteer { get; set;}
    }
}
