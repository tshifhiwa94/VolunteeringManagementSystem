using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain.Attributes;

namespace VolunteeringManagementSystem.Domain
{
    [Entity(TypeShortAlias = "Vms.Employee")]
    [DiscriminatorValue("Vms.Employee")]
    public class Employee:Person
    {
        public virtual string EmpoyeeNo { get; set; }
        public virtual Department Department { get; set;}
    }
}
