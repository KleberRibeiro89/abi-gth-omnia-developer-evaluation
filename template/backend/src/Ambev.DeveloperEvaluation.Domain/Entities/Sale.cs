using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public string Id { get; set; } = string.Empty;

    public int SaleNumber { get; set; }

    public string Customer { get; set; } = string.Empty;

    public decimal TotalSaleAmount { get; set; }

    public string BranchSaleMade { get; set; } = string.Empty;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
