using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Azul.Framework.Events;
using Azul.Recife.Microservices.Domain.Commands.v2.AddComment;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Azul.Recife.Microservices.Subscribers.ProductCommentAdded
{
    /// <summary>
    /// Consumes the event of a product comment added.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Events.EventSubscriber{Azul.Recife.Microservices.Events.Subscribers.ProductCommentAdded.ProductCommentAddedMessage}</cref>
    /// </seealso>
    public class ProductCommentAddedSubscriber : EventSubscriber<ProductCommentAddedMessage>
    {
        /// <summary>
        /// Gets the name of the topic.
        /// </summary>
        /// <value>
        /// The name of the topic.
        /// </value>
        public override string TopicName => "ProductCommentAdded";

        /// <summary>
        /// Gets the name of the subscription.
        /// </summary>
        /// <value>
        /// The name of the subscription.
        /// </value>
        public override string SubscriptionName => "AzulRecifeMicroservices";

        /// <summary>
        /// Gets the connection identifier.
        /// </summary>
        /// <value>
        /// The connection identifier.
        /// </value>
        public override string ConnectionId => "localAzureBus";

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCommentAddedSubscriber"/> class.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="mapper"></param>
        public ProductCommentAddedSubscriber(IMediator mediator,
                                             ILoggerFactory loggerFactory,
                                             IMapper mapper) : base(mediator, loggerFactory, mapper)
        {
        }

        /// <summary>
        /// Consumes the message from  subscription asynchronous.
        /// </summary>
        /// <param name="message">The message to be consumed.</param>
        /// <param name="headers">The custom headers of message.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public override async Task<bool> ConsumeAsync(ProductCommentAddedMessage message, IDictionary<string, object> headers, CancellationToken cancellationToken)
        {
            try
            {
                var command = MapperService.Map<AddCommentCommand>(message);
                return await MediatorService.Send(command, cancellationToken);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}