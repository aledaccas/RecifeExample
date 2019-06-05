using Newtonsoft.Json;

namespace SubscriberConsole
{
    /// <summary>
    /// ProductPriceChangedMessage Class.
    /// </summary>
    public class ProductPriceChangedMessage
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
        /// Gets or sets the new amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}