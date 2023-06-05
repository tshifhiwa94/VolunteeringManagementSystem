using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;

namespace VolunteeringManagementSystem.Services.TaskAssignService.Dto
{

    [AutoMap(typeof(TaskAssign))]
    public class TaskAssignDto:EntityDto<Guid>
    {
        public DateTime StartDate { get; set; }
        public  DateTime? CompletedDate { get; set; }
        public string? FileAttachment { get; set; }
        public  Guid TaskId { get; set; }
        public  Guid VolunteerId { get; set; }

    }
}
