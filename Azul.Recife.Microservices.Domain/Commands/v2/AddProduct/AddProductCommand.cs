using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Commands.v2.AddProduct
{
    /// <summary>
    /// AddProductCommand Class.
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Azul.Recife.Microservices.Domain.Commands.AddProductCommandResponse}</cref>
    /// </seealso>
    public class AddProductCommand : IRequest<AddProductCommandResponse>
    {
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