using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Azul.Framework.Context;
using Azul.Framework.Domain.Commands;
using Azul.Framework.Notifications;
using Azul.Recife.Microservices.Data.Repositories.Products;
using Azul.Recife.Microservices.Exceptions;
using MediatR;
using MongoDB.Bson;

namespace Azul.Recife.Microservices.Domain.Queries.v2.GetProductsComments
{
    /// <summary>
    /// GetProductsCommentsQueryHandler
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Domain.Commands.BaseCommandHandler</cref>
    /// </seealso>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Azul.Recife.Microservices.Domain.Queries.v2.GetProductsComments.GetProductsCommentsQuery,
    ///         Azul.Recife.Microservices.Domain.Queries.v2.GetProductsComments.GetProductsCommentsResponse}
    ///     </cref>
    /// </seealso>
    public class GetProductsCommentsQueryHandler : BaseCommandHandler, IRequestHandler<GetProductsCommentsQuery, GetProductsCommentsResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductsCommentsQueryHandler" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="context">The context.</param>
        /// <param name="notificationService">The notification service.</param>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="mapper">The mapper.</param>
        public GetProductsCommentsQueryHandler(IMediator mediator, 
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
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<GetProductsCommentsResponse> Handle(GetProductsCommentsQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindByIdAsync(new ObjectId(request.ProductId));
            if (product != null)
            {
                return new GetProductsCommentsResponse {Comments = _mapper.Map<List<Comment>>(product.Comments)};
            }
            throw new ProductDoesNotExistException();



        }
    }
}