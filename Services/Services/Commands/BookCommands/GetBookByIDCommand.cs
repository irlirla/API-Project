using Services.Commands.Interfaces;
using Services.Mappers;
using Services.Models;
using Services.Repositories;

namespace Services.Commands.BookCommands
{
    public class GetBookByIDCommand : IGetByIDCommand<BookDTO>
    {
        private readonly BookRepo _repository;
        private readonly BookToBookDTO _mapper;

        public GetBookByIDCommand(BookRepo repository, BookToBookDTO mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BookDTO Execute(int id)
        {
            Book result = _repository.GetById(id).Item1;
            BookDTO book = _mapper.Map(result);
            return book;
        }
    }
}
