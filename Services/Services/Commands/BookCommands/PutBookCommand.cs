using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;

namespace Services.Commands.BookCommands
{
    public class PutBookCommand : IPutCommand<Book>
    {
        private readonly BookRepo _repository;

        public PutBookCommand(BookRepo repository)
        {
            _repository = repository;
        }

        public void Execute(Book book)
        {
            _repository.Put(book);
        }
    }
}
