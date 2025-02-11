using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Product Description is Required");

        RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull()
            .WithMessage("Price é required");
    }
}
