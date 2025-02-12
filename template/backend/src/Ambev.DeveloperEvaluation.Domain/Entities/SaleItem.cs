using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem: BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
    public decimal Amount { get; set; }

    public decimal UnitPrice { get; set; }
    public decimal DiscountsApplied { get; set; }

    public decimal TotalValueItem { get; set; }

    public Guid SaleId { get; set; }
    public virtual Sale Sale { get; set; }

}
