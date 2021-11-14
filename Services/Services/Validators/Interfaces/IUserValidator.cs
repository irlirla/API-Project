using FluentValidation;
using Services.Models;

namespace Services.Validators
{
    public interface IUserValidator : IValidator<User>
    {
    }
}
