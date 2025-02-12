using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetResultProfile : Profile
{
    public GetResultProfile()
    {
        CreateMap<SaleItem, GetSaleResult.GetSaleItemResult>()
            .ForMember(dest => dest.SaleItemId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Quantities, opt => opt.MapFrom(src => src.Amount));

        CreateMap<Sale, GetSaleResult>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.SaleItems));


    }
}
