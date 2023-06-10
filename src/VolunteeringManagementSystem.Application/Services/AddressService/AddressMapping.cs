using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.AddressService.Dto;
using VolunteeringManagementSystem.Services.EmployeeService.Dto;
using VolunteeringManagementSystem.Services.RefListHelper;

namespace VolunteeringManagementSystem.Services.AddressService
{
    public class AddressMapping:Profile
    {
        public AddressMapping()
        {
            CreateMap<Address, AddressDto>()
           .ForMember(dto => dto.ProvinceName, opt => opt.MapFrom(src => src.Province != null && src.Province != 0 ? src.Province.GetnumDescription() : null));

            CreateMap<AddressDto, Address>()
               .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
