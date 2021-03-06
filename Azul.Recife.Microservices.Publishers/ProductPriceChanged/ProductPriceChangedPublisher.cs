﻿using Azul.Framework.Events;

namespace Azul.Recife.Microservices.Publishers.ProductPriceChanged
{
    /// <summary>
    /// Publishes messages informing a product price was changed. 
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Events.EventPublisher{Azul.Recife.Microservices.Events.Publishers.ProductPriceChangedMessage}</cref>
    /// </seealso>
    public class ProductPriceChangedPublisher : EventPublisher<ProductPriceChangedMessage>
    {
        /// <summary>
        /// Gets the name of the topic.
        /// </summary>
        /// <value>
        /// The name of the topic.
        /// </value>
        public override string TopicName => "ProductPriceChanged";

        /// <summary>
        /// Gets the connection identifier.
        /// </summary>
        /// <value>
        /// The connection identifier.
        /// </value>
        public override string ConnectionId => "localAzureBus";
    }
}