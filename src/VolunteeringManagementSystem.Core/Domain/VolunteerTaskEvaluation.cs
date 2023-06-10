using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain.Attributes;

namespace VolunteeringManagementSystem.Domain
{

    public class VolunteerTaskEvaluation:FullAuditedEntity<Guid>
    {
        public virtual double Rating { get; set; }
        public virtual string Comments { get; set; }
        public virtual DateTime EvaluationDate { get; set;}
        public virtual TaskAssign TaskAssign { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Volunteer Volunteer { get; set; }
    }
}
