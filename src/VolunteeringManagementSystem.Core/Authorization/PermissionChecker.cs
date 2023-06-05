using Abp.Authorization;
using VolunteeringManagementSystem.Authorization.Roles;
using VolunteeringManagementSystem.Authorization.Users;

namespace VolunteeringManagementSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
