using FluentValidation;
using FranchiseService.Broker.Requests;

namespace FranchiseService.Validator
{
    public class FranchiseDeleteRequestValidator : AbstractValidator<FranchiseDeleteRequest>, IDeleteFranchiseRequestValidator
    {
        public FranchiseDeleteRequestValidator()
        {
            RuleFor(x => x.FranchiseID)
            .GreaterThan(-1)
            .LessThan(int.MaxValue)
            .WithMessage("Invalid franchise ID!");
        }
    }
}
