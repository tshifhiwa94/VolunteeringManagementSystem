using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Authorization;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Domain.Enum;
using VolunteeringManagementSystem.Services.TaskService.Dto;

namespace VolunteeringManagementSystem.Services.TaskService
{
    //[AbpAuthorize(PermissionNames.Pages_Tasks)]
    //[AbpAuthorize]
    public class TaskItemAppService : ApplicationService, ITaskItemAppService
    {
        private readonly IRepository<TaskItem, Guid> _taskItemRepository;
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IRepository<TaskAssign, Guid> _taskAssignRepository;

        public TaskItemAppService(IRepository<TaskItem, Guid> taskItemRepository, IRepository<Employee, Guid> employeeRepository, IRepository<TaskAssign, Guid> taskAssignRepository)
        {
            _taskItemRepository = taskItemRepository;
            _employeeRepository = employeeRepository;
            _taskAssignRepository = taskAssignRepository;
        }

        public async Task<TaskItemDto> GetAsync(Guid id)
        {

            var taskItem = _taskItemRepository.GetAllIncluding(m => m.Employee).FirstOrDefault(x=>x.Id==id);

            if (taskItem == null)
            {
                throw new UserFriendlyException("This TaskItem  does not exist");
            }
            return ObjectMapper.Map<TaskItemDto>(taskItem);
        }

        public async Task<List<TaskItemDto>> GetAllAsync()
        {
            var taskItems =  _taskItemRepository.GetAllIncluding(m=>m.Employee).ToList();
            if (taskItems == null)
            {
                throw new UserFriendlyException("TaskItems are not there");
            }
            return ObjectMapper.Map<List<TaskItemDto>>(taskItems);
        }


        public async Task<List<TaskItemDto>> GetAllTasksByEmployeeId(Guid employeeId)
        {
            var taskItems =  _taskItemRepository.GetAllIncluding(m => m.Employee)
                                                    .Where(m => m.Employee.Id == employeeId)
                                                    .ToList();

            return ObjectMapper.Map<List<TaskItemDto>>(taskItems);
        }





        public async Task<TaskItemDto> CreateAsync(TaskItemDto input)
        {
            var taskItem = ObjectMapper.Map<TaskItem>(input);
            if(taskItem == null) {
                throw new UserFriendlyException("Task does not exist");
            }
            taskItem.Employee = _employeeRepository.Get(input.EmployeeId);
            

            return ObjectMapper.Map<TaskItemDto>(await _taskItemRepository.InsertAsync(taskItem));
        }

        public async Task<TaskItemDto> UpdateAsync(TaskItemDto input)
        {
            var taskItem = _taskItemRepository.GetAllIncluding(m => m.Employee).FirstOrDefault(x => x.Id == input.Id);
            if (taskItem == null)
            {
                throw new UserFriendlyException("This TaskItem  does not exist of this "+input.Id);
            }
            ObjectMapper.Map(input, taskItem);

            return ObjectMapper.Map<TaskItemDto>(await _taskItemRepository.UpdateAsync(taskItem));
        }

        public async Task DeleteAsync(Guid id)
        {
            var taskItem = await _taskItemRepository.FirstOrDefaultAsync(x => x.Id == id);

            //cant delete a task that is completed
            if (taskItem.Status == RefListTaskStatus.completed) 
            {
                throw new UserFriendlyException("This TaskItem does is completed, you can not delete a completed task " + taskItem.Title);
            }

            await _taskAssignRepository.DeleteAsync(x => x.TaskItem.Id == taskItem.Id);
            await _taskItemRepository.DeleteAsync(taskItem); 

        }
    }

}
