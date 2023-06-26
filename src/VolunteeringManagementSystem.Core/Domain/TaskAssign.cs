using Abp.Domain.Entities.Auditing;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain.Attributes;
using VolunteeringManagementSystem.Domain.Enum;

namespace VolunteeringManagementSystem.Domain
{
 
    public class TaskAssign: FullAuditedEntity<Guid>
    {
        public virtual DateTime? StartDate { get; set; }
        public virtual RefListStatus Status { get; set; }
        public DateTime Deadline { get; set; }
        public virtual DateTime? CompletedDate { get; set; }
        [NotMapped]
        //public virtual IFormFile? File { get; set; }
        public virtual string File { get; set; }
        public virtual TaskItem TaskItem { get; set; }
        public virtual Volunteer Volunteer { get; set;}
    }
}
