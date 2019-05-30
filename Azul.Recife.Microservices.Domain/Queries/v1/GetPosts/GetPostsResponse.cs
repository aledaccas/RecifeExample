using System.Collections.Generic;
using Azul.Recife.Microservices.Services.PostService.Response;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Queries.v1.GetPosts
{
    /// <summary>
    /// GetPostsResponse Class.
    /// </summary>
    public class GetPostsResponse
    {
        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>
        /// The posts.
        /// </value>
        [JsonProperty("posts")]
        public List<PostResponse> Posts { get; set; }
    }
}