using System.Threading;
using System.Threading.Tasks;
using Azul.Framework.Context;
using Azul.Framework.Domain.Commands;
using Azul.Framework.Notifications;
using MediatR;

namespace Azul.Recife.Microservices.Domain.Commands
{
    public class AddProductCommandHandler : BaseCommandHandler, IRequestHandler<AddProductCommand, AddProductCommandResponse>
    {
        public AddProductCommandHandler(IMediator mediator, IContext context, INotificationHandler notificationService) : base(mediator, context, notificationService)
        {
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            NotificationService.NotifyInformation("deucerto", "funcionou");


            return await Task.Run(() => new AddProductCommandResponse { ProductId = 1 }, cancellationToken);
        }
    }
}