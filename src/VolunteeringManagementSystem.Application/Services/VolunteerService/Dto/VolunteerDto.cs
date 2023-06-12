using Abp.Application.Services.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Authorization.Users;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Domain.Enum;
using VolunteeringManagementSystem.Services.PersonService;
using VolunteeringManagementSystem.Services.VolunteerSkillService.Dto;

namespace VolunteeringManagementSystem.Services.VolunteerService.Dto
{
    [AutoMap(typeof(Volunteer))]
    public class VolunteerDto:PersonDto
    {
        public  string VolunteerNo { get; set; }
        public  bool IsAvailable { get; set; }
 

    }
}
