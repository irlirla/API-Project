using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;
using System.Threading.Tasks;

namespace Services.Commands.MovieCommands
{
    public class PostMovieCommand : IAsyncPostCommand<Movie>
    {
        private readonly MovieRepo _repository;

        public PostMovieCommand(MovieRepo repository)
        {
            _repository = repository;
        }
        public async Task Execute(Movie movie)
        {
            await _repository.Post(movie);
        }
    }
}
