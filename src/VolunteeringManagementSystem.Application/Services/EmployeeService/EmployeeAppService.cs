
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

            employee.User = await CreateUserAsync(input);


            employee.Department = _departmentRepository.Get(input.DepartmentId);
            //employee.Department=await _departmentRepository.InsertAsync(employee.Department);
            //employee.Address = await _addressAppService.InsertAsync(employee.Address);


            await _employeeRepository.InsertAsync(employee);
            return ObjectMapper.Map<EmployeeDto>(employee);
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
                var employee = _employeeRepository.GetAllIncluding(x => x.Department);
                var result = new PagedResultDto<EmployeeDto>();
                result.TotalCount = employee.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<EmployeeDto>>(employee);

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
            var employee = _employeeRepository.GetAllIncluding(x => x.Department).FirstOrDefault(x=>x.Id == Id);

            return ObjectMapper.Map<EmployeeDto>(employee);
        }


        [HttpPut]
        public async  Task<EmployeeDto> UpdateAsync(EmployeeDto input)
        {
            var employee = _employeeRepository.GetAllIncluding(x => x.Department).FirstOrDefault(x => x.Id == input.Id);
            ObjectMapper.Map(employee, input);
            return ObjectMapper.Map<EmployeeDto>(await _employeeRepository.UpdateAsync(employee));

        }

        [HttpPost]
        private async Task<User> CreateUserAsync(EmployeeDto input)
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
