using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Domain.Enum;

namespace VolunteeringManagementSystem.Services.TaskAssignService.Dto
{

    [AutoMap(typeof(TaskAssign))]
    public class TaskAssignDto:EntityDto<Guid>
    {
        public Guid TaskId { get; set; }
        public Guid VolunteerId { get; set; }
        public DateTime StartDate { get; set; }
        public RefListStatus Status { get; set; }
        public DateTime Deadline { get; set; }
        

    }


    [AutoMap(typeof(TaskAssign))]
    public class TaskSubmissionDto : EntityDto<Guid>
    {
        public Guid TaskId { get; set; }
        public Guid VolunteerId { get; set; }
        public RefListStatus Status { get; set; }
        public DateTime CompletedDate { get; set; }
        public string Submission { get; set; }
       
    }

    public class GraphDataDto
    {
        public Guid VolunteerId { get; set; }
        public int Count { get; set; }
    }


}
