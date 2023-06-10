using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.VolunteerService;
using VolunteeringManagementSystem.Services.VolunteerSkillService.Dto;

namespace VolunteeringManagementSystem.Services.VolunteerSkillService
{
    public class VolunteerSkillAppService:ApplicationService,IVolunteerSkillAppService
    {
        private readonly IRepository<VolunteerSkill,Guid> _repository;
        private readonly IRepository<Skill, Guid> _skillRepository;
        private readonly IRepository<Volunteer, Guid> _volunteerRepository;
        public VolunteerSkillAppService(IRepository<VolunteerSkill, Guid> repository, IRepository<Skill, Guid> skillRepository, IRepository<Volunteer, Guid> volunteerRepository)
        {
            _repository = repository;
            _skillRepository = skillRepository;
            _volunteerRepository= volunteerRepository;

        }

        public async Task<VolunteerSkillDto> CreateAsync(VolunteerSkillDto input)
        {
            var skill = _skillRepository.Get(input.SkillId);
            var volunteer = _volunteerRepository.Get(input.VolunteerId);


            var volunteerSkill = ObjectMapper.Map<VolunteerSkill>(skill);
            volunteerSkill = ObjectMapper.Map<VolunteerSkill>(volunteer);

            return ObjectMapper.Map<VolunteerSkillDto>(await _repository.InsertAsync(volunteerSkill));
        }



        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id); 
        }

        public async Task<List<VolunteerSkillDto>> GetAllAsync()
        {
            var volunteerSkill =_repository.GetAllIncluding(s => s.Skill, v => v.Volunteer).ToList();
            return ObjectMapper.Map<List<VolunteerSkillDto>>(volunteerSkill);

        }

        public async Task<VolunteerSkillDto> GetAsync(Guid id)
        {
            var volunteerSkill = _repository.GetAllIncluding(s => s.Skill, v => v.Volunteer).FirstOrDefault(x=>x.Id==id);
            return ObjectMapper.Map<VolunteerSkillDto>(volunteerSkill);

        }

        public async Task<VolunteerSkillDto> UpdateAsync(VolunteerSkillDto input)
        {
            var volunteerSkill = _repository.GetAllIncluding(s => s.Skill, v => v.Volunteer).FirstOrDefault(x => x.Id == input.Id);
            ObjectMapper.Map(volunteerSkill, input);
            return ObjectMapper.Map<VolunteerSkillDto>(await _repository.UpdateAsync(volunteerSkill));
        }
    }
}
