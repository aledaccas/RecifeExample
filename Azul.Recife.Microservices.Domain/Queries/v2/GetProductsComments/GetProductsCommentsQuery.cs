using MediatR;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Queries.v2.GetProductsComments
{
    /// <summary>
    /// GetProductsCommentsQuery
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Azul.Recife.Microservices.Domain.Queries.v2.GetProductsComments.GetProductsCommentsResponse}</cref>
    /// </seealso>
    public class GetProductsCommentsQuery : IRequest<GetProductsCommentsResponse>
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        [JsonProperty("productId")]
        public string ProductId { get; set; }
    }
}