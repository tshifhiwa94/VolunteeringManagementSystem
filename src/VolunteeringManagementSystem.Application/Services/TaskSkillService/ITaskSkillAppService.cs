using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Services.TaskSkillService.Dto;
using VolunteeringManagementSystem.Services.VolunteerService.Dto;

namespace VolunteeringManagementSystem.Services.TaskSkillService
{
    public interface ITaskSkillAppService:IApplicationService
    {
        Task<TaskSkillDto> CreateAsync(TaskSkillDto input);
        Task<TaskSkillDto> UpdateAsync(TaskSkillDto input);

        Task<List<TaskSkillDto>> GetAllAsnyc();
        Task<TaskSkillDto> GetAsnyc(Guid id);

        Task DeleteAsnyc(Guid id);
    }
}
