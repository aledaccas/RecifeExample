using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azul.Framework.Cache;
using Azul.Framework.Context;
using Azul.Framework.Domain.Commands;
using Azul.Framework.Notifications;
using Azul.Recife.Microservices.Domain.Queries.v1.GetProductsById;
using MediatR;

namespace Azul.Recife.Microservices.Domain.Queries.v1.GetProducts
{
    /// <summary>
    /// GetProductsQueryHandler Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Domain.Commands.BaseCommandHandler</cref>
    /// </seealso>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Azul.Recife.Microservices.Domain.Queries.v1.GetProducts.GetProductsQuery,
    ///         Azul.Recife.Microservices.Domain.Queries.v1.GetProducts.GetProductsResponse}
    ///     </cref>
    /// </seealso>
    public class GetProductsQueryHandler : BaseCommandHandler,  IRequestHandler<GetProductsQuery, GetProductsResponse>
    {
        private readonly ICache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductsQueryHandler"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="context">The context.</param>
        /// <param name="notificationService">The notification service.</param>
        /// <param name="cache">The cache.</param>
        public GetProductsQueryHandler(IMediator mediator, 
                                       IContext context, 
                                       INotificationHandler notificationService,
                                       ICache cache) : base(mediator, context, notificationService)
        {
            _cache = cache;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<GetProductsResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _cache.RetrieveOrAddAsync("productsList", () => new List<GetProductsByIdResponse>(), 1);
            return new GetProductsResponse {Products = products};
        }
    }
}