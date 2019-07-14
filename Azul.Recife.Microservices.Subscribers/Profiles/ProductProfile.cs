using AutoMapper;
using Azul.Recife.Microservices.Domain.Commands.v2.AddComment;
using Azul.Recife.Microservices.Subscribers.ProductCommentAdded;

namespace Azul.Recife.Microservices.Subscribers.Profiles
{
    /// <summary>
    /// ProductProfile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ProductProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductProfile"/> class.
        /// </summary>
        public ProductProfile()
        {
            CreateMap<ProductCommentAddedMessage, AddCommentCommand>().ConstructUsingServiceLocator();
        }
    }
}