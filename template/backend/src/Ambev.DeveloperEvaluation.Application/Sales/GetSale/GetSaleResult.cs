namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public record GetSaleResult
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }

    public Guid CustomerID { get; set; }

    public string BranchSaleMade { get; set; } = string.Empty;

    public List<GetSaleItemResult> Items { get; set; } = new();


    public record GetSaleItemResult
    {
        public Guid? SaleItemId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantities { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
