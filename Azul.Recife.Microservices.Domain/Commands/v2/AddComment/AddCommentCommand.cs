using MediatR;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Commands.v2.AddComment
{
    /// <summary>
    /// AddCommentCommand Class.
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{System.Boolean}</cref>
    /// </seealso>
    public class AddCommentCommand : IRequest<bool>
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