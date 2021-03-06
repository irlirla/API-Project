using Services.Commands.Interfaces;
using Services.Mappers;
using Services.Models;
using Services.Repositories;
using System.Threading.Tasks;

namespace Services.Commands.MovieCommands
{
    public class GetMovieByIDCommand : IAsyncGetByIDCommand<MovieDTO>
    {
        private readonly IAsyncRepository<Movie> _repository;
        private readonly IMapper<Movie, MovieDTO> _mapper;

        public GetMovieByIDCommand(IAsyncRepository<Movie> repository, IMapper<Movie, MovieDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<MovieDTO> Execute(int id)
        {
            var result = await _repository.GetById(id);
            var movie = _mapper.Map(result);
            return movie;
        }
    }
}
