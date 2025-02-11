using Ambev.DeveloperEvaluation.Application.Product.ListProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ListProducts;

public class ListProductsProfile : Profile
{
    public ListProductsProfile()
    {
        CreateMap<ListProductResult, ListProductsResponse>();
    }
}
