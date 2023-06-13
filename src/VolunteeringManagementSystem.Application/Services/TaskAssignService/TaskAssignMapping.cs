using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.RefListHelper;
using VolunteeringManagementSystem.Services.TaskAssignService.Dto;
using VolunteeringManagementSystem.Services.TaskEvaluationService.Dto;

namespace VolunteeringManagementSystem.Services.TaskAssignService
{
    public class TaskAssignMapping:Profile
    {
        public TaskAssignMapping()
        {
            CreateMap<TaskAssign, TaskAssignDto>()
                 .ForMember(dto => dto.StatusName, opt => opt.MapFrom(src => src.Status != null && src.Status!= 0 ? src.Status.GetnumDescription() : null))
                .ForMember(x => x.TaskId, m => m.MapFrom(x => x.TaskItem != null ? x.TaskItem.Id : (Guid?)null))
                 .ForMember(x => x.VolunteerId, m => m.MapFrom(x => x.Volunteer != null ? x.Volunteer.Id : (Guid?)null));

            //CreateMap<TaskAssignDto, TaskSubmissionDto>()
            //    .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
            //        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            //        .ForMember(dest => dest.AdditionalInfo, opt => opt.MapFrom(src => src.AdditionalInfo))
            //        .ForMember(dest => dest.FilePath, opt => opt.Ignore())



            CreateMap<TaskAssignDto, TaskAssign>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<TaskSubmissionDto, TaskAssign>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
