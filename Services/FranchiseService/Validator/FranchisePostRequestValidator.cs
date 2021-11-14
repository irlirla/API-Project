using FluentValidation;
using FranchiseService.Broker.Requests;
using FranchiseService.Models;

namespace FranchiseService.Validator
{
    public class FranchisePostRequestValidator : AbstractValidator<FranchisePostRequest>, IPostFranchiseRequestValidator
    {
        public FranchisePostRequestValidator()
        {
            RuleFor(x => x.FranchiseID)
            .GreaterThan(-1)
            .LessThan(int.MaxValue)
            .WithMessage("Invalid franchise ID!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("PLease, try again to enter the name!");
        }
    }
}
