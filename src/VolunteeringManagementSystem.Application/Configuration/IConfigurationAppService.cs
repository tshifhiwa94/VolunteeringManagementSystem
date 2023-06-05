using System.Threading.Tasks;
using VolunteeringManagementSystem.Configuration.Dto;

namespace VolunteeringManagementSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
