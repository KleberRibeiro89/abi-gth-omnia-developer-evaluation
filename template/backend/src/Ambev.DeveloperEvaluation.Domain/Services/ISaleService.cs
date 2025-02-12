using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services;

public interface ISaleService
{
    Task AlterSaleAsync(Sale sale, CancellationToken cancellationToken);
    ValueTask<Guid> CreateSaleAsync(Sale sale, CancellationToken cancellationToken = default);
}
