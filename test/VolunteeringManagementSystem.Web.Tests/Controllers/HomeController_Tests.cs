using System.Threading.Tasks;
using VolunteeringManagementSystem.Models.TokenAuth;
using VolunteeringManagementSystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace VolunteeringManagementSystem.Web.Tests.Controllers
{
    public class HomeController_Tests: VolunteeringManagementSystemWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}