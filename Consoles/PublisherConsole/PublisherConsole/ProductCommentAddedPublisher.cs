using Azul.Framework.Events;
using Microsoft.Extensions.Logging;

namespace PublisherConsole
{
    public class ProductCommentAddedPublisher : EventPublisher<ProductCommentAddedMessage>
    {
        /// <summary>
        /// Gets the name of the topic.
        /// </summary>
        /// <value>
        /// The name of the topic.
        /// </value>
        public override string TopicName => "ProductCommentAdded";

        /// <summary>
        /// Gets the connection identifier.
        /// </summary>
        /// <value>
        /// The connection identifier.
        /// </value>
        public override string ConnectionId => "localAzureBus";

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCommentAddedPublisher"/> class.
        /// </summary>
        /// <param name="loggerFactory"></param>
        public ProductCommentAddedPublisher(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }
    }
}