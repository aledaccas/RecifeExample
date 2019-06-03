using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Azul.Framework.Context;
using Azul.Framework.Domain.Commands;
using Azul.Framework.Events;
using Azul.Framework.Notifications;
using Azul.Recife.Microservices.Data.Repositories.Products;
using Azul.Recife.Microservices.Exceptions;
using Azul.Recife.Microservices.Publishers.ProductPriceChanged;
using MediatR;
using MongoDB.Bson;

namespace Azul.Recife.Microservices.Domain.Commands.v2.ChangeProductPrice
{
    /// <summary>
    /// ChangeProductPriceCommandHandler Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Domain.Commands.BaseCommandHandler</cref>
    /// </seealso>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Azul.Recife.Microservices.Domain.Commands.v2.ChangeProductPrice.ChangeProductPriceCommand,
    ///         System.Boolean}
    ///     </cref>
    /// </seealso>
    public class ChangeProductPriceCommandHandler : BaseCommandHandler, IRequestHandler<ChangeProductPriceCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IPublisher<ProductPriceChangedMessage> _productPriceChangedPublisher;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeProductPriceCommandHandler" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="context">The context.</param>
        /// <param name="notificationService">The notification service.</param>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="productPriceChangedPublisher">The product price changed publisher.</param>
        /// <param name="mapper">The mapper.</param>
        public ChangeProductPriceCommandHandler(IMediator mediator, 
                                                IContext context, 
                                                INotificationHandler notificationService,
                                                IProductRepository productRepository,
                                                IPublisher<ProductPriceChangedMessage> productPriceChangedPublisher,
                                                IMapper mapper) : base(mediator, context, notificationService)
        {
            _productRepository = productRepository;
            _productPriceChangedPublisher = productPriceChangedPublisher;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<bool> Handle(ChangeProductPriceCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindByIdAsync(new ObjectId(request.Id));
            if (product != null)
            {
                product.Amount = request.Amount;
                await _productRepository.UpdateAsync(product);
                var changeProductPriceMessage = _mapper.Map<ProductPriceChangedMessage>(request);
                await _productPriceChangedPublisher.PublishAsync(changeProductPriceMessage);
                return true;
            }
            throw new ProductDoesNotExistException();
        }
    }
}