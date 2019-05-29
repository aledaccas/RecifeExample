using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Queries.GetProductsById
{
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
        public int Id { get; set; }

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
