using Abp.Application.Services;
using VolunteeringManagementSystem.MultiTenancy.Dto;

namespace VolunteeringManagementSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

