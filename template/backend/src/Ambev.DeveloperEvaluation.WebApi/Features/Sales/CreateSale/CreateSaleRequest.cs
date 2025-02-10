namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequest
{
    public string Customer { get; set; } = string.Empty;

    public string BranchSaleMade { get; set; } = string.Empty;

    public List<string> Products { get; set; } = new();

    public decimal Quantities { get; set; }

    public decimal UnitPrices { get; set; }

    public decimal Discounts { get; set; }

}
