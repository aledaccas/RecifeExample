using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Queries.v2.GetProductsComments
{
    /// <summary>
    /// GetProductsCommentsResponse
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Azul.Recife.Microservices.Domain.Queries.v2.GetProductsComments.GetProductsCommentsResponse}</cref>
    /// </seealso>
    public class GetProductsCommentsResponse : IRequest<GetProductsCommentsResponse>
    {
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }
    }

    /// <summary>
    /// Comment Class.
    /// </summary>
    public class Comment
    {
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