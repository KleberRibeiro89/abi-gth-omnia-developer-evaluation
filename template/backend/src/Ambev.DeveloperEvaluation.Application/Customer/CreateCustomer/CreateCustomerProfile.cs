using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer;

public class CreateCustomerProfile : Profile
{
    public CreateCustomerProfile()
    {

        CreateMap<CreateCustomerCommand, Domain.Entities.Customer>();
        CreateMap<Domain.Entities.Customer, CreateCustomerResult>();
    }
}
