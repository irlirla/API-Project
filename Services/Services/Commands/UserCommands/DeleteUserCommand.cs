using Services.Commands.Interfaces;
using Services.Models;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Commands.UserCommands
{
    public class DeleteUserCommand : IDeleteCommand<User>
    {
        private readonly IRepository<User> _repository;

        public DeleteUserCommand(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            _repository.Delete(id);
        }
    }
}
