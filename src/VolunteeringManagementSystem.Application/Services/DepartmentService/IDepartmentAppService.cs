using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Services.DepartmentService.Dto;

namespace VolunteeringManagementSystem.Services.DepartmentService
{
    public interface IDepartmentAppService:IApplicationService
    {
        Task<DepartmentDto> CreateAsync(DepartmentDto input);
        Task<DepartmentDto> UpdateAsync(DepartmentDto input);

        Task<List<DepartmentDto>> GetAllAsnyc();
        Task<DepartmentDto> GetAsnyc(Guid id);

        Task DeleteAsnyc(Guid id);
    }
}
