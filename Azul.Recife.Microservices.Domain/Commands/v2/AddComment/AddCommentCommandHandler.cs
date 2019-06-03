using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azul.Framework.Context;
using Azul.Framework.Domain.Commands;
using Azul.Framework.Notifications;
using Azul.Recife.Microservices.Data.Repositories.Products;
using Azul.Recife.Microservices.Data.Repositories.Products.Entities;
using MediatR;
using MongoDB.Bson;

namespace Azul.Recife.Microservices.Domain.Commands.v2.AddComment
{
    /// <summary>
    /// AddCommentCommandHandler Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Domain.Commands.BaseCommandHandler</cref>
    /// </seealso>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Azul.Recife.Microservices.Domain.Commands.v2.AddComment.AddCommentCommand,
    ///         System.Boolean}
    ///     </cref>
    /// </seealso>
    public class AddCommentCommandHandler : BaseCommandHandler, IRequestHandler<AddCommentCommand,bool>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCommentCommandHandler" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="context">The context.</param>
        /// <param name="notificationService">The notification service.</param>
        /// <param name="productRepository">The product repository.</param>
        public AddCommentCommandHandler(IMediator mediator, 
                                        IContext context, 
                                        INotificationHandler notificationService,
                                        IProductRepository productRepository) : base(mediator, context, notificationService)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindByIdAsync(new ObjectId(request.Id));
            if (product != null)
            {
                if (product.Comments == null)
                {
                    product.Comments = new List<Comment>();
                }
                product.Comments.Add(new Comment {CommentText = request.CommentText, Author = request.Author});
                await _productRepository.UpdateAsync(product);
            }
            return true;
        }
    }
}