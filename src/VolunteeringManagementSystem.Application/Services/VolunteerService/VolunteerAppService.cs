using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Authorization.Accounts;
using VolunteeringManagementSystem.Authorization.Users;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.EmployeeService.Dto;
using VolunteeringManagementSystem.Services.VolunteerService.Dto;
using VolunteeringManagementSystem.Users.Dto;

namespace VolunteeringManagementSystem.Services.VolunteerService
{
    public class VolunteerAppService:ApplicationService,IVolunteerAppService
    {
        private readonly IRepository<Volunteer,Guid> _volunteerRepository;
        private readonly UserManager _userManager;
        private readonly IRepository<Address, Guid> _addressAppService;
     
        public VolunteerAppService(IRepository<Volunteer, Guid> volunteerRepository, UserManager userManager, IRepository<Address, Guid> addressAppService)
        {
            _volunteerRepository=volunteerRepository;
            _userManager = userManager;
            _addressAppService = addressAppService;
           
        }

        [HttpPost]
        public async Task<VolunteerDto> CreateAsync(VolunteerDto input)
        {
            var volunteer = ObjectMapper.Map<Volunteer>(input);
            if (volunteer == null)
            {
                throw new UserFriendlyException("Input the required Fields");
            }

            volunteer.User = await CreateUserAsync(input);
            //volunteer.Address = await _addressAppService.InsertAsync(volunteer.Address);
            return ObjectMapper.Map<VolunteerDto>(await _volunteerRepository.InsertAsync(volunteer));
        }
        [HttpDelete]
        public async Task DeleteAsnyc(Guid id)
        {
            await _volunteerRepository.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<List<VolunteerDto>> GetAllAsnyc()
        {
            return ObjectMapper.Map<List<VolunteerDto>>(_volunteerRepository.GetAllIncluding(x => x.User));
        }

        [HttpGet]
        public async Task<VolunteerDto> GetAsnyc(Guid id)
        {
            var volunteer = _volunteerRepository.GetAllIncluding(x => x.User).FirstOrDefault(x => x.Id == id);

            if (volunteer == null)
            {
                throw new UserFriendlyException("This volunteer  does not exist");
            }
            return ObjectMapper.Map<VolunteerDto>(volunteer);
        }

        [HttpPut]
        public async Task<VolunteerDto> UpdateAsync(VolunteerDto input)
        {
            var volunteer = _volunteerRepository.GetAllIncluding(x => x.User).FirstOrDefault(x => x.Id == input.Id);
            if (volunteer == null)
            {
                throw new UserFriendlyException("This volunteer  does not exist");
            }
            ObjectMapper.Map(volunteer, input);
            return ObjectMapper.Map<VolunteerDto>(await _volunteerRepository.UpdateAsync(volunteer));
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









