using FluentValidation;
using Services.Models;

namespace Services.Validators
{
    public interface IHeroValidator : IValidator<Hero>
    {
    }
}
