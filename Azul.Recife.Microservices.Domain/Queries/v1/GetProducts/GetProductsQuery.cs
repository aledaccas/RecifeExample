using MediatR;

namespace Azul.Recife.Microservices.Domain.Queries.v1.GetProducts
{
    /// <summary>
    /// GetProductsQuery Class.
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Azul.Recife.Microservices.Domain.Queries.v1.GetProducts.GetProductsResponse}</cref>
    /// </seealso>
    public class GetProductsQuery : IRequest<GetProductsResponse>
    {   
    }
}