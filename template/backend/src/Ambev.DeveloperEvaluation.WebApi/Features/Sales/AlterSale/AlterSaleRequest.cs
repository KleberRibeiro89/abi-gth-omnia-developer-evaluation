﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.AlterSale;

public class AlterSaleRequest
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }

    public Guid CustomerID { get; set; }

    public string BranchSaleMade { get; set; } = string.Empty;

    public List<AlterSaleItemRequest> Items { get; set; } = new();


    public record AlterSaleItemRequest
    {
        public Guid? SaleItemId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantities { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
