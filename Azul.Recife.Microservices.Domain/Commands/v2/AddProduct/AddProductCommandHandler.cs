using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Azul.Framework.Cache;
using Azul.Framework.Context;
using Azul.Framework.Domain.Commands;
using Azul.Framework.Notifications;
using Azul.Recife.Microservices.Data.Repositories.Products;
using Azul.Recife.Microservices.Data.Repositories.Products.Entities;
using Azul.Recife.Microservices.Domain.Queries.v1.GetProductsById;
using MediatR;

namespace Azul.Recife.Microservices.Domain.Commands.v2.AddProduct
{
    /// <summary>
    /// AddProductCommandHandler Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Domain.Commands.BaseCommandHandler</cref>
    /// </seealso>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Azul.Recife.Microservices.Domain.Commands.v1.AddProduct.AddProductCommand,
    ///         Azul.Recife.Microservices.Domain.Commands.v1.AddProduct.AddProductCommandResponse}
    ///     </cref>
    /// </seealso>
    public class AddProductCommandHandler : BaseCommandHandler, IRequestHandler<AddProductCommand, AddProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddProductCommandHandler" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="context">The context.</param>
        /// <param name="notificationService">The notification service.</param>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="mapper">The mapper.</param>
        public AddProductCommandHandler(IMediator mediator,
                                        IContext context,
                                        INotificationHandler notificationService,
                                        IProductRepository productRepository,
                                        IMapper mapper) : base(mediator, context, notificationService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<AddProductCommandResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            if (!product.Comments.Any())
            {
                return new AddProductCommandResponse { ProductId = string.Empty };
            }

            if (product.Comments.Count == 1)
            {
                throw new ArgumentOutOfRangeException(nameof(request.Comments));
            }

            var products = _productRepository.FindAllAsync();
            await _productRepository.AddAsync(product);
            return new AddProductCommandResponse { ProductId = product.Id.ToString() };
        }
    }
}