using FluentValidation.TestHelper;
using NUnit.Framework;
using Services.Models;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.HeroUnitTests
{
    internal class HeroValidationTest
    {
        private HeroValidator _validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            _validator = new HeroValidator();
        }

        [Test]
        public void ValidHeroRequest_Test()
        {
            Hero hero = new()
            {
                ID = 1,
                FirstName = "Name",
                SecondName = "Ya",
                Fac = 1,
                Army = true
            };

            TestValidationResult<Hero> result = _validator.TestValidate(hero);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidHeroRequest_Test()
        {
            Hero hero = new()
            {
                ID = -1,
                Fac = -1
            };

            TestValidationResult<Hero> result = _validator.TestValidate(hero);
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
            result.ShouldHaveValidationErrorFor(x => x.SecondName);
            result.ShouldHaveValidationErrorFor(x => x.ID);
            result.ShouldHaveValidationErrorFor(x => x.Fac);
        }
    }
}
