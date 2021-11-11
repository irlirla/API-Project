using FluentValidation;
using Services.Models;

namespace Services.Validators
{
    public class UserValidator : AbstractValidator<User>, IUserValidator
    {
        public UserValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .GreaterThan(-1)
                .LessThan(int.MaxValue)
                .WithMessage("Please, choose another id!");

            RuleFor(x => x.Age)
                .NotNull()
                .GreaterThan(0)
                .LessThan(1000)
                .WithMessage("I doubt that there is such an age. Please, change it.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(70)
                .WithMessage("Please, enter a Name!(Shorter than 70)");

            RuleFor(x => x.Address)
                .NotNull()
                .MaximumLength(100)
                .WithMessage("Please, enter an Address!(Shorter than 70)");
        }
    }
}
