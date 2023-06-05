using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Services.TaskAssignService;

namespace VolunteeringManagementSystem.Services.TaskEvaluationService
{
    public class TaskEvaluationAppService:ApplicationService,ITaskAssignAppService
    {
        public TaskEvaluationAppService()
        {
            
        }
    }
}
