using AutoMapper;
using Azul.Recife.Microservices.Data.Repositories.Products.Entities;
using Azul.Recife.Microservices.Domain.Queries.v2.GetProducts;

namespace Azul.Recife.Microservices.Domain.MapperProfiles
{
    public class ProductGetProductsByIdResponse : Profile
    {
        public ProductGetProductsByIdResponse()
        {
            CreateMap<Product, GetProductsByIdResponse>()
                .ConstructUsingServiceLocator();
        }
    }
}