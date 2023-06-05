﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.TaskAssignService.Dto;
using VolunteeringManagementSystem.Services.TaskEvaluationService.Dto;

namespace VolunteeringManagementSystem.Services.TaskAssignService
{
    public class TaskAssignMapping:Profile
    {
        public TaskAssignMapping()
        {
            CreateMap<TaskAssign, TaskAssignDto>()
                .ForMember(x => x.TaskId, m => m.MapFrom(x => x.TaskItem != null ? x.TaskItem.Id : (Guid?)null))
                 .ForMember(x => x.VolunteerId, m => m.MapFrom(x => x.Volunteer != null ? x.Volunteer.Id : (Guid?)null));



            CreateMap<TaskAssignDto, TaskAssign>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}