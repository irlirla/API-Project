using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Services.Models;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.UserUnitTests
{
    internal class UserValidationTest
    {
        private UserValidator _validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            _validator = new UserValidator();
        }

        [Test]
        public void ValidUserRequest_Test()
        {
            User user = new()
            {
                Id = 1,
                Name = "Name",
                Age = 1,
                Address = "Address"
            };

            TestValidationResult<User> result = _validator.TestValidate(user);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidUserRequest_Test()
        {
            User user = new()
            {
                Id = -1,
                Age = -10
            };

            TestValidationResult<User> result = _validator.TestValidate(user);
            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.Age);
            result.ShouldHaveValidationErrorFor(x => x.Address);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
