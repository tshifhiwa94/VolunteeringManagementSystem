
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Authorization.Users;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.EmployeeService.Dto;
using VolunteeringManagementSystem.Services.VolunteerService.Dto;

namespace VolunteeringManagementSystem.Services.EmployeeService
{
    //[AbpAuthorize]
    public class EmployeeAppService : ApplicationService, IEmployeeAppService
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IRepository<Department, Guid> _departmentRepository;
        private readonly IRepository<Address, Guid> _addressAppService;
        private readonly UserManager _userManager;
        public EmployeeAppService(IRepository<Employee, Guid> employeeRepository, IRepository<Department, Guid> departmentRepository,
            UserManager userManager, IRepository<Address, Guid> addressAppService)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _userManager = userManager;
            _addressAppService = addressAppService;
        }

        [HttpPost]
        public async Task<EmployeeDto> CreateAsync(EmployeeDto input)
        {
           
            var employee = ObjectMapper.Map<Employee>(input);
            if (employee == null)
            {
                throw new UserFriendlyException("Input the required Fields");
            }

           

            employee.Address = await _addressAppService.InsertAsync(employee.Address);
            employee.User = await CreateUserAsync(input);

            
            return ObjectMapper.Map<EmployeeDto>(await _employeeRepository.InsertAsync(employee));
        }



        [HttpDelete]
        public async Task DeleteAsync(Guid Id)
        {
            await _employeeRepository.DeleteAsync(Id);
        }

        [HttpGet]
        public async Task<PagedResultDto<EmployeeDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var employees =await _employeeRepository.GetAllIncluding(x=>x.Address).ToListAsync();
                var result = new PagedResultDto<EmployeeDto>();
                result.TotalCount = employees.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<EmployeeDto>>(employees);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet]
        public async Task<EmployeeDto> GetAsync(Guid Id)
        {
            var employee = await _employeeRepository.GetAllIncluding(x=>x.Address).FirstOrDefaultAsync(x=>x.Id == Id);
            if (employee == null)
            {
                throw new UserFriendlyException("Employee does not exist");
            }

            return ObjectMapper.Map<EmployeeDto>(employee);
        }

        [HttpGet]
        public async Task<EmployeeDto> GetEmployeeByUserId(long userId)
        {
            var employee = await _employeeRepository.GetAllIncluding(x => x.Address).FirstOrDefaultAsync(x => x.User.Id == userId);

            if (employee == null)
            {
                throw new UserFriendlyException("Employee does not exist");
            }

       
            return ObjectMapper.Map<EmployeeDto>(employee);
        }



        [HttpPut]
        public async  Task<EmployeeDto> UpdateAsync(EmployeeDto input)
        {
            string[] role = new string[] { "SUPERVISOR" };
            var employee = _employeeRepository.GetAllIncluding(x=>x.Address).FirstOrDefault(x => x.Id == input.Id);
            if (employee == null)
            {
                throw new UserFriendlyException("Employee does not exist");
            }
            ObjectMapper.Map(employee, input);
            return ObjectMapper.Map<EmployeeDto>(await _employeeRepository.UpdateAsync(employee));

        }

        private async Task<User> CreateUserAsync(EmployeeDto input)
        {
           
            var user = ObjectMapper.Map<User>(input);
            input.RoleNames = new string[] { "Supervisor" };

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
