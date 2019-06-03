using MediatR;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Commands.v2.ChangeProductPrice
{
    /// <summary>
    /// ChangeProductPriceCommand Class.
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{System.Boolean}</cref>
    /// </seealso>
    public class ChangeProductPriceCommand : IRequest<bool>
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
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}