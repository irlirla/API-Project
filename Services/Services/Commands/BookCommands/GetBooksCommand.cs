using Services.Commands.Interfaces;
using Services.Mappers;
using Services.Models;
using Services.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Services.Commands.BookCommands
{
    public class GetBooksCommand : IGetAllCommand<BookDTO>
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper<Book, BookDTO> _mapper;

        public GetBooksCommand(IRepository<Book> repository, IMapper<Book, BookDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<BookDTO> Execute()
        {
            IEnumerable<BookDTO> result = _repository.Get().Item1.ToList().Select(x => _mapper.Map(x));
            return result;
        }
    }
}
