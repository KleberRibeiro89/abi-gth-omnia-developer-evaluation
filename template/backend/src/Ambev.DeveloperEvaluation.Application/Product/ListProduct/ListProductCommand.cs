using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.ListProduct;

public class ListProductCommand : IRequest<List<ListProductResult>>
{
}
