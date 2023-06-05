using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Services.SkillService.Dto;

namespace VolunteeringManagementSystem.Services.SkillService
{
    public interface ISkillAppService:IApplicationService
    {
        Task<SkillDto> CreateAsnyc(SkillDto input);
        Task<SkillDto> UpdateAsync(SkillDto input);

        Task<List<SkillDto>> GetAllAsync();
        Task<SkillDto> GetAsync(Guid id);
        
        Task DeleteAsync(Guid id);
    }
}
