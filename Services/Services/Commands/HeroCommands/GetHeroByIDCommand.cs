using Services.Commands.Interfaces;
using Services.Mappers;
using Services.Models;
using Services.Repositories;
using System.Threading.Tasks;

namespace Services.Commands.HeroCommands
{
    public class GetHeroByIDCommand : IAsyncGetByIDCommand<HeroDTO>
    {
        private readonly IAsyncRepository<Hero> _repository;
        private readonly IMapper<Hero, HeroDTO> _mapper;

        public GetHeroByIDCommand(IAsyncRepository<Hero> repository, IMapper<Hero, HeroDTO> mapper)
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
