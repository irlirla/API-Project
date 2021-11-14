using Services.Commands.Interfaces;
using Services.Mappers;
using Services.Models;
using Services.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Services.Commands.HeroCommands
{
    public class GetHeroesCommand : IAsyncGetAllCommand<HeroDTO>
    {
        private readonly IAsyncRepository<Hero> _repository;
        private readonly IMapper<Hero, HeroDTO> _mapper;

        public GetHeroesCommand(IAsyncRepository<Hero> repository, IMapper<Hero, HeroDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HeroDTO>> Execute()
        {
            var result = _repository.Get();
            var heroes = await result;
            var heroes1 = heroes.ToList().Select(x => _mapper.Map(x));
            return heroes1;
        }
    }
}
