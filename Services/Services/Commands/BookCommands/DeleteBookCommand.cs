using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;

namespace Services.Commands.BookCommands
{
    public class DeleteBookCommand : IDeleteCommand<Book>
    {
        private readonly IRepository<Book> _repository;

        public DeleteBookCommand(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            _repository.Delete(id);
        }
    }
}
