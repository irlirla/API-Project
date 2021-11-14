using FluentValidation;
using FranchiseService.Broker.Requests;

namespace FranchiseService.Validator
{
    public class FranchisePutRequestValidator : AbstractValidator<FranchisePutRequest>, IPutFranchiseRequestValidator
    {
        public FranchisePutRequestValidator()
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
