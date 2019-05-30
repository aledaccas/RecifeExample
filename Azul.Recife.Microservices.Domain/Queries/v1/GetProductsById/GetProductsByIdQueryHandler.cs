using System.Threading;
using System.Threading.Tasks;
using Azul.Framework.Context;
using Azul.Framework.Domain.Commands;
using Azul.Framework.Notifications;
using MediatR;

namespace Azul.Recife.Microservices.Domain.Queries.v1.GetProductsById
{
    /// <summary>
    /// GetProductsByIdQueryHandler Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Domain.Commands.BaseCommandHandler</cref>
    /// </seealso>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Azul.Recife.Microservices.Domain.Queries.v1.GetProductsById.GetProductsByIdQuery,
    ///         Azul.Recife.Microservices.Domain.Queries.v1.GetProductsById.GetProductsByIdResponse}
    ///     </cref>
    /// </seealso>
    public class GetProductsByIdQueryHandler : BaseCommandHandler, IRequestHandler<GetProductsByIdQuery, GetProductsByIdResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductsByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="context">The context.</param>
        /// <param name="notificationService">The notification service.</param>
        public GetProductsByIdQueryHandler(IMediator mediator, 
                                           IContext context, 
                                           INotificationHandler notificationService) : base(mediator, context, notificationService)
        {
            
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<GetProductsByIdResponse> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new GetProductsByIdResponse {Id = request.ProductId, Name = $"Product {Context.GetContextDataValue<string>("culture")}", Amount = 10}, cancellationToken);
        }
    }
}