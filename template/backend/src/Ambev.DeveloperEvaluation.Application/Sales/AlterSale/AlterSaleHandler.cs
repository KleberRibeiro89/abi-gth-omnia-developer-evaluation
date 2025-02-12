using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.AlterSale;

public class AlterSaleHandler : IRequestHandler<AlterSaleCommand, AlterSaleResult>
{
    private readonly ISaleService _service;
    private readonly IMapper _mapper;
    public AlterSaleHandler(ISaleService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<AlterSaleResult> Handle(AlterSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new AlterSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = _mapper.Map<Sale>(command);

        await _service.AlterSaleAsync(sale, cancellationToken);

        return new AlterSaleResult();

    }


}
