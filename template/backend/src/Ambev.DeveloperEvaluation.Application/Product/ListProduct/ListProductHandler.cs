using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.ListProduct;

public class ListProductHandler : IRequestHandler<ListProductCommand, List<ListProductResult>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;
    public ListProductHandler(IMapper mapper, IProductRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<ListProductResult>> Handle(ListProductCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<List<ListProductResult>>(await _repository.GetAllAsync(cancellationToken));

        return result;
    }
}
