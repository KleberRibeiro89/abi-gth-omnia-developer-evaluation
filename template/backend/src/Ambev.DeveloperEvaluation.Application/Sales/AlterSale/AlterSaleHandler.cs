using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.AlterSale;

public class AlterSaleHandler : IRequestHandler<AlterSaleCommand>
{
    private readonly ISaleService _service;
    private readonly ISaleRepository _saleRepository;
    public AlterSaleHandler(ISaleService service, ISaleRepository saleRepository)
    {
        _service = service;
        _saleRepository = saleRepository;
    }

    public async Task Handle(AlterSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new AlterSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetAsync(command.Id, cancellationToken);
        sale.CustomerId = command.CustomerID;

        foreach (var item in sale.SaleItems)
        {
            var commandItem = command.Items.First(i => i.SaleItemId == item.Id);
            item.Amount = commandItem.Quantities;
            item.UnitPrice = commandItem.UnitPrice;
        }

        await _service.AlterSaleAsync(sale, cancellationToken);
    }


}
