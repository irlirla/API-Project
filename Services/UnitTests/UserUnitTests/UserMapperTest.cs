using Moq;
using NUnit.Framework;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.UserUnitTests
{
    internal class UserMapperTest
    {
        private UserToUserDTO _mapper;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mapper = new UserToUserDTO();
        }

        [Test]
        public void SuccessfulMapUser_Test()
        {
            User user = new()
            {
                Id = 1,
                Name = "Name",
                Age = 1,
                Address = "Address"
            };
            UserDTO userdto = new()
            {
                Name = user.Name,
                Age = user.Age,
                Address = user.Address
            };

            var result = _mapper.Map(user);
            Assert.AreEqual(userdto.Name, result.Name);
            Assert.AreEqual(userdto.Address, result.Address);
            Assert.AreEqual(userdto.Age, result.Age);
        }

        [Test]
        public void FailMapUser_Test()
        {
            User user = new()
            {
                Id = 1,
                Name = "Name",
                Age = 1,
                Address = "Address"
            };
            
            var result = _mapper.Map(user);
            Assert.AreNotEqual(It.IsAny<UserDTO>(), result);
        }
    }
}
