using Ambev.DeveloperEvaluation.Application.Sales.AlterSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.AlterSale;

public class AlterSaleRequestProfile : Profile
{
    public AlterSaleRequestProfile()
    {

        CreateMap<AlterSaleRequest.AlterSaleItemRequest, AlterSaleCommand.AlterSaleItemCommand>();
        CreateMap<AlterSaleRequest, AlterSaleCommand>();
    }
}
