using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.TaskAssignService.Dto;

namespace VolunteeringManagementSystem.Services.TaskAssignService
{

    public class TaskAssignAppService : ApplicationService, ITaskAssignAppService
    {
        private readonly IRepository<TaskAssign, Guid> _taskAssignRepository;
        private readonly IRepository<TaskItem, Guid> _taskItemRepository;
        private readonly IRepository<Volunteer, Guid> _volunteerRepository;
        public TaskAssignAppService(IRepository<TaskAssign, Guid> taskAssignRepository, IRepository<TaskItem, Guid> taskItemRepository,IRepository<Volunteer, Guid> volunteerRepository)
        {
            _taskAssignRepository = taskAssignRepository;
            _taskItemRepository = taskItemRepository;
            _volunteerRepository = volunteerRepository;
        }
        [HttpGet]
        public async Task<TaskAssignDto> GetAsync(Guid id)
        {

           
            var taskAssign = _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer).FirstOrDefault(x=>x.Id == id);
            return ObjectMapper.Map<TaskAssignDto>(taskAssign);
        }

        [HttpGet]
        public async Task<List<TaskAssignDto>> GetAllAsync()
        {
            var taskAssigns = _taskAssignRepository.GetAllIncluding(x=>x.TaskItem,y=>y.Volunteer).ToList();
            return ObjectMapper.Map<List<TaskAssignDto>>(taskAssigns);
        }

        [HttpPost]
        public async Task<TaskAssignDto> CreateAsync(TaskAssignDto input)
        {
            var taskAssign = ObjectMapper.Map<TaskAssign>(input);

            taskAssign.TaskItem = _taskItemRepository.Get(input.TaskId);
            taskAssign.Volunteer = _volunteerRepository.Get(input.VolunteerId);
            return ObjectMapper.Map<TaskAssignDto>(await _taskAssignRepository.InsertAsync(taskAssign));
        }

        [HttpPut]
        public async Task<TaskAssignDto> UpdateAsync(TaskAssignDto input)
        {
            var taskAssign = _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer).FirstOrDefault(x => x.Id == input.Id);
            ObjectMapper.Map(input, taskAssign);
            return ObjectMapper.Map<TaskAssignDto>(await _taskAssignRepository.UpdateAsync(taskAssign));
        }


        [HttpDelete]
        public async Task DeleteAsnyc(Guid id)
        {
            await _taskAssignRepository.DeleteAsync(id);
        }

        [HttpPost]
      
        public async Task<TaskAssignDto> SubmitTask(Guid id, TaskAssignDto input)
        {
            var task = _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer).FirstOrDefault(x => x.Id == id);
            task.StartDate = input.StartDate;
            task.CompletedDate = input.CompletedDate;
            task.FileAttachment = input.FileAttachment;
            return ObjectMapper.Map<TaskAssignDto>(await _taskAssignRepository.UpdateAsync(task));
        }

        public async Task<List<TaskAssign>> GetAllCompletedTasks()
        {
            return await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer).Where(task => task.CompletedDate != null) .ToListAsync();
        }
     






    }
}
