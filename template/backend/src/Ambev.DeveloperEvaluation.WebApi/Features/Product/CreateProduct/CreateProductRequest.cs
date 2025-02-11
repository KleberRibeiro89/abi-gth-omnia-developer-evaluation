namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;

public record CreateProductRequest
{
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
