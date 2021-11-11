using Services.Models;
using System;

namespace Services.Mappers
{
    public class HeroToHeroDTO : IMapper<Hero, HeroDTO>
    {
        public HeroDTO Map(Hero hero)
        {
            if (hero is null)
            {
                return null;
            }
            else
            {
                return new HeroDTO { FirstName = hero.FirstName, SecondName = hero.SecondName, Army = hero.Army, Fac = hero.Fac };
            }
        }
    }
}
