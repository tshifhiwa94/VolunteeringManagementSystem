using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using VolunteeringManagementSystem.Authorization;

namespace VolunteeringManagementSystem
{
    [DependsOn(
        typeof(VolunteeringManagementSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class VolunteeringManagementSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<VolunteeringManagementSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(VolunteeringManagementSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
