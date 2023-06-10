using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Services.TaskEvaluationService.Dto;

namespace VolunteeringManagementSystem.Services.TaskEvaluationService
{
    public interface ITaskEvaluationAppService:IApplicationService
    {
        Task<VolunteerTaskEvaluationDto> GetAsync(Guid id);
        Task<List<VolunteerTaskEvaluationDto>> GetAllTaskEvaluation();
        Task<VolunteerTaskEvaluationDto> CreateAsync(VolunteerTaskEvaluationDto input);
        Task<VolunteerTaskEvaluationDto> UpdateAsync(VolunteerTaskEvaluationDto input);
        Task DeleteAsync(Guid id);

    }
}
