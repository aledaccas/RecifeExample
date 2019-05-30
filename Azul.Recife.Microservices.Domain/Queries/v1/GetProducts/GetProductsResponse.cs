using System.Collections.Generic;
using Azul.Recife.Microservices.Domain.Queries.v1.GetProductsById;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Queries.v1.GetProducts
{
    /// <summary>
    /// GetProductsResponse Class.
    /// </summary>
    public class GetProductsResponse
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        [JsonProperty("products")]
        public List<GetProductsByIdResponse> Products { get; set; }
    }
}