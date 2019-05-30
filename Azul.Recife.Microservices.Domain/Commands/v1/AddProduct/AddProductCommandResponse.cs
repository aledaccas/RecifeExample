using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Commands.v1.AddProduct
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
        public int ProductId { get; set; }
    }
}