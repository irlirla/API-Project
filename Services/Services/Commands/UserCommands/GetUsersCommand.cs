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
        private readonly UserRepo _repository;
        private readonly IMapper<User, UserDTO> _mapper;

        public GetUsersCommand(UserRepo repository, UserToUserDTO mapper)
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


