using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Services.AddressService.Dto;

namespace VolunteeringManagementSystem.Services.AddressService
{
    public interface IAddressAppService:IApplicationService
    {
        Task<AddressDto> CreateAsync(AddressDto input);
        Task<AddressDto> UpdateAsync(AddressDto input);
        Task<AddressDto> GetAsync(Guid id);
        Task<List<AddressDto>> GetAllAsync();
        Task Delete (Guid id);
    }
}
