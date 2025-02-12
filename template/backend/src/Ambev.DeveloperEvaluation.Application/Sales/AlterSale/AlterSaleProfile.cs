using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.AlterSale;

public class AlterSaleProfile : Profile
{
    public AlterSaleProfile()
    {

        CreateMap<AlterSaleCommand.AlterSaleItemCommand, SaleItem>()
            .ForMember(dest=>dest.Amount, opt=>opt.MapFrom(s=>s.Quantities));

        CreateMap<AlterSaleCommand, Sale>()
            .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(s => s.Items));
    }
}
