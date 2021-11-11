using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;
using System.Threading.Tasks;

namespace Services.Commands.HeroCommands
{
    public class DeleteHeroCommand : IAsyncDeleteCommand<Hero>
    {
        private readonly HeroRepo _repository;

        public DeleteHeroCommand(HeroRepo repository)
        {
            _repository = repository;
        }

        public async Task Execute(int id)
        {
            await _repository.Delete(id);
        }
    }
}
