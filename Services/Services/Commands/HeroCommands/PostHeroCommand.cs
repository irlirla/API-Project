using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;
using System.Threading.Tasks;

namespace Services.Commands.HeroCommands
{
    public class PostHeroCommand : IAsyncPostCommand<Hero>
    {
        private readonly HeroRepo _repository;

        public PostHeroCommand(HeroRepo repository)
        {
            _repository = repository;
        }

        public async Task Execute(Hero hero)
        {
            await _repository.Post(hero);
        }
    }
}
