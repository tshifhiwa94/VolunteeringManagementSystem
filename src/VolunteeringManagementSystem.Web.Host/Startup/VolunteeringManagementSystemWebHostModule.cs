using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using VolunteeringManagementSystem.Configuration;

namespace VolunteeringManagementSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(VolunteeringManagementSystemWebCoreModule))]
    public class VolunteeringManagementSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public VolunteeringManagementSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VolunteeringManagementSystemWebHostModule).GetAssembly());
        }
    }
}
