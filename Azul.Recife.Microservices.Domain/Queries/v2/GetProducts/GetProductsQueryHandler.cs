using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Azul.Framework.Cache;
using Azul.Framework.Context;
using Azul.Framework.Domain.Commands;
using Azul.Framework.Notifications;
using Azul.Recife.Microservices.Data.Repositories.Products;
using MediatR;

namespace Azul.Recife.Microservices.Domain.Queries.v2.GetProducts
{
    /// <summary>
    /// GetProductsQueryHandler Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Domain.Commands.BaseCommandHandler</cref>
    /// </seealso>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Azul.Recife.Microservices.Domain.Queries.v1.GetProducts.GetProductsQuery,
    ///         Azul.Recife.Microservices.Domain.Queries.v1.GetProducts.GetProductsResponse}
    ///     </cref>
    /// </seealso>
    public class GetProductsQueryHandler : BaseCommandHandler,  IRequestHandler<GetProductsQuery, GetProductsResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductsQueryHandler" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="context">The context.</param>
        /// <param name="notificationService">The notification service.</param>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="mapper">The mapper.</param>
        public GetProductsQueryHandler(IMediator mediator, 
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
        public async Task<GetProductsResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.FindAllAsync();
            var response = _mapper.Map<List<GetProductsByIdResponse>>(products);
            return new GetProductsResponse {Products = response };
        }
    }
}