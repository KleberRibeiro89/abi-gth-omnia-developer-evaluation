using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public Task<Sale> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return _context
                .Sales
                .Include(s=>s.SaleItems)
                .FirstAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<Sale> CreateAsync(Sale entity, CancellationToken cancellationToken = default)
    {
        entity.DateSaleMade = DateTime.UtcNow;

        await _context.Sales.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }


    public async Task<Sale> UpdateAsync(Sale entity, CancellationToken cancellationToken = default)
    {
        _context.Sales.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);


        _context.SaleItems.UpdateRange(entity.SaleItems);
        await _context.SaveChangesAsync(cancellationToken);



        return entity;
    }

    public async Task CancelAsync(Guid id, CancellationToken cancellationToken)
    {
        var sale = await _context
                        .Sales
                        .FirstAsync(s => s.Id == id, cancellationToken);

        sale.Cancelled = true;
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
