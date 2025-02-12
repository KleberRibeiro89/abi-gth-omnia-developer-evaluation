using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return product;
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context
                        .Products
                        .ToListAsync(cancellationToken);
    }

    public async Task<Dictionary<Guid, decimal>> GetPricesAsync(List<Guid> ids, CancellationToken cancellationToken = default)
    {
        return await _context
                        .Products
                        .Where(p => ids.Contains(p.Id))
                        .ToDictionaryAsync(p => p.Id, p => p.Price, cancellationToken);
    }
}
