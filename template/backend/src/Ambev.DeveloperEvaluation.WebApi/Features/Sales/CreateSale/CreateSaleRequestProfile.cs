using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using AutoMapper;
using static Ambev.DeveloperEvaluation.Application.Sales.CreateSale.CreateSaleCommand;
using static Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale.CreateSaleRequest;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestProfile : Profile
{
    public CreateSaleRequestProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>()
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Quantities));
    }
}
