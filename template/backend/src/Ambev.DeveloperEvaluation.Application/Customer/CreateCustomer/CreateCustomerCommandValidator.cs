using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name customer is required");
    }
}
