using Services.Commands.Interfaces;
using Services.Mappers;
using Services.Models;
using Services.Repositories;

namespace Services.Commands.UserCommands
{
    public class GetUserByIDCommand : IGetByIDCommand<UserDTO>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper<User,UserDTO> _mapper;

        public GetUserByIDCommand(IRepository<User> repository, IMapper<User, UserDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserDTO Execute(int id)
        {
            User result = _repository.GetById(id).Item1;
            UserDTO user = _mapper.Map(result);
            return user;
        }
    }
}
