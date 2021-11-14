using Microsoft.AspNetCore.Identity;
using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;
using Services.Validators;

namespace Services.Commands.UserCommands
{
    public class PostUserCommand : IPostCommand<User>
    {
        private readonly IRepository<User> _repository;

        public PostUserCommand(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Execute(User user)
        {
            _repository.Post(user);
        }
    }
}
