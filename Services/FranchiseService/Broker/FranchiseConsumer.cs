using FluentValidation;
using FranchiseService.Broker;
using FranchiseService.Mapper;
using FranchiseService.Validator;
using MassTransit;
using System.Threading.Tasks;

namespace FranchiseService.Models
{
    public class FranchiseConsumer : IConsumer<FranchiseRequest>
    {
        private readonly IAsyncRepository<Franchise> _repository;
        private readonly IMapper<Franchise, FranchiseDTO> _mapper;
        private readonly IFranchiseRequestValidator _validator;

        public FranchiseConsumer(IAsyncRepository<Franchise> repository, 
            IMapper<Franchise, FranchiseDTO> mapper,
            IFranchiseRequestValidator validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task Consume(ConsumeContext<FranchiseRequest> context)
        {
            _validator.Validate(context.Message);
            var franchiseID = context.Message.FranchiseID;
            var franchise = await _repository.GetById(franchiseID);
            var franchiseRespond = _mapper.Map(franchise);
            if (franchiseRespond is not null)
            {
                await context.RespondAsync(franchiseRespond);
            }
            else
            {
                await context.RespondAsync(new FranchiseResponse());
            }
        }
    }
}
