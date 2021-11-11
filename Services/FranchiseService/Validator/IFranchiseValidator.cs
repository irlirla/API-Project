using FluentValidation;
using FranchiseService.Models;

namespace FranchiseService.Validator
{
    public interface IFranchiseValidator : IValidator<Franchise>
    {
    }
}
