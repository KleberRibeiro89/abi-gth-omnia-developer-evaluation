namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public record CreateSaleRequest
{
    public Guid CustomerID { get; set; }

    public string BranchSaleMade { get; set; } = string.Empty;

    public List<CreateSaleItemRequest> Items { get; set; } = new();

    public decimal Quantities { get; set; }

    public decimal Discounts { get; set; }


    public record CreateSaleItemRequest
    {
        public Guid ProductId { get; set; }
        public decimal Quantities { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
