using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;
using System.Threading.Tasks;

namespace Services.Commands.HeroCommands
{
    public class PutHeroCommand : IAsyncPutCommand<Hero>
    {
        private readonly IAsyncRepository<Hero> _repository;

        public PutHeroCommand(IAsyncRepository<Hero> repository)
        {
            _repository = repository;
        }

        public async Task Execute(Hero hero)
        {
            await _repository.Put(hero);
        }
    }
}
