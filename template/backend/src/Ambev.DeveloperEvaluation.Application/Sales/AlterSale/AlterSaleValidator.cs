using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.AlterSale;

public class AlterSaleValidator : AbstractValidator<AlterSaleCommand>
{
    public AlterSaleValidator()
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
            .WithMessage("items is required");
    }
}
