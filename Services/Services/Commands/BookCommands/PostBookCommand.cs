using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;

namespace Services.Commands.BookCommands
{
    public class PostBookCommand : IPostCommand<Book>
    {
        private readonly BookRepo _repository;

        public PostBookCommand(BookRepo repository)
        {
            _repository = repository;
        }

        public void Execute(Book book)
        {
            _repository.Post(book);
        }
    }
}
