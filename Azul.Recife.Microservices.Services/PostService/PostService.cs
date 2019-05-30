using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Azul.Framework.Context;
using Azul.Framework.ServiceClient.Http;
using Azul.Recife.Microservices.Services.PostService.Response;

namespace Azul.Recife.Microservices.Services.PostService
{
    public class PostService : HttpServiceClient, IPostService
    {
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