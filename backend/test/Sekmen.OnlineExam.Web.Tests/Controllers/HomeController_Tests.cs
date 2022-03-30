using Sekmen.OnlineExam.Models.TokenAuth;
using Sekmen.OnlineExam.Web.Controllers;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Sekmen.OnlineExam.Web.Tests.Controllers
{
    public class HomeController_Tests : OnlineExamWebTestBase
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
            var response = await GetResponseAsStringAsync(GetUrl<HomeController>(nameof(HomeController.Index)));

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}