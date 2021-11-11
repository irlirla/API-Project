using FranchiseService.Repositories;
using FranchiseService.Commands.Interfaces;
using FranchiseService.Models;
using System;
using System.Threading.Tasks;

namespace FranchiseService.Commands
{
    public class DeleteFranchiseCommand : IAsyncDeleteCommand<Franchise>
    {
        private readonly FranchiseRepo _repository;

        public DeleteFranchiseCommand(FranchiseRepo repository)
        {
            _repository = repository;
        }

        public async Task Execute(int id)
        {
            await _repository.Delete(id);
        }
    }
}
