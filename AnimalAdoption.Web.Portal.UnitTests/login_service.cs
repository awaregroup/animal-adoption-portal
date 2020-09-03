using AnimalAdoption.Common.Logic;
using FluentAssertions;
using Xunit;

namespace AnimalAdoption.Web.Portal.UnitTests
{
    public class login_service
    {
        [Theory]
        [InlineData("pencil", "Charlie")]
        public void get_login_user_from_id_should_return_correct_users(string password, string username)
        {
            var loginService = new LoginService();
            loginService.GetLoginUserFromId(password).Should().Be(username);
        }
    }
}
