using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(s => s.CustomerID)
            .NotEmpty()
            .NotNull()
            .WithMessage("Customer id is required");

        RuleFor(s => s.BranchSaleMade)
            .NotEmpty()
            .NotNull()
            .WithMessage("Branch sale made is required");

        RuleFor(s => s.Items)
            .NotEmpty()
            .WithMessage("item is required");

    }
}
