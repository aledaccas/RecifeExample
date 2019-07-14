using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Azul.Framework.Context;
using Azul.Framework.ServiceClient.Http;
using Azul.Recife.Microservices.Services.PostService.Response;
using Microsoft.Extensions.Logging;

namespace Azul.Recife.Microservices.Services.PostService
{
    /// <summary>
    /// Post Service Class.
    /// </summary>
    /// <seealso cref="Azul.Framework.ServiceClient.Http.HttpServiceClient" />
    /// <seealso cref="Azul.Recife.Microservices.Services.PostService.IPostService" />
    public class PostService : HttpServiceClient, IPostService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="contextFactory">The context factory.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public PostService(IHttpClientFactory httpClientFactory, IContextFactory contextFactory, ILoggerFactory loggerFactory) : base(httpClientFactory, contextFactory, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the posts asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<PostResponse>> GetPostsAsync()
        {
            var response = await GetAsync<List<PostResponse>>("/posts");

            if (response.HttpResponse.IsSuccessStatusCode)
            {
                var posts = await response.GetContentObjectAsync();
                return posts;
            }
           
            return await Task.Run(() => new List<PostResponse>());
        }
    }
}