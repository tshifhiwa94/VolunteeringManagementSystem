using AutoMapper;
using HomeForHope.Services.StoredFileService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.PersonService;

namespace VolunteeringManagementSystem.Services.StoredFileService.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<StoredFileDto, StoredFile>()
               .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
