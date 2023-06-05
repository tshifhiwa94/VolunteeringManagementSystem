using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Services.EmployeeService.Dto;

namespace VolunteeringManagementSystem.Services.EmployeeService
{
    public interface IEmployeeAppService:IApplicationService
    {
        Task<EmployeeDto> CreateAsync(EmployeeDto input);
        Task<EmployeeDto> UpdateAsync(EmployeeDto input);
        Task<EmployeeDto> GetAsync( Guid Id);
        Task<PagedResultDto<EmployeeDto>> GetAllAsync(PagedAndSortedResultRequestDto input);

        Task DeleteAsync(Guid Id);
    }
}
