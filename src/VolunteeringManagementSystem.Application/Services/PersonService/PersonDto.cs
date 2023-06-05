﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Domain.Enum;

namespace VolunteeringManagementSystem.Services.PersonService
{
    [AutoMap(typeof(Person))]
    public class PersonDto:EntityDto<Guid>
    {
        public  string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public RefListGender Gender { get; set; }
        public RefListTitle Title { get; set; } 

        public long? UserId { get; set; }
        public Guid AddressId { get; set; }

        [NotMapped]
        public string[] RoleNames { get; set; }
    }
}