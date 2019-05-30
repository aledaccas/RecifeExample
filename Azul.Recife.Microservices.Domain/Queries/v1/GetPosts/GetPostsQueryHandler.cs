using System.Threading;
using System.Threading.Tasks;
using Azul.Framework.Context;
using Azul.Framework.Domain.Commands;
using Azul.Framework.Notifications;
using Azul.Recife.Microservices.Services.PostService;
using MediatR;

namespace Azul.Recife.Microservices.Domain.Queries.v1.GetPosts
{
    /// <summary>
    /// GetPostsQueryHandler Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Domain.Commands.BaseCommandHandler</cref>
    /// </seealso>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Azul.Recife.Microservices.Domain.Queries.v1.GetPosts.GetPostsQuery,
    ///         Azul.Recife.Microservices.Domain.Queries.v1.GetPosts.GetPostsResponse}
    ///     </cref>
    /// </seealso>
    public class GetPostsQueryHandler : BaseCommandHandler, IRequestHandler<GetPostsQuery, GetPostsResponse>
    {
        private readonly IPostService _postService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPostsQueryHandler"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="context">The context.</param>
        /// <param name="notificationService">The notification service.</param>
        /// <param name="postService">The post service.</param>
        public GetPostsQueryHandler(IMediator mediator,
                                    IContext context,
                                    INotificationHandler notificationService,
                                    IPostService postService) : base(mediator, context, notificationService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<GetPostsResponse> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postService.GetPostsAsync();
            return new GetPostsResponse { Posts = posts };
        }
    }
}