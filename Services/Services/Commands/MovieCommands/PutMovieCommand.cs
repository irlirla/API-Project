using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;
using System.Threading.Tasks;

namespace Services.Commands.MovieCommands
{
    public class PutMovieCommand : IAsyncPutCommand<Movie>
    {
        private readonly MovieRepo _repository;

        public PutMovieCommand(MovieRepo repository)
        {
            _repository = repository;
        }
        public async Task Execute(Movie movie)
        {
            await _repository.Put(movie);
        }
    }
}
