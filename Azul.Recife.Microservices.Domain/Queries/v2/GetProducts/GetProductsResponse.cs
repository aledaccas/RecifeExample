using System.Collections.Generic;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Queries.v2.GetProducts
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

    /// <summary>
    /// GetProductsByIdResponse Class.
    /// </summary>
    public class GetProductsByIdResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}