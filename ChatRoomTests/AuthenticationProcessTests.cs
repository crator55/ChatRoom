using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Authentication;
using API.Models;

namespace ChatRoomTests
{
    [TestClass]
    public class AuthenticationProcessTests
    {
        [TestMethod]
        public void ProcessAuthentication_UserIsRegistered_ReturnTrue()
        {
            User user = new User
            {
                Name = "Diego",
                Password = "MTIzNDU2Nzg5"
            };
            Response response = AuthenticationProcess.ProcessAuthentication(user);
            Assert.IsTrue(response.ResponseApi);
        }
        [TestMethod]
        public void ProcessAuthentication_UserIsNotRegistered_ReturnFalse()
        {
            User user = new User
            {
                Name = "Diego",
                Password = "123"
            };
            Response response = AuthenticationProcess.ProcessAuthentication(user);
            Assert.IsFalse(response.ResponseApi);
        }
    }
}
