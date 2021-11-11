using NUnit.Framework;
using Services.Commands.Interfaces;
using Services.Controllers;
using Services.Repositories;
using UnitTests.Mocks.UserService;

namespace UnitTests
{
    public class UserGetTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetUser()
        {
            //Arrange
            var model = new MockUser();
            var controller = new UserController();

            //Act
            //controller.Get(IGetAllCommand<MockUser>);

            //Assert
        }

        [Test]
        public void UserValid()
        {
        }
    }
}