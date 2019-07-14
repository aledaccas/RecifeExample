using AutoMapper;
using Azul.Recife.Microservices.Data.Repositories.Products.Entities;
using Azul.Recife.Microservices.Domain.Queries.v2.GetProducts;

namespace Azul.Recife.Microservices.Domain.MapperProfiles
{
    /// <summary>
    /// ProductGetProductsByIdResponse
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ProductGetProductsByIdResponse : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductGetProductsByIdResponse"/> class.
        /// </summary>
        public ProductGetProductsByIdResponse()
        {
            CreateMap<Product, GetProductsByIdResponse>().ConstructUsingServiceLocator();
            CreateMap<Comment, Queries.v2.GetProductsComments.Comment>().ConstructUsingServiceLocator();
        }
    }
}