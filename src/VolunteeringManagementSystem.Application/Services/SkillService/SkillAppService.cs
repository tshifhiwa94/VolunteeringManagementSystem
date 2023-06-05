using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.PersonService;
using VolunteeringManagementSystem.Services.SkillService.Dto;

namespace VolunteeringManagementSystem.Services.SkillService
{
    public class SkillAppService:ApplicationService,ISkillAppService
    {
        private readonly IRepository<Skill, Guid> _skillRepository;

        public SkillAppService(IRepository<Skill, Guid> skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpPost]
        public async Task<SkillDto> CreateAsnyc(SkillDto input)
        {
            var skill = ObjectMapper.Map<Skill>(input);
            return ObjectMapper.Map<SkillDto>(await _skillRepository.InsertAsync(skill));
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _skillRepository.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<List<SkillDto>> GetAllAsync()
        {
            var skill =await _skillRepository.GetAllListAsync();
            return ObjectMapper.Map<List<SkillDto>>(skill);
        }
        [HttpGet]
        public async Task<SkillDto> GetAsync(Guid id)
        {
           var skill = await _skillRepository.GetAsync(id); 
            return ObjectMapper.Map<SkillDto>(skill);
        }

        [HttpPut]
        public async Task<SkillDto> UpdateAsync(SkillDto input)
        {
            var skill = _skillRepository.Get(input.Id);
            var update = await _skillRepository.UpdateAsync(ObjectMapper.Map(input, skill));
            return ObjectMapper.Map<SkillDto>(update);
        }
    }
}
