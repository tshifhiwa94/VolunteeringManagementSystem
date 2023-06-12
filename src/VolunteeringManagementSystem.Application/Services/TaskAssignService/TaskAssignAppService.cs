using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Domain.Enum;
using VolunteeringManagementSystem.Services.TaskAssignService.Dto;
using VolunteeringManagementSystem.Services.TaskEvaluationService.Dto;

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



        //public async Task<TaskAssignDto> AssignTaskToVolunteer(Guid taskId, Guid volunteerId)
        //{
        //    var task = await _taskItemRepository.GetAsync(taskId);
        //    var volunteer = await _volunteerRepository.GetAsync(volunteerId);

        //    if (task == null)
        //    {
        //        throw new ArgumentException("Invalid taskId. Task not found.");
        //    }

        //    if (volunteer == null)
        //    {
        //        throw new ArgumentException("Invalid volunteerId. Volunteer not found.");
        //    }

        //    if (task.RequiredSkills != null || volunteer.Skills != null)
        //    {
        //        var taskSkills = task.RequiredSkills.Split(',').ToList();
        //        var volunteerSkills = volunteer.Skills.Split(',').ToList();



        //        var matchingSkillsCount = taskSkills.Count(ts => volunteerSkills.Contains(ts));

                
        //        var minimumMatchingSkillsCount = 2;

        //        if (matchingSkillsCount < minimumMatchingSkillsCount)
        //        {
        //            throw new InvalidOperationException($"Volunteer does not have at least {minimumMatchingSkillsCount} matching skills for the task.");
        //        }

                
        //    }
        //    if (task.RequiredSkills == null && volunteer.Skills == null)
        //    {
        //        throw new InvalidOperationException("No skills were provided for the task or volunteer.");
        //    }
        //    var taskAssign = new TaskAssign
        //    {
        //        TaskItem = task,
        //        Volunteer = volunteer,
        //        StartDate = DateTime.Now
        //    };

        //    return ObjectMapper.Map<TaskAssignDto>(await _taskAssignRepository.InsertAsync(taskAssign));
        //}




        [HttpGet]
        public async Task<TaskAssignDto> GetAsync(Guid id)
        {
            var taskAssign =await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer).FirstOrDefaultAsync(x=>x.Id == id);
            return ObjectMapper.Map<TaskAssignDto>(taskAssign);
        }

        [HttpGet]
        public async Task<List<TaskAssignDto>> GetAllAsync()
        {
            var taskAssigns = await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer).ToListAsync();
            return ObjectMapper.Map<List<TaskAssignDto>>(taskAssigns);
        }





        [HttpPost]
        public async Task<TaskAssignDto> CreateAsync(TaskAssignDto input)
        {
            if (input == null)
            {
                throw new UserFriendlyException("Some input field are Required");
            }
            var taskAssign = ObjectMapper.Map<TaskAssign>(input);
            if(taskAssign.TaskItem != null && taskAssign.Volunteer !=null) 
            {
                taskAssign.TaskItem = _taskItemRepository.Get(input.TaskId);
                taskAssign.Volunteer = _volunteerRepository.Get(input.VolunteerId);
            }
           
            return ObjectMapper.Map<TaskAssignDto>(await _taskAssignRepository.InsertAsync(taskAssign));
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


        //[HttpPost]
        //public async Task<TaskAssignDto> AssignTaskToVolunteer(Guid taskId, Guid volunteerId)
        //{

        //    var task = await _taskItemRepository.GetAsync(taskId);
        //    var volunteer = await _volunteerRepository.GetAsync(volunteerId);


        //    if (task == null)
        //    {
        //        throw new ArgumentException("Invalid taskId. Task not found.");
        //    }

        //    if (volunteer == null)
        //    {
        //        throw new ArgumentException("Invalid volunteerId. Volunteer not found.");
        //    }


        //    var taskAssign = new TaskAssign
        //    {
        //        TaskItem = task,
        //        Volunteer = volunteer,
        //        StartDate = DateTime.Now
        //    };

        //    return ObjectMapper.Map<TaskAssignDto>(await _taskAssignRepository.InsertAsync(taskAssign));
        //}


        [HttpPost]
        //public async Task<TaskSubmissionDto> SubmitTask(Guid id, TaskSubmissionDto input)
        //{
        //    var task = await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer).FirstOrDefaultAsync(x => x.Id == id);
        //    if (task == null)
        //    {

        //        throw new Exception("Task not found.");
        //    }
        //    task.CompletedDate = input.CompletedDate;
        //    task.Submission = input.Submission;
        //    return ObjectMapper.Map<TaskSubmissionDto>(await _taskAssignRepository.UpdateAsync(task));
        //}



        //public async Task<TaskAssignDto> SubmitTask(Guid Taskid, TaskSubmissionDto input)
        //{
        //    var task = await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer).FirstOrDefaultAsync(x => x.Id == Taskid);
        //    if (task == null)
        //    {

        //        throw new Exception("Task not found.");
        //    }




        //    task.CompletedDate = input.CompletedDate;
        //    task.FilePath = input.FileUpload;
        //    task.Status = input.Status;
        //    return ObjectMapper.Map<TaskAssignDto>(await _taskAssignRepository.UpdateAsync(task));
        //}


        public async Task<TaskAssignDto> SubmitTask(Guid taskId, TaskSubmissionDto input)
        {
            var task = await _taskAssignRepository.GetAllIncluding(x => x.TaskItem, y => y.Volunteer)
                .FirstOrDefaultAsync(x => x.Id == taskId);

            if (task == null)
            {
                throw new Exception("Task not found.");
            }

            // Assign other properties from the input DTO
            task.CompletedDate = input.CompletedDate;
            task.Status = input.Status;

            if (input.FileUpload != null && input.FileUpload.Length > 0)
            {
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyApp", "Storage");
            
                var fileName = Guid.NewGuid().ToString() + "_" + input.FileUpload.FileName;

                var fullFilePath = Path.Combine(filePath, fileName);

                using (var stream = new FileStream(fullFilePath, FileMode.Create))
                {
                    await input.FileUpload.CopyToAsync(stream);
                }

                task.FilePath = fullFilePath; 
            }

            var updatedTask = await _taskAssignRepository.UpdateAsync(task);

            return ObjectMapper.Map<TaskAssignDto>(updatedTask);
        }


        [HttpGet]
        public async Task<List<TaskAssignDto>> GetAllCompletedTasks()
        {
            var completedTasks = await _taskAssignRepository
                .GetAllIncluding(x => x.TaskItem, y => y.Volunteer)
                .Where(task => task.CompletedDate != null)
                .ToListAsync();

            return ObjectMapper.Map<List<TaskAssignDto>>(completedTasks);
        }

        [HttpGet]
        public async Task<List<TaskAssignDto>> GetAllCompletedTasksByVolunteer(Guid volunteerId)
        {
            var completedTasks = await _taskAssignRepository
                .GetAllIncluding(x => x.TaskItem, y => y.Volunteer)
                .Where(task => task.Volunteer.Id == volunteerId && task.CompletedDate != null)
                .ToListAsync();

            return ObjectMapper.Map<List<TaskAssignDto>>(completedTasks);
        }




        [HttpGet]
        public async Task<List<GraphDataDto>> GetCompletedTasksGraph()
        {
            var completedTasks = await GetAllCompletedTasks();

            var groupedTasks = completedTasks.GroupBy(task => task.VolunteerId);

            var graphData = groupedTasks
                .Select(group => new GraphDataDto
                {
                    VolunteerId = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return graphData;
        }




    }
}
