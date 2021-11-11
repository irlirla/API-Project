using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;

namespace Services.Commands.UserCommands
{
    public class PutUserCommand : IPutCommand<User>
    {
        private readonly UserRepo _repository;

        public PutUserCommand(UserRepo repository)
        {
            _repository = repository;
        }

        public void Execute(User user)
        {
            _repository.Put(user);
        }
    }
}
