using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azul.Framework.Cache;
using Azul.Framework.Context;
using Azul.Framework.Domain.Commands;
using Azul.Framework.Notifications;
using Azul.Recife.Microservices.Domain.Queries.v1.GetProductsById;
using MediatR;

namespace Azul.Recife.Microservices.Domain.Commands.v1.AddProduct
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
        /// <summary>
        /// The cache
        /// </summary>
        private readonly ICache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddProductCommandHandler"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="context">The context.</param>
        /// <param name="notificationService">The notification service.</param>
        /// <param name="cache">The cache.</param>
        public AddProductCommandHandler(IMediator mediator, 
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
        public async Task<AddProductCommandResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var productsList = await _cache.RetrieveAsync<List<GetProductsByIdResponse>>("productsList") ?? new List<GetProductsByIdResponse>();

            var product = new GetProductsByIdResponse {Id = new Random().Next(), Name = $"Product {Context.GetContextDataValue<string>("culture")}", Amount = 10};

            productsList.Add(product);

            await _cache.AddAsync("productsList", productsList, TimeSpan.FromMinutes(1));
            return await Task.Run(() => new AddProductCommandResponse { ProductId = product.Id }, cancellationToken);
        }
    }
}