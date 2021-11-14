using FranchiseService.Repositories;
using FranchiseService.Commands.Interfaces;
using FranchiseService.Models;
using System;
using System.Threading.Tasks;

namespace FranchiseService.Commands
{
    public class DeleteFranchiseCommand : IAsyncDeleteCommand<Franchise>
    {
        private readonly IAsyncRepository<Franchise> _repository;

        public DeleteFranchiseCommand(IAsyncRepository<Franchise> repository)
        {
            _repository = repository;
        }

        public async Task Execute(int id)
        {
            await _repository.Delete(id);
        }
    }
}
