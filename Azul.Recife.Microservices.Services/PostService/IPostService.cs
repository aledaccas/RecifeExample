using System.Collections.Generic;
using System.Threading.Tasks;
using Azul.Recife.Microservices.Services.PostService.Response;

namespace Azul.Recife.Microservices.Services.PostService
{
    /// <summary>
    /// IPostService interface.
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Gets the posts asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<PostResponse>> GetPostsAsync();
    }
}