using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public CreateProductHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator();
        var validatorResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validatorResult.IsValid)
            throw new FluentValidation.ValidationException(validatorResult.Errors);

        var product = _mapper.Map<Domain.Entities.Product>(request);
        var result = await _repository.CreateAsync(product);
        return _mapper.Map<CreateProductResult>(result);
    }
}
