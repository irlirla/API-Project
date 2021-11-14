using FranchiseService.Repositories;
using FranchiseService.Commands.Interfaces;
using FranchiseService.Models;
using System.Threading.Tasks;
using FranchiseService.Mapper;

namespace FranchiseService.Commands
{
    public class GetFranchiseByIDCommand : IAsyncGetByIDCommand<FranchiseDTO>
    {
        private readonly IAsyncRepository<Franchise> _repository;
        private readonly IMapper<Franchise, FranchiseDTO> _mapper;

        public GetFranchiseByIDCommand(IAsyncRepository<Franchise> repository, IMapper<Franchise, FranchiseDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FranchiseDTO> Execute(int id)
        {
            var result = await _repository.GetById(id);
            var franchise = _mapper.Map(result);
            return franchise;
        }
    }
}
