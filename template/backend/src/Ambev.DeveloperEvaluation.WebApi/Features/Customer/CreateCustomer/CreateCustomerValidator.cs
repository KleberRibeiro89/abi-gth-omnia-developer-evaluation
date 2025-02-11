using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name customer is required");
    }
}
