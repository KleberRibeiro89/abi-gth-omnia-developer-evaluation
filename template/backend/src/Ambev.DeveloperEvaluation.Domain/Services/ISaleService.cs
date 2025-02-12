using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services;

public interface ISaleService
{
    ValueTask<Guid> CreateSaleAsync(Sale sale, CancellationToken cancellationToken = default);
}
