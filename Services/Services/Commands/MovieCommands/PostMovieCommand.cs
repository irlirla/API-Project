using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;
using System.Threading.Tasks;

namespace Services.Commands.MovieCommands
{
    public class PostMovieCommand : IAsyncPostCommand<Movie>
    {
        private readonly IAsyncRepository<Movie> _repository;

        public PostMovieCommand(IAsyncRepository<Movie> repository)
        {
            _repository = repository;
        }
        public async Task Execute(Movie movie)
        {
            await _repository.Post(movie);
        }
    }
}
