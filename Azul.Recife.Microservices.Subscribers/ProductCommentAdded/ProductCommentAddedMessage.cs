using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Subscribers.ProductCommentAdded
{
    /// <summary>
    /// ProductCommentAddedMessage Class.
    /// </summary>
    public class ProductCommentAddedMessage
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
        /// Gets or sets the comment text.
        /// </summary>
        /// <value>
        /// The comment text.
        /// </value>
        [JsonProperty("commentText")]
        public string CommentText { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        [JsonProperty("author")]
        public string Author { get; set; }
    }
}