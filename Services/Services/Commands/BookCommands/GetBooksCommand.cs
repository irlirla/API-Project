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
        private readonly BookRepo _repository;
        private readonly BookToBookDTO _mapper;

        public GetBooksCommand(BookRepo repository, BookToBookDTO mapper)
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
