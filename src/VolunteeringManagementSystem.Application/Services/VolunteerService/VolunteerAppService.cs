using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Authorization.Users;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.EmployeeService.Dto;
using VolunteeringManagementSystem.Services.VolunteerService.Dto;

namespace VolunteeringManagementSystem.Services.VolunteerService
{
    public class VolunteerAppService:ApplicationService,IVolunteerAppService
    {
        private readonly IRepository<Volunteer,Guid> _repository;
        private readonly UserManager _userManager;
        public VolunteerAppService(IRepository<Volunteer, Guid> repository, UserManager userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<VolunteerDto> CreateAsync(VolunteerDto input)
        {
            var volunteer = ObjectMapper.Map<Volunteer>(input);
            volunteer.User = await CreateUserAsync(input);
            return ObjectMapper.Map<VolunteerDto>(await _repository.InsertAsync(volunteer));

        }
        [HttpDelete]
        public async Task DeleteAsnyc(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<List<VolunteerDto>> GetAllAsnyc()
        {
            return ObjectMapper.Map<List<VolunteerDto>>(_repository.GetAllIncluding(x => x.User));
        }

        [HttpGet]
        public async Task<VolunteerDto> GetAsnyc(Guid id)
        {
            return ObjectMapper.Map<VolunteerDto>(_repository.GetAllIncluding(x => x.User).FirstOrDefault(x => x.Id == id));
        }

        [HttpPut]
        public async Task<VolunteerDto> UpdateAsync(VolunteerDto input)
        {
            var volunteer = _repository.GetAllIncluding(x => x.User).FirstOrDefault(x => x.Id == input.Id);
            ObjectMapper.Map(volunteer, input);
            return ObjectMapper.Map<VolunteerDto>(await _repository.UpdateAsync(volunteer));
        }

        [HttpPost]
        private async Task<User> CreateUserAsync(VolunteerDto input)
        {
            var user = ObjectMapper.Map<User>(input);
            if (!string.IsNullOrEmpty(user.NormalizedEmailAddress) && !string.IsNullOrEmpty(user.NormalizedUserName))
                user.SetNormalizedNames();

            user.TenantId = AbpSession.TenantId;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));
            }
            return user;

        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

    }
}
