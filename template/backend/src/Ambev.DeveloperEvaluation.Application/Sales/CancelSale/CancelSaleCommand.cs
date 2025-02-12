using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleCommand : IRequest
{
    public Guid Id { get; set; }
    public CancelSaleCommand(Guid id)
    {
        Id = id;
    }
}
