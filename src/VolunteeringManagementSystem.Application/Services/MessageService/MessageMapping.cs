using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.MessageService.Dto;
using VolunteeringManagementSystem.Services.TaskEvaluationService.Dto;

namespace VolunteeringManagementSystem.Services.MessageService
{
    public class MessageMapping:Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, MessageDto>()
                 .ForMember(x => x.EmployeeId, m => m.MapFrom(x => x.Employee != null ? x.Employee.Id : (Guid?)null))
                 .ForMember(x => x.TaskAssignId, m => m.MapFrom(x => x.TaskAssign != null ? x.TaskAssign.Id : (Guid?)null))
                 .ForMember(x => x.VolunteerId, m => m.MapFrom(x => x.Volunteer != null ? x.Volunteer.Id : (Guid?)null));


            CreateMap<MessageDto, Message>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
