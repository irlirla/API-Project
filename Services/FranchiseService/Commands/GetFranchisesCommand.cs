using FranchiseService.Repositories;
using FranchiseService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranchiseService.Commands.Interfaces;
using FranchiseService.Mapper;

namespace FranchiseService.Commands
{
    public class GetFranchisesCommand : IAsyncGetAllCommand<FranchiseDTO>
    {
        private readonly IAsyncRepository<Franchise> _repository;
        private readonly IMapper<Franchise, FranchiseDTO> _mapper;

        public GetFranchisesCommand(IAsyncRepository<Franchise> repository, IMapper<Franchise, FranchiseDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FranchiseDTO>> Execute()
        {
            var result = _repository.Get();
            var franchises = await result;
            var franchises1 = franchises.ToList().Select(x => _mapper.Map(x));
            return franchises1;
        }
    }
}
