using System.Threading.Tasks;
using Abp.Application.Services;
using VolunteeringManagementSystem.Sessions.Dto;

namespace VolunteeringManagementSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
