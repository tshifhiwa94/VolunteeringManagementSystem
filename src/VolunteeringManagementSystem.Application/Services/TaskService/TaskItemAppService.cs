using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.TaskService.Dto;

namespace VolunteeringManagementSystem.Services.TaskService
{
    public class TaskItemAppService : ApplicationService, ITaskItemAppService
    {
        private readonly IRepository<TaskItem, Guid> _taskItemRepository;
        private readonly IRepository<Employee, Guid> _employeeRepository;

        public TaskItemAppService(IRepository<TaskItem, Guid> taskItemRepository, IRepository<Employee, Guid> employeeRepository)
        {
            _taskItemRepository = taskItemRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<TaskItemDto> GetAsync(Guid id)
        {

            var taskItem = _taskItemRepository.GetAllIncluding(m => m.Employee).FirstOrDefault(x=>x.Id==id);
            return ObjectMapper.Map<TaskItemDto>(taskItem);
        }

        public async Task<List<TaskItemDto>> GetAllAsync()
        {
            var taskItems =  _taskItemRepository.GetAllIncluding(m=>m.Employee).ToList();
            return ObjectMapper.Map<List<TaskItemDto>>(taskItems);
        }

        public async Task<TaskItemDto> CreateAsync(TaskItemDto input)
        {
            var taskItem = ObjectMapper.Map<TaskItem>(input);
            taskItem.Employee = _employeeRepository.Get(input.EmployeeId);

            return ObjectMapper.Map<TaskItemDto>(await _taskItemRepository.InsertAsync(taskItem));
        }

        public async Task<TaskItemDto> UpdateAsync(TaskItemDto input)
        {
            var taskItem = _taskItemRepository.GetAllIncluding(m => m.Employee).FirstOrDefault(x => x.Id == input.Id);
            ObjectMapper.Map(input, taskItem);
            return ObjectMapper.Map<TaskItemDto>(await _taskItemRepository.UpdateAsync(taskItem));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _taskItemRepository.DeleteAsync(id);
        }
    }

}
