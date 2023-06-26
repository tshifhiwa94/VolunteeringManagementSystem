using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Domain.Enum;
using VolunteeringManagementSystem.Services.EmployeeService.Dto;
using VolunteeringManagementSystem.Services.TaskService.Dto;
using VolunteeringManagementSystem.Services.VolunteerService.Dto;

namespace VolunteeringManagementSystem.Services.TaskAssignService.Dto
{

    [AutoMap(typeof(TaskAssign))]
    public class TaskAssignDto:EntityDto<Guid>
    {
        //public EntityReferenceDto? Task { get; set; }
        //public EntityReferenceDto? Volunteer { get; set; }

        public Guid TaskId { get; set; }
        public Guid VolunteerId { get; set; }
        public DateTime ?StartDate { get; set; }
        public RefListStatus ?Status { get; set; }
        public string? StatusName { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime ?Deadline { get; set; }
        public string  File { get; set; }
        //public IFormFile? File { get; set; }
        public TaskItemDto? Task { get; set; }
        public VolunteerDto ?Volunteer { get; set; }
        public EmployeeDto ?Employee { get; set; }   

    }


    [AutoMapTo(typeof(TaskAssignDto))]
    public class TaskSubmissionDto : EntityDto<Guid>
    {
        public Guid TaskId { get; set; }
        public Guid VolunteerId { get; set; }

        public string File { get; set; }
        //public IFormFile File { get; set; }
       
    }

    public class GraphDataDto
    {
        public Guid VolunteerId { get; set; }
        public int Count { get; set; }
    }


}
