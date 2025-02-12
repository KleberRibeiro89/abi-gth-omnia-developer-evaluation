namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public record CreateSaleRequest
{
    public Guid CustomerID { get; set; }

    public string BranchSaleMade { get; set; } = string.Empty;

    public List<CreateSaleItemCommand> Items { get; set; } = new();

    public record CreateSaleItemCommand
    {
        public Guid ProductId { get; set; }
        public decimal Quantities { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalValue { get; set; }
    }
}
