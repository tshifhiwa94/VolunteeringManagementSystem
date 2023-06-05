using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Authorization.Users;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.EmployeeService.Dto;
using VolunteeringManagementSystem.Services.RefListHelper;

namespace VolunteeringManagementSystem.Services.PersonService
{
    public class PersonMappingProfile:Profile
    {
        public PersonMappingProfile()
        {

            //CreateMap<Person, PersonDto>()
            //.ForMember(dto => dto.Title, opt => opt.MapFrom(src => src.Title != null && src.Title != 0 ? src.Title.GetnumDescription() : null))
            //.ForMember(dto => dto.Gender, opt => opt.MapFrom(src => src.Gender != null && src.Gender != 0 ? src.Gender.GetnumDescription() : null))
            //.ForMember(dto => dto.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.Id : (long?)null))
            //.ForMember(x => x.AddressId, m => m.MapFrom(x => x.Address != null ? x.Address.Id : (Guid?)null));


            //CreateMap<PersonDto, User>()
            //    .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress))
            //    .ForMember(x => x.Password, m => m.MapFrom(x => x.Password))
            //    .ForMember(x => x.PhoneNumber, m => m.MapFrom(x => x.Phone))
            //    .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
            //    .ForMember(x => x.UserName, m => m.MapFrom(x => x.UserName))
            //    .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname));


            //CreateMap<PersonDto, User>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore());
            //CreateMap<PersonDto, Person>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
