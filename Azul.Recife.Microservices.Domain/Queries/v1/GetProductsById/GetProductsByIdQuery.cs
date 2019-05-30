using MediatR;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Queries.v1.GetProductsById
{
    /// <summary>
    /// GetProductsByIdQuery Class.
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Azul.Recife.Microservices.Domain.Queries.GetProductsById.GetProductsByIdResponse}</cref>
    /// </seealso>
    public class GetProductsByIdQuery : IRequest<GetProductsByIdResponse>
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        [JsonProperty("productId")]
        public int ProductId { get; set; }
    }
}
