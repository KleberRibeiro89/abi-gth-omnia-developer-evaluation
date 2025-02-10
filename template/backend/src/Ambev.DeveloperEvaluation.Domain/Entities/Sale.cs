using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public int SaleNumber { get; init; }

    /// <summary>
    /// Date when the sale was made
    /// </summary>
    public DateTime DateSaleMade { get; set; }

    public virtual Customer Customer{ get; set; } 

    public decimal TotalSaleAmount { get; set; }

    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string BranchSaleMade { get; set; } = string.Empty;

    public virtual ICollection<SaleItem> Sales { get; set; } = new List<SaleItem>();


    public decimal Discounts { get; set; }

    /// <summary>
    /// Total amount for each item
    /// </summary>
    public decimal TotalAmountItem { get; set; }

    /// <summary>
    /// Cancelled/Not Cancelled
    /// </summary>
    public bool Cancelled { get; set; }
}
