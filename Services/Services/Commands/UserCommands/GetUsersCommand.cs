using Services.Commands.Interfaces;
using Services.Mappers;
using Services.Models;
using Services.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Services.Commands.UserCommands
{
    public class GetUsersCommand : IGetAllCommand<UserDTO>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper<User, UserDTO> _mapper;

        public GetUsersCommand(IRepository<User> repository, IMapper<User, UserDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> Execute()
        {
            IEnumerable<UserDTO> result = _repository.Get().Item1.ToList().Select(x => _mapper.Map(x));
            return result;
        }
    }
}


