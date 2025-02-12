using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.AlterSale;

public class AlterSaleCommand : IRequest
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }

    public Guid CustomerID { get; set; }

    public string BranchSaleMade { get; set; } = string.Empty;

    public List<AlterSaleItemCommand> Items { get; set; } = new();


    public record AlterSaleItemCommand
    {
        public Guid? SaleItemId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantities { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
