using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleHandler : IRequestHandler<CancelSaleCommand>
{
    private readonly ISaleRepository _saleRepository;
    public CancelSaleHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        await _saleRepository.CancelAsync(request.Id, cancellationToken);
    }
}
