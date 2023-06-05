using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VolunteeringManagementSystem.Authorization;
using VolunteeringManagementSystem.Authorization.Roles;
using VolunteeringManagementSystem.Authorization.Users;
using VolunteeringManagementSystem.Editions;
using VolunteeringManagementSystem.MultiTenancy;

namespace VolunteeringManagementSystem.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
