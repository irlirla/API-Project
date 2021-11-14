using FranchiseService.Broker.Requests;
using FranchiseService.Broker.Responses;
using FranchiseService.Mapper;
using FranchiseService.Models;
using FranchiseService.Validator;
using MassTransit;
using System.Threading.Tasks;

namespace FranchiseService.Broker.Consumers
{
    public class GetByIdFranchiseConsumer : IConsumer<FranchiseByIdRequest>
    {
        private readonly IAsyncRepository<Franchise> _repository;
        private readonly IMapper<Franchise, FranchiseResponse> _mapper;

        public GetByIdFranchiseConsumer(IAsyncRepository<Franchise> repository, 
            IMapper<Franchise, FranchiseResponse> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<FranchiseByIdRequest> context)
        {
            var result = await _repository.GetById(context.Message.FranchiseID);
            var franchise = _mapper.Map(result);
            await context.RespondAsync(new FranchiseByIdResponse() { Name = franchise.Name });
        }
    }
}
