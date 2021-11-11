using Services.Commands.Interfaces;
using Services.Mappers;
using Services.Models;
using Services.Repositories;
using System.Threading.Tasks;

namespace Services.Commands.HeroCommands
{
    public class GetHeroByIDCommand : IAsyncGetByIDCommand<HeroDTO>
    {
        private readonly HeroRepo _repository;
        private readonly HeroToHeroDTO _mapper;

        public GetHeroByIDCommand(HeroRepo repository, HeroToHeroDTO mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HeroDTO> Execute(int id)
        {
            var result = await _repository.GetById(id);
            var hero = _mapper.Map(result);
            return hero;
        }
    }
}
