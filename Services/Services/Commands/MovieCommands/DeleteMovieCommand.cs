using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;
using System.Threading.Tasks;

namespace Services.Commands.MovieCommands
{
    public class DeleteMovieCommand : IAsyncDeleteCommand<Movie>
    {
        private readonly MovieRepo _repository;

        public DeleteMovieCommand(MovieRepo repository)
        {
            _repository = repository;
        }

        public async Task Execute(int id)
        {
            await _repository.Delete(id);
        }
    }
}
