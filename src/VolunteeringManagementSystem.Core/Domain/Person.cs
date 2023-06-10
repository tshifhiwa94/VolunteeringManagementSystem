using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VolunteeringManagementSystem.Authorization.Users;
using VolunteeringManagementSystem.Domain.Attributes;
using VolunteeringManagementSystem.Domain.Enum;

namespace VolunteeringManagementSystem.Domain
{
    [Entity(TypeShortAlias="Vms.Persons")]
    [Table("Vms_Persons")]
    [DiscriminatorValue("Vms.Persons")]
    public class Person: FullAuditedEntity<Guid>
    {
        public virtual string UserName { get; set; }

        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }

        [StringLength(13)]
        public virtual string IdNumber { get; set; }

        public virtual RefListGender Gender { get; set; }
        public virtual string Phone { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual Address Address { get; set; }
        public User User { get; set; }

        [NotMapped]
        public virtual string[] RoleNames { get; set; }
    }
}
