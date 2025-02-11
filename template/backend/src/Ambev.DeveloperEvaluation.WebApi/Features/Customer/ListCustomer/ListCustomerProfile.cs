using Ambev.DeveloperEvaluation.Application.Customer.ListCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.ListCustomer;

public class ListCustomerProfile : Profile
{
    public ListCustomerProfile()
    {
        CreateMap<ListCustomerResult, ListCustomerResponse>();
    }
}
