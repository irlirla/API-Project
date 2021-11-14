using FluentValidation;
using Services.Models;

namespace Services.Validators
{
    public interface IMovieValidator : IValidator<Movie>
    {
    }
}
