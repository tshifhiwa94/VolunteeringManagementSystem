using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Services.TaskEvaluationService.Dto;
using VolunteeringManagementSystem.Services.VolunteerSkillService.Dto;

namespace VolunteeringManagementSystem.Services.VolunteerSkillService
{
    public interface IVolunteerSkillAppService:IApplicationService
    {
        Task<VolunteerSkillDto> GetAsync(Guid id);
        Task<List<VolunteerSkillDto>> GetAllAsync();
        Task<VolunteerSkillDto> CreateAsync(VolunteerSkillInputDto input);
        Task<VolunteerSkillDto> UpdateAsync(VolunteerSkillDto input);
        Task DeleteAsync(Guid id);
    }
}
