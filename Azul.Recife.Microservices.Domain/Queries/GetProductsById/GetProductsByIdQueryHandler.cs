using System.Threading;
using System.Threading.Tasks;
using Azul.Framework.Context;
using Azul.Framework.Domain.Commands;
using Azul.Framework.Notifications;
using MediatR;

namespace Azul.Recife.Microservices.Domain.Queries.GetProductsById
{
    public class GetProductsByIdQueryHandler : BaseCommandHandler, IRequestHandler<GetProductsByIdQuery, GetProductsByIdResponse>
    {
        public GetProductsByIdQueryHandler(IMediator mediator, 
                                           IContext context, 
                                           INotificationHandler notificationService) : base(mediator, context, notificationService)
        {
            
        }

        public async Task<GetProductsByIdResponse> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new GetProductsByIdResponse {Id = request.ProductId, Name = $"Product {Context.GetContextDataValue<string>("culture")}", Amount = 10}, cancellationToken);
        }
    }
}