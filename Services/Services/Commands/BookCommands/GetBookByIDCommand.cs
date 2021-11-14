using Services.Commands.Interfaces;
using Services.Mappers;
using Services.Models;
using Services.Repositories;

namespace Services.Commands.BookCommands
{
    public class GetBookByIDCommand : IGetByIDCommand<BookDTO>
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper<Book, BookDTO> _mapper;

        public GetBookByIDCommand(IRepository<Book> repository, IMapper<Book, BookDTO> mapper)
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
