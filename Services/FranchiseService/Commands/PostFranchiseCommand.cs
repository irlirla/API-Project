using FranchiseService.Repositories;
using FranchiseService.Commands.Interfaces;
using FranchiseService.Models;
using System.Threading.Tasks;

namespace FranchiseService.Commands
{
    public class PostFranchiseCommand : IAsyncPostCommand<Franchise>
    {
        private readonly FranchiseRepo _repository;

        public PostFranchiseCommand(FranchiseRepo repository)
        {
            _repository = repository;
        }

        public async Task Execute(Franchise franchise)
        {
            await _repository.Post(franchise);
        }
    }
}
