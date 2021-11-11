using Services.Commands.Interfaces;
using Services.Mappers;
using Services.Models;
using Services.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Commands.MovieCommands
{
    public class GetMoviesCommand : IAsyncGetAllCommand<MovieDTO>
    {
        private readonly MovieRepo _repository;
        private readonly IMapper<Movie, MovieDTO> _mapper;

        public GetMoviesCommand(MovieRepo repository, MovieToMovieDTO mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDTO>> Execute()
        {
            var result = _repository.Get();
            var movies = await result;
            var movies1 = movies.ToList().Select(x => _mapper.Map(x));
            return movies1;
        }
    }
}
