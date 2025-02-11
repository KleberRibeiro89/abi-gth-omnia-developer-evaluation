using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer.ListCustomer;

public class ListCustomerCommand : IRequest<List<ListCustomerResult>>
{
}
