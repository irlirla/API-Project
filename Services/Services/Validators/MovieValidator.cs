using FluentValidation;
using Services.Models;

namespace Services.Validators
{
    public class MovieValidator : AbstractValidator<Movie>, IMovieValidator
    {
        public MovieValidator()
        {
            RuleFor(x => x.ID)
                .NotNull()
                .GreaterThan(-1)
                .LessThan(int.MaxValue)
                .WithMessage("Please, choose another id!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Please, try again to enter the Name.");

            RuleFor(x => x.FranchiseName.Name)
                .NotEmpty()
                .MaximumLength(100)
                .Must(x => x.ToUpper() != "FRANCHISE")
                .WithMessage("Please, try again to enter the Name of Franchise.");
        }
    }
}
