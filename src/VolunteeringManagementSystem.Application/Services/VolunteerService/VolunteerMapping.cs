using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Authorization.Users;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.AddressService.Dto;
using VolunteeringManagementSystem.Services.RefListHelper;
using VolunteeringManagementSystem.Services.VolunteerService.Dto;

namespace VolunteeringManagementSystem.Services.VolunteerService
{
    public class VolunteerMapping : Profile
    {
        public VolunteerMapping()
        {
            CreateMap<Volunteer, VolunteerDto>()

              .ForMember(dto => dto.GenderName, opt => opt.MapFrom(src => src.Gender != null && src.Gender != 0 ? src.Gender.GetnumDescription() : null))
                .ForMember(x => x.UserId, m => m.MapFrom(x => x.User != null ? x.User.Id : (long?)null));

            CreateMap<Address, AddressDto>();


            CreateMap<VolunteerDto, User>()
                .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress))
                .ForMember(x => x.Password, m => m.MapFrom(x => x.Password))
                .ForMember(x => x.PhoneNumber, m => m.MapFrom(x => x.Phone))
                .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
                .ForMember(x => x.UserName, m => m.MapFrom(x => x.UserName))
                .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname));


            CreateMap<AddressDto, Volunteer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<VolunteerDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<VolunteerDto, Volunteer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }


    }
}
