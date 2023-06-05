using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain.Attributes;

namespace VolunteeringManagementSystem.Domain
{
    [Entity(TypeShortAlias = "Vms.Department")]
    public class Department :FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
