using System.Net;
using System.Threading.Tasks;
using Azul.Framework.Api.Attributes;
using Azul.Framework.Api.Controllers;
using Azul.Framework.Context;
using Azul.Framework.Notifications;
using Azul.Framework.Resource.Interfaces;
using Azul.Recife.Microservices.Domain.Commands;
using Azul.Recife.Microservices.Domain.Commands.v1.AddProduct;
using Azul.Recife.Microservices.Domain.Queries.v1.GetProducts;
using Azul.Recife.Microservices.Domain.Queries.v1.GetProductsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Azul.Recife.Microservices.Api.Controllers.v1
{
    /// <summary>
    /// Products Controller
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Api.Controllers.BaseController{Azul.Recife.Microservice.Controllers.ProductsController}</cref>
    /// </seealso>
    [ApiController]
    public class ProductsController : BaseController<ProductsController>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="mediatorService">The mediator service.</param>
        /// <param name="notificationHandler">The notification handler.</param>
        /// <param name="context">The context.</param>
        /// <param name="resourceCatalog">The resource catalog.</param>
        public ProductsController(ILoggerFactory loggerFactory, 
                                  IMediator mediatorService, 
                                  INotificationHandler notificationHandler, 
                                  IContext context, 
                                  IResourceCatalog resourceCatalog) 
            : base(loggerFactory, mediatorService, notificationHandler, context, resourceCatalog)
        {
        }
        
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/v1/products")]
        [ProducesResponseType(typeof(GetProductsByIdResponse), 200)]
        public async Task<IActionResult> GetProducts()
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(new GetProductsQuery()));
        }

        /// <summary>
        /// Gets the products asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        [HttpGet("api/v1/products/{productId}")]
        [ProducesResponseType(typeof(GetProductsByIdResponse), 200)]
        //[SwaggerAuthorizationHeader]
        [SwaggerCultureHeader]
        //[SwaggerDeviceHeader]
        public async Task<IActionResult> GetProductsAsync(int productId)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(new GetProductsByIdQuery { ProductId = productId }));
        }
        
        /// <summary>
        /// Adds the products asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("api/v1/products")]
        [ProducesResponseType(typeof(AddProductCommandResponse), (int)HttpStatusCode.Created)]
        [SwaggerCultureHeader]
        public async Task<IActionResult> AddProductsAsync(AddProductCommand request)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(request), HttpStatusCode.Created);
        }
    }
}