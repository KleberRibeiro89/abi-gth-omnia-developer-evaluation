using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.ListProduct;

public class ListProductProfile : Profile
{
    public ListProductProfile()
    {
        CreateMap<Domain.Entities.Product, ListProductResult>();
    }
}
