using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer;

public class CreateCustomerCommand : IRequest<CreateCustomerResult>
{
    public string Name { get; set; } = string.Empty;
}
