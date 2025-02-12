using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class SaleService : ISaleService
{
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _saleRepository;
    public SaleService(IProductRepository productRepository, ISaleRepository saleRepository)
    {
        _productRepository = productRepository;
        _saleRepository = saleRepository;
    }

    public async ValueTask<Guid> CreateSaleAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        
        var productIds = sale.SaleItems.Select(s => s.ProductId).ToList();

        var prices = await _productRepository.GetPricesAsync(productIds, cancellationToken);

        foreach (var item in sale.SaleItems)
        {
            
            var dbPrince = prices.FirstOrDefault(x => x.Key == item.ProductId).Value;
            if (item.UnitPrice != dbPrince)
                throw new DomainException("the unit price entered is different from the price of the product");

            CalcDiscounts(item);
        }

        CalcTotalSale(sale);

        var result = await _saleRepository.CreateAsync(sale, cancellationToken);

        return result.Id;
    }

    public void CalcTotalSale(Sale sale)
    {
        foreach (var item in sale.SaleItems)
        {
            item.TotalValueItem = item.Amount * item.UnitPrice;
            item.TotalValueItem = item.TotalValueItem - (item.TotalValueItem * item.DiscountsApplied);
        }

        sale.Discounts = sale.SaleItems.Sum(item=> item.DiscountsApplied);
        sale.TotalAmountItem = sale.SaleItems.Sum(item => item.Amount);
        sale.TotalSaleAmount = sale.SaleItems.Sum(item => item.TotalValueItem);        
    }

    public void CalcDiscounts(SaleItem item)
    {
        if (item.Amount == 0)
            throw new DomainException("Amount is 0");

        if (item.Amount > 20)
            throw new DomainException("no more than 20 of the same item may be sold");

        if (item.Amount < 4)
            return;

        if (item.Amount >= 4 && item.Amount < 10)
            item.DiscountsApplied = 0.1M;

        if (item.Amount >= 10 && item.Amount <= 20)
            item.DiscountsApplied = 0.2M;
    }

    public async Task AlterSaleAsync(Sale sale, CancellationToken cancellationToken)
    {
        var productIds = sale.SaleItems.Select(s => s.ProductId).ToList();

        var prices = await _productRepository.GetPricesAsync(productIds, cancellationToken);

        foreach (var item in sale.SaleItems)
        {

            var dbPrince = prices.FirstOrDefault(x => x.Key == item.ProductId).Value;
            if (item.UnitPrice != dbPrince)
                throw new DomainException("the unit price entered is different from the price of the product");

            CalcDiscounts(item);
        }

        CalcTotalSale(sale);

        var result = await _saleRepository.UpdateAsync(sale, cancellationToken);


    }
}
