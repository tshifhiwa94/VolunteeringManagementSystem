using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.RefListHelper;
using VolunteeringManagementSystem.Services.VolunteerService.Dto;

namespace VolunteeringManagementSystem.Services.PersonService
{
   public class PersonMapProfile:Profile
    {
        public PersonMapProfile()
        {

            CreateMap<Person, PersonDto>()

                    .ForMember(dto => dto.GenderName, opt => opt.MapFrom(src => src.Gender!= null && src.Gender != 0 ? src.Gender.GetnumDescription() : null))
                    .ForMember(x => x.UserId, m => m.MapFrom(x => x.User != null ? x.User.Id : (long?)null));



            CreateMap<PersonDto,Person>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
