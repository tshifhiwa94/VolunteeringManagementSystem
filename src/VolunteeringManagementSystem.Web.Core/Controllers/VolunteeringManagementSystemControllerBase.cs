using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace VolunteeringManagementSystem.Controllers
{
    public abstract class VolunteeringManagementSystemControllerBase: AbpController
    {
        protected VolunteeringManagementSystemControllerBase()
        {
            LocalizationSourceName = VolunteeringManagementSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
