using AutoMapper;
using Azul.Recife.Microservices.Data.Repositories.Products.Entities;
using Azul.Recife.Microservices.Domain.Commands.v2.AddProduct;
using Azul.Recife.Microservices.Domain.Commands.v2.ChangeProductPrice;
using Azul.Recife.Microservices.Publishers.ProductPriceChanged;

namespace Azul.Recife.Microservices.Domain.MapperProfiles
{
    /// <summary>
    /// AddProductCommandProductProfile Class.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class AddProductCommandProductProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddProductCommandProductProfile"/> class.
        /// </summary>
        public AddProductCommandProductProfile()
        {
            CreateMap<AddProductCommand, Product>(MemberList.None)
                .ConstructUsingServiceLocator().ForMember(dst => dst.Comments, src => src.Ignore());
            CreateMap<ChangeProductPriceCommand, ProductPriceChangedMessage>().ConstructUsingServiceLocator();
            
        }
    }
}