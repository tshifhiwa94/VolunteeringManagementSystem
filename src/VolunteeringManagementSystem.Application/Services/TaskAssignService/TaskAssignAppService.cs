using Abp.Application.Services;
using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.UI;
using HomeForHope.Services.StoredFileService.Dto;
using HomeForHope.Services.StoredFileService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Domain.Enum;
using VolunteeringManagementSystem.Services.TaskAssignService.Dto;
using VolunteeringManagementSystem.Services.TaskEvaluationService.Dto;
using VolunteeringManagementSystem.Services.Helpers;
using VolunteeringManagementSystem.Roles.Dto;
using VolunteeringManagementSystem.Roles;

namespace VolunteeringManagementSystem.Services.TaskAssignService
{
    //[AbpAuthorize]
    public class TaskAssignAppService : ApplicationService, ITaskAssignAppService
    {
        private readonly IRepository<TaskAssign, Guid> _taskAssignRepository;
        private readonly IRepository<TaskItem, Guid> _taskItemRepository;
        private readonly IRepository<Volunteer, Guid> _volunteerRepository;
        private readonly IRepository<Employee, Guid> _employeeRepository;
        public TaskAssignAppService(IRepository<TaskAssign, Guid> taskAssignRepository, IRepository<TaskItem, Guid> taskItemRepository,IRepository<Volunteer, Guid> volunteerRepository, IRepository<Employee, Guid> employeeRepository)
        {
            _taskAssignRepository = taskAssignRepository;
            _taskItemRepository = taskItemRepository;
            _volunteerRepository = volunteerRepository;
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public async Task<List<TaskAssignDto>> GetAllTasksAssignedByEmployee(Guid employeeId)
        {
            var taskAssigns = await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer)
                .Where(task => task.TaskItem.Employee.Id == employeeId)
                .ToListAsync();

            return ObjectMapper.Map<List<TaskAssignDto>>(taskAssigns);
        }





        [HttpGet]
        public async Task<TaskAssignDto> GetAsync(Guid id)
        {
            var taskAssign =await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer).FirstOrDefaultAsync(x=>x.Id == id);
            return ObjectMapper.Map<TaskAssignDto>(taskAssign);
        }

        [HttpGet]
        public async Task<List<TaskAssignDto>> GetAllAsync()
        {
            var taskAssigns = await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer).Where(x => x.Status == RefListStatus.completed).ToListAsync();
            return ObjectMapper.Map<List<TaskAssignDto>>(taskAssigns);
        }

        public async Task<List<TaskAssignDto>> GetAllCompletedTasksForEmployee(Guid EmployeeId)
        {
            var taskAssigns = await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer)
                .Where(task=> task.Status==RefListStatus.completed && task.TaskItem.Employee.Id== EmployeeId).ToListAsync();
            return ObjectMapper.Map<List<TaskAssignDto>>(taskAssigns);
        }

        public async Task<List<TaskAssignDto>> GetAllAssignedTasksForEmployee(Guid EmployeeId)
        {
            var taskAssigns = await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer)
                .Where(task=> task.Status == RefListStatus.active|| task.TaskItem.Status ==RefListTaskStatus.assigned && task.TaskItem.Employee.Id == EmployeeId).ToListAsync();
            return ObjectMapper.Map<List<TaskAssignDto>>(taskAssigns);
        }




        public async Task<List<TaskAssignDto>> GetAllCompletedTasksByVolunteer(Guid volunteerId)
        {
            var Tasks = await _taskAssignRepository
                .GetAllIncluding(x => x.TaskItem, z => z.TaskItem.Employee, y => y.Volunteer)
                .Where(task => task.Status == RefListStatus.completed || task.TaskItem.Status == RefListTaskStatus.completed && task.Volunteer.Id == volunteerId)
                .ToListAsync();

            return ObjectMapper.Map<List<TaskAssignDto>>(Tasks);
        }






        [HttpPut]
        public async Task<TaskAssignDto> UpdateAsync(TaskAssignDto input)
        {
            var taskAssign = await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer).FirstOrDefaultAsync(x => x.Id == input.Id);
            ObjectMapper.Map(input, taskAssign);
            return ObjectMapper.Map<TaskAssignDto>(await _taskAssignRepository.UpdateAsync(taskAssign));
        }


        [HttpDelete]
        public async Task DeleteAsnyc(Guid id)
        {
            await _taskAssignRepository.DeleteAsync(id);
        }



        [HttpPost]
        public async Task<TaskAssignDto> SubmitTask(TaskSubmissionDto input)
        {

            var task = await _taskItemRepository.GetAsync(input.TaskId);
            if (task == null)
            {
                throw new UserFriendlyException("Task not found.");
            }

            var taskAssignment = await _taskAssignRepository.FirstOrDefaultAsync(ta =>
                ta.TaskItem.Id == input.TaskId && ta.Volunteer.Id == input.VolunteerId);
            if (taskAssignment == null)
            {
                throw new UserFriendlyException("Task assignment not found.");
            }

            taskAssignment.Status = RefListStatus.completed;
            taskAssignment.CompletedDate = DateTime.Now;
            taskAssignment.File = input.File;
            taskAssignment.Volunteer = taskAssignment.Volunteer;

            if (taskAssignment.CompletedDate > taskAssignment.Deadline)
            {
                task.Status = RefListTaskStatus.overdue;
            }
            else
            {
                task.Status = RefListTaskStatus.completed;
            }

            await _taskItemRepository.UpdateAsync(task);
            await _taskAssignRepository.UpdateAsync(taskAssignment);

            return ObjectMapper.Map<TaskAssignDto>(taskAssignment);
        }



        //[HttpPost]
        //[Consumes("multipart/form-data")]
        //public async Task<TaskAssignDto> SubmitTask([FromForm] TaskSubmissionDto input)
        //{

        //    var task = await _taskItemRepository.GetAsync(input.TaskId);
        //    if (task == null)
        //    {
        //        throw new UserFriendlyException("Task not found.");
        //    }

        //    var taskAssignment = await _taskAssignRepository.FirstOrDefaultAsync(ta =>
        //        ta.TaskItem.Id == input.TaskId && ta.Volunteer.Id == input.VolunteerId);
        //    if (taskAssignment == null)
        //    {
        //        throw new UserFriendlyException("Task assignment not found.");
        //    }

        //    taskAssignment.Status = RefListStatus.completed;
        //    taskAssignment.CompletedDate = DateTime.Now;
        //    taskAssignment.File = input.File;
        //    taskAssignment.Volunteer = taskAssignment.Volunteer;

        //    if (taskAssignment.CompletedDate>taskAssignment.Deadline)
        //    {
        //        task.Status = RefListTaskStatus.overdue;
        //    }
        //    else
        //    {
        //        task.Status = RefListTaskStatus.completed;
        //    }

        //    await _taskItemRepository.UpdateAsync(task);
        //    await _taskAssignRepository.UpdateAsync(taskAssignment);

        //    return ObjectMapper.Map<TaskAssignDto>(taskAssignment);
        //}




        //[HttpPost]
        //[Consumes("multipart/form-data")]
        //public async Task<TaskAssignDto> SubmitTask([FromForm] TaskSubmissionDto input)
        //{
        //    if (!Utils.IsImage(input.File))
        //        throw new ArgumentException("The file is not a valid image.");

        //    var task = await _taskItemRepository.GetAsync(input.TaskId);
        //    if (task == null)
        //    {
        //        throw new UserFriendlyException("Task not found.");
        //    }

        //    var taskAssignment = await _taskAssignRepository.FirstOrDefaultAsync(ta =>
        //        ta.TaskItem.Id == input.TaskId && ta.Volunteer.Id == input.VolunteerId);
        //    if (taskAssignment == null)
        //    {
        //        throw new UserFriendlyException("Task assignment not found.");
        //    }

        //    taskAssignment.Status = RefListStatus.completed;
        //    taskAssignment.CompletedDate = DateTime.Now;

        //    if (input.File != null)
        //    {
        //        var storedFileService = IocManager.Instance.Resolve<StoredFileAppService>();
        //        var storedFileDto = new StoredFileDto { File = input.File };
        //        taskAssignment.File = await storedFileService.CreateStoredFile(storedFileDto);
        //    }

        //    if (taskAssignment.CompletedDate > taskAssignment.Deadline)
        //    {
        //        task.Status = RefListTaskStatus.overdue;
        //    }
        //    else
        //    {
        //        task.Status = RefListTaskStatus.completed;
        //    }

        //    await _taskItemRepository.UpdateAsync(task);
        //    await _taskAssignRepository.UpdateAsync(taskAssignment);

        //    return ObjectMapper.Map<TaskAssignDto>(taskAssignment);
        //}


        [HttpPost]
        public async Task<TaskAssignDto> AssignTaskToVolunteer(TaskAssignDto input)
        {
            var taskAssign = ObjectMapper.Map<TaskAssign>(input);
            taskAssign.TaskItem = await _taskItemRepository.GetAsync(input.TaskId);
            taskAssign.Volunteer = await _volunteerRepository.GetAsync(input.VolunteerId);
            taskAssign.TaskItem.Status = RefListTaskStatus.assigned;
            taskAssign.Status = RefListStatus.active;
            taskAssign.StartDate = DateTime.Now;
            return ObjectMapper.Map<TaskAssignDto>(await _taskAssignRepository.InsertAsync(taskAssign));
        }

     


        [HttpGet]
        public async Task<List<TaskAssignDto>> GetAllTasksForVolunteer(Guid volunteerId)
        {
            var Tasks = await _taskAssignRepository
                .GetAllIncluding(x => x.TaskItem,z=>z.TaskItem.Employee, y => y.Volunteer)
                .Where(task => task.Volunteer.Id == volunteerId)
                .ToListAsync();

            return ObjectMapper.Map<List<TaskAssignDto>>(Tasks);
        }
    }
}
