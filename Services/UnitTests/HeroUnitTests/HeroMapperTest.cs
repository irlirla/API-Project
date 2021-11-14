using Moq;
using NUnit.Framework;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.HeroUnitTests
{
    internal class HeroMapperTest
    {
        private HeroToHeroDTO _mapper;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mapper = new HeroToHeroDTO();
        }

        [Test]
        public void SuccessfulMapHero_Test()
        {
            Hero hero = new()
            {
                ID = 1,
                FirstName = "Name",
                SecondName = "SName",
                Fac = 1,
                Army = true
            };
            HeroDTO herodto = new()
            {
                FirstName = hero.FirstName,
                SecondName = hero.SecondName,
                Fac = hero.Fac,
                Army = hero.Army
            };

            var result = _mapper.Map(hero);
            Assert.AreEqual(herodto.FirstName, result.FirstName);
            Assert.AreEqual(herodto.SecondName, result.SecondName);
            Assert.AreEqual(herodto.Fac, result.Fac);
            Assert.AreEqual(herodto.Army, result.Army);
        }

        [Test]
        public void FailMapHero_Test()
        {
            Hero hero = new()
            {
                ID = 1,
                FirstName = "Name",
                SecondName = "SName",
                Fac = 1,
                Army = true
            };

            var result = _mapper.Map(hero);
            Assert.AreNotEqual(It.IsAny<HeroDTO>(), result);
        }
    }
}
