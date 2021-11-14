using FranchiseService.Models;
using FranchiseService.Repositories;
using FranchiseService.Commands.Interfaces;
using System.Threading.Tasks;

namespace FranchiseService.Commands
{
    public class PutFranchiseCommand : IAsyncPutCommand<Franchise>
    {
        private readonly IAsyncRepository<Franchise> _repository;

        public PutFranchiseCommand(IAsyncRepository<Franchise> repository)
        {
            _repository = repository;
        }

        public async Task Execute(Franchise franchise)
        {
            await _repository.Put(franchise);
        }
    }
}
