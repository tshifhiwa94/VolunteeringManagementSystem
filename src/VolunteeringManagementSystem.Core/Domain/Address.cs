using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain.Enum;

namespace VolunteeringManagementSystem.Domain
{
    public class Address:FullAuditedEntity<Guid>
    {
        public virtual string StreetName { get; set; }
        public virtual string City { get; set; }
        public virtual RefListProvince Province { get; set; }
        public virtual string PostalCode { get; set; }
       
    }
}
