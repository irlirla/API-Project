using FluentValidation;
using FranchiseService.Models;

namespace FranchiseService.Validator
{
    public class FranchiseValidator : AbstractValidator<Franchise>, IFranchiseValidator
    {
        public FranchiseValidator()
        {
            RuleFor(x => x.FranchiseID)
                .NotNull()
                .GreaterThan(-1)
                .LessThan(int.MaxValue)
                .WithMessage("Please, choose another id!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .Must(x => x.ToUpper() != "FRANCHISE")
                .WithMessage("Please, try again to enter the Name.");

            RuleFor(x => x.Movies.ToString())
                .NotEmpty()
                .WithMessage("Please, try again to enter at least 1 Movie to the Franchise");
        }
    }
}
