using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customer.ListCustomer;

public class ListCustomerProfile : Profile
{
    public ListCustomerProfile()
    {
        CreateMap<Domain.Entities.Customer, ListCustomerResult>();
    }
}
