using FluentValidation;
using FranchiseService.Broker.Requests;

namespace FranchiseService.Validator
{
    public interface IPutFranchiseRequestValidator : IValidator<FranchisePutRequest>
    {
    }
}
