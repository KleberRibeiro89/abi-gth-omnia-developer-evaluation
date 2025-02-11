using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _repository;
    public CreateCustomerHandler(IMapper mapper, ICustomerRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerCommandValidator();
        var validatorResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validatorResult.IsValid)
            throw new FluentValidation.ValidationException(validatorResult.Errors);

        var customer = _mapper.Map<Domain.Entities.Customer>(command);

        customer = await _repository.CreateAsync(customer, cancellationToken);

        return _mapper.Map<CreateCustomerResult>(customer);
    }
}
