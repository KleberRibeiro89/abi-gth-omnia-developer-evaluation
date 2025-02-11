using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer.ListCustomer;

public class ListCustomerHandler : IRequestHandler<ListCustomerCommand, List<ListCustomerResult>>
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;
    public ListCustomerHandler(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ListCustomerResult>> Handle(ListCustomerCommand request, CancellationToken cancellationToken)
    {
        var customers = await _repository.GetAllAsync(cancellationToken);

        var result = _mapper.Map<List<ListCustomerResult>>(customers);

        return result;
    }
}
