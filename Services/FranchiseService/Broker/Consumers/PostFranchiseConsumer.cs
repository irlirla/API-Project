using FranchiseService.Broker.Requests;
using FranchiseService.Mapper;
using FranchiseService.Models;
using FranchiseService.Validator;
using MassTransit;
using System.Threading.Tasks;

namespace FranchiseService.Broker.Consumers
{
    public class PostFranchiseConsumer : IConsumer<FranchisePostRequest>
    {
        private readonly IAsyncRepository<Franchise> _repository;
        private readonly IMapper<Franchise, FranchiseResponse> _mapper;
        private readonly IPostFranchiseRequestValidator _validator;

        public PostFranchiseConsumer(IAsyncRepository<Franchise> repository,
            IMapper<Franchise, FranchiseResponse> mapper,
            IPostFranchiseRequestValidator validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task Consume(ConsumeContext<FranchisePostRequest> context)
        {
            if (_validator.Validate(context.Message).IsValid)
            {
                var result = await _repository.Post(context.Message);
                var franchises = result.ToList().Select(x => _mapper.Map(x));
            }
        }
    }
}
