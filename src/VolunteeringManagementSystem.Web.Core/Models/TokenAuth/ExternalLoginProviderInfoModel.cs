using Abp.AutoMapper;
using VolunteeringManagementSystem.Authentication.External;

namespace VolunteeringManagementSystem.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
