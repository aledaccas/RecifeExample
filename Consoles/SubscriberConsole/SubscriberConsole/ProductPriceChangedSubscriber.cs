using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Azul.Framework.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SubscriberConsole
{
    public class ProductPriceChangedSubscriber : EventSubscriber<ProductPriceChangedMessage>
    {
        /// <summary>
        /// Gets the name of the topic.
        /// </summary>
        /// <value>
        /// The name of the topic.
        /// </value>
        public override string TopicName => "productpricechanged";

        /// <summary>
        /// Gets the name of the subscription.
        /// </summary>
        /// <value>
        /// The name of the subscription.
        /// </value>
        public override string SubscriptionName => "SubscriberConsole";

        /// <summary>
        /// Gets the connection identifier.
        /// </summary>
        /// <value>
        /// The connection identifier.
        /// </value>
        public override string ConnectionId => "localAzureBus";

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductPriceChangedSubscriber"/> class.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="mapper"></param>
        public ProductPriceChangedSubscriber(IMediator mediator,
                                             ILoggerFactory loggerFactory,
                                             IMapper mapper) : base(mediator, loggerFactory, mapper)
        {
        }

        /// <summary>
        /// Consumes the message from  subscription asynchronous.
        /// </summary>
        /// <param name="message">The message to be consumed.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public override async Task<bool> ConsumeAsync(Event<ProductPriceChangedMessage> message, CancellationToken cancellationToken)
        {
            try
            {
                await Task.Run(() => 
                    Console.WriteLine($"Price of product {message.EventData.Id} has changed. New price is {message.EventData.Amount}"),
                    cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error consuming message. Exception: {ex}");
                return true;
            }
        }
    }
}