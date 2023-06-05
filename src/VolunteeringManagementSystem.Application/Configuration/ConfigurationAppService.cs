using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using VolunteeringManagementSystem.Configuration.Dto;

namespace VolunteeringManagementSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : VolunteeringManagementSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
