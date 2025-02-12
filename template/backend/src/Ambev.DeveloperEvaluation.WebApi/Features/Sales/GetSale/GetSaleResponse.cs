namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public record GetSaleResponse
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }

    public Guid CustomerID { get; set; }

    public string BranchSaleMade { get; set; } = string.Empty;

    public List<GetSaleItemResponse> Items { get; set; } = new();


    public record GetSaleItemResponse
    {
        public Guid? SaleItemId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantities { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
