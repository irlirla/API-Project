using FluentValidation;
using Services.Models;

namespace Services.Validators
{
    public class BookValidator : AbstractValidator<Book>, IBookValidator
    {
        public BookValidator()
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

            RuleFor(x => x.Author)
                .NotEmpty()
                .MaximumLength(70)
                .Must(x => x.ToUpper() != "AUTHOR")
                .WithMessage("Please, try again to enter the Author.");
        }
    }
}
