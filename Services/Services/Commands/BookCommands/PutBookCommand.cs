using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;

namespace Services.Commands.BookCommands
{
    public class PutBookCommand : IPutCommand<Book>
    {
        private readonly IRepository<Book> _repository;

        public PutBookCommand(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public void Execute(Book book)
        {
            _repository.Put(book);
        }
    }
}
