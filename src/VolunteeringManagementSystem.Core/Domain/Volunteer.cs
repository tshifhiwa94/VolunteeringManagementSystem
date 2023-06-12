using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain.Attributes;

namespace VolunteeringManagementSystem.Domain
{
    [Entity(TypeShortAlias = "Vms.Volunteer")]
    [DiscriminatorValue("Vms.Volunteer")]
    public class Volunteer:Person
    {
        public virtual string VolunteerNo { get; set; }
        public virtual bool IsAvailable { get; set; }
    }
}
