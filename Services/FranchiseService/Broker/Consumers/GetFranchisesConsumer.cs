using FranchiseService.Broker.Requests;
using FranchiseService.Broker.Responses;
using FranchiseService.Mapper;
using FranchiseService.Models;
using FranchiseService.Validator;
using MassTransit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranchiseService.Broker.Consumers
{
    public class GetFranchisesConsumer : IConsumer<FranchisesRequest>
    {
        private readonly IAsyncRepository<Franchise> _repository;
        private readonly IMapper<Franchise, FranchiseResponse> _mapper;

        public GetFranchisesConsumer(IAsyncRepository<Franchise> repository, 
            IMapper<Franchise, FranchiseResponse> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<FranchisesRequest> context)
        {
            var result = await _repository.Get();
            var franchises = result.ToList().Select(x => _mapper.Map(x));
            await context.RespondAsync(new FranchisesResponse() { Franchises = franchises.ToList() });
        }
    }
}
