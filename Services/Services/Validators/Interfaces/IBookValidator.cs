using FluentValidation;
using Services.Models;

namespace Services.Validators
{
    public interface IBookValidator : IValidator<Book>
    {
    }
}
