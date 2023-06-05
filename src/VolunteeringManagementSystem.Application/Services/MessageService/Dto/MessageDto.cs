using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;

namespace VolunteeringManagementSystem.Services.MessageService.Dto
{
    [AutoMap(typeof(Message))]
    public class MessageDto:EntityDto<Guid>
    {
        public string Title { get; set; }
        public string MessageText { get; set; }
        public  DateTime SentDate { get; set; }
        public  bool IsRead { get; set; }
        public  Guid VolunteerId { get; set; }
        public  Guid EmployeeId { get; set; }

        public  Guid TaskAssignId { get; set; }

    }
}
