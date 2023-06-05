using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringManagementSystem.Domain
{
    public class Message:FullAuditedEntity<Guid>
    {
        public virtual string Title { get; set; }
        public virtual string MessageText{ get; set; }
        public virtual DateTime SentDate { get; set; }
        public virtual bool IsRead { get; set; }
        public virtual Volunteer Volunteer { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual TaskAssign TaskAssign { get; set; }
    }
}
