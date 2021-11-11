using Services.Models;
using System.Collections.Generic;

namespace UnitTests.Mocks.HeroService
{
    public class MockHero
    {
        List<Hero> mockHeroList = new()
        {
            new Hero { ID = 1, FirstName = "Harry", SecondName = "Potter", Army = true, Fac = 1 },
            new Hero { ID = 2, FirstName = "Hermione", SecondName = "Granger", Army = true, Fac = 1 },
            new Hero { ID = 3, FirstName = "Ron", SecondName = "Weasley", Army = true, Fac = 1 }
        };

        Hero mockHero = new() { ID = 1, FirstName = "Harry", SecondName = "Potter", Army = true, Fac = 1 };
}
}
