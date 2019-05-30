using MediatR;

namespace Azul.Recife.Microservices.Domain.Queries.v1.GetPosts
{
    /// <summary>
    /// GetPostsQuery
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Azul.Recife.Microservices.Domain.Queries.v1.GetPosts.GetPostsResponse}</cref>
    /// </seealso>
    public class GetPostsQuery : IRequest<GetPostsResponse>
    {
    }
}