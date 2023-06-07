using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Services.TaskService.Dto;

namespace VolunteeringManagementSystem.Services.TaskService
{
    public interface ITaskItemAppService : IApplicationService
    {
        Task<TaskItemDto> GetAsync(Guid id);
        Task<List<TaskItemDto>> GetAllAsync();
        Task<TaskItemDto> CreateAsync(TaskItemDto input);
        Task<TaskItemDto> UpdateAsync(TaskItemDto input);
        Task DeleteAsync(Guid id);
    }

}
