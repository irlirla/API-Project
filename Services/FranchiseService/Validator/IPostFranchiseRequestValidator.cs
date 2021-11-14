using FluentValidation;
using FranchiseService.Broker.Requests;
using FranchiseService.Models;

namespace FranchiseService.Validator
{
    public interface IPostFranchiseRequestValidator : IValidator<FranchisePostRequest>
    {
    }
}
