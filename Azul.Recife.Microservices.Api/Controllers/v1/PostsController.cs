using System.Net;
using System.Threading.Tasks;
using Azul.Framework.Api.Controllers;
using Azul.Framework.Context;
using Azul.Framework.Notifications;
using Azul.Framework.Resource.Interfaces;
using Azul.Recife.Microservices.Domain.Queries.v1.GetPosts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Azul.Recife.Microservices.Api.Controllers.v1
{
    /// <summary>
    /// Posts Controller Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Api.Controllers.BaseController{Azul.Recife.Microservices.Api.Controllers.v1.PostsController}</cref>
    /// </seealso>
    [ApiController]
    public class PostsController : BaseController<PostsController>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostsController"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="mediatorService">The mediator service.</param>
        /// <param name="notificationHandler">The notification handler.</param>
        /// <param name="context">The context.</param>
        /// <param name="resourceCatalog">The resource catalog.</param>
        public PostsController(ILoggerFactory loggerFactory,
                               IMediator mediatorService,
                               INotificationHandler notificationHandler,
                               IContext context,
                               IResourceCatalog resourceCatalog) : base(loggerFactory, mediatorService, notificationHandler, context, resourceCatalog)
        {
        }


        /// <summary>
        /// Gets the posts.
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/v1/posts")]
        [ProducesResponseType(typeof(GetPostsResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPosts()
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(new GetPostsQuery()));
        }

    }
}
