using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Commands.v2.AddProduct
{
    /// <summary>
    /// AddProductCommandResponse Class.
    /// </summary>
    public class AddProductCommandResponse
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