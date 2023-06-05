using System.Threading.Tasks;
using Abp.Application.Services;
using VolunteeringManagementSystem.Authorization.Accounts.Dto;

namespace VolunteeringManagementSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
