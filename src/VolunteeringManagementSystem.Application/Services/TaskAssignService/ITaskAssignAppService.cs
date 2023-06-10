using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Services.TaskAssignService.Dto;

namespace VolunteeringManagementSystem.Services.TaskAssignService
{
    public interface ITaskAssignAppService:IApplicationService
    {
        //Task<TaskAssignDto> CreateAsync(TaskAssignDto input);
        Task<TaskAssignDto> UpdateAsync(TaskAssignDto input);

        Task<TaskAssignDto> GetAsync(Guid id);
        Task<List<TaskAssignDto>> GetAllAsync();
        Task DeleteAsnyc(Guid id);



    }
}
