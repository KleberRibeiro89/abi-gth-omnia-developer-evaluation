using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

public class CreateProductCommand : IRequest<CreateProductResult>
{
    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }
}
