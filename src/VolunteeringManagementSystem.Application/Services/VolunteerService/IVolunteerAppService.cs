using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Services.VolunteerService.Dto;

namespace VolunteeringManagementSystem.Services.VolunteerService
{
    public interface IVolunteerAppService:IApplicationService
    {
        Task<VolunteerDto> CreateAsync(VolunteerDto input);
        Task<VolunteerDto> UpdateAsync(VolunteerDto input);

        Task<List<VolunteerDto>> GetAllAsnyc();
        Task<VolunteerDto> GetAsnyc(Guid id);

        Task DeleteAsnyc(Guid id);
    }
}
