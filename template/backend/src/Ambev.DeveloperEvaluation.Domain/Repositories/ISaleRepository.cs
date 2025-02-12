using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sale> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<Sale> CreateAsync(Sale entity, CancellationToken cancellationToken = default);
    Task<Sale> UpdateAsync(Sale entity, CancellationToken cancellationToken = default);
    Task CancelAsync(Guid id, CancellationToken cancellationToken);
}
