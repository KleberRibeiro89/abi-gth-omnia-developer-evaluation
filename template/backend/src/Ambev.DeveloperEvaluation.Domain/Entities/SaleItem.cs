using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem: BaseEntity
{
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
    public decimal Amount { get; set; }

    public decimal TotalValueItem { get; set; }

    public Guid SaleId { get; set; }
    public virtual Sale Sale { get; set; }

}
