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

    public class TaskItem:FullAuditedEntity<Guid>
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }

        public virtual DateTime DeadLine { get; set; }
        public virtual RefListStatus Status { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
