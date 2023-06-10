using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;

namespace VolunteeringManagementSystem.Services.TaskEvaluationService.Dto
{
    [AutoMap(typeof(VolunteerTaskEvaluation))]
    public class VolunteerTaskEvaluationDto:EntityDto<Guid>
    {
        public double Rating { get; set; }
        public  string Comments { get; set; }
        public  DateTime EvaluationDate { get; set; }
        public  Guid TaskAssignId { get; set; }
       
        public  Guid EmployeeId { get; set; }
        public  Guid VolunteerId { get; set; }
    }

    [AutoMapTo(typeof(VolunteerTaskEvaluation))]
    public class VolunteerTaskEvaluationAnalysisDto
    {
        public Guid VolunteerId { get; set; }
        public int TotalEvaluations { get; set; }
        public double AverageRating { get; set; }
        // Other analysis properties specific to VolunteerTaskEvaluation
    }

}
