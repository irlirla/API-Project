using Services.Commands.Interfaces;
using Services.Mappers;
using Services.Models;
using Services.Repositories;

namespace Services.Commands.UserCommands
{
    public class GetUserByIDCommand : IGetByIDCommand<UserDTO>
    {
        private readonly UserRepo _repository;
        private readonly UserToUserDTO _mapper;

        public GetUserByIDCommand(UserRepo repository, UserToUserDTO mapper)
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
