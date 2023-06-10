using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.TaskSkillService.Dto;
using VolunteeringManagementSystem.Services.VolunteerSkillService.Dto;

namespace VolunteeringManagementSystem.Services.TaskSkillService
{
    public class TaskSkillAppService:ApplicationService,ITaskSkillAppService
    {
        private readonly IRepository<TaskSkill,Guid> _taskSkillRepository;
        private readonly IRepository<Skill, Guid> _skillRepository;
        private readonly IRepository<TaskItem, Guid> _taskRepository;
        public TaskSkillAppService(IRepository<TaskSkill, Guid> taskSkillRepository, IRepository<Skill, Guid> skillRepository, IRepository<TaskItem, Guid> taskRepository)
        {
            _skillRepository = skillRepository;
            _taskSkillRepository = taskSkillRepository;
            _taskRepository = taskRepository;
        
        }

        public async Task<TaskSkillDto> CreateAsync(TaskSkillDto input)
        {
            var taskSkill = ObjectMapper.Map<TaskSkill>(input);

            taskSkill.Skill = _skillRepository.Get(input.SkillId);
            taskSkill.TaskItem = _taskRepository.Get(input.TaskItemId);

            return ObjectMapper.Map<TaskSkillDto>(await _taskSkillRepository.InsertAsync(taskSkill));
        }

        public async Task DeleteAsnyc(Guid id)
        {
            await _taskSkillRepository.DeleteAsync(id);
        }

     

        public async  Task<List<TaskSkillDto>> GetAllAsnyc()
        {
            var taskSkills = _taskSkillRepository.GetAllIncluding(s => s.Skill, v => v.TaskItem).ToList();
            return ObjectMapper.Map<List<TaskSkillDto>>(taskSkills);
        }

      

        public async Task<TaskSkillDto> GetAsnyc(Guid id)
        {
            var taskSkill = _taskSkillRepository.GetAllIncluding(s => s.Skill, v => v.TaskItem).FirstOrDefault(x => x.Id == id);
            return ObjectMapper.Map<TaskSkillDto>(taskSkill);
        }

    

        public async Task<TaskSkillDto> UpdateAsync(TaskSkillDto input)
        {
            var taskSkill = _taskSkillRepository.GetAllIncluding(s => s.Skill, v => v.TaskItem).FirstOrDefault(x => x.Id == input.Id);
            ObjectMapper.Map(taskSkill, input);
            return ObjectMapper.Map<TaskSkillDto>(await _taskSkillRepository.UpdateAsync(taskSkill));
        }
    }
}
