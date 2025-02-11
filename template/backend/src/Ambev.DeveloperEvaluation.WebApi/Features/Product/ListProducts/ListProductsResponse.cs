namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ListProducts;

public class ListProductsResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
