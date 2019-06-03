using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using Azul.Framework.Api.Attributes;
using Azul.Framework.Api.Controllers;
using Azul.Framework.Context;
using Azul.Framework.Notifications;
using Azul.Framework.Resource.Interfaces;
using Azul.Recife.Microservices.Domain.Commands.v2.AddProduct;
using Azul.Recife.Microservices.Domain.Commands.v2.ChangeProductPrice;
using Azul.Recife.Microservices.Domain.Queries.v2.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Azul.Recife.Microservices.Api.Controllers.v2
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
        /// Adds the products asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("api/v2/products")]
        [ProducesResponseType(typeof(AddProductCommandResponse), (int)HttpStatusCode.Created)]
        [SwaggerCultureHeader]
        [ExcludeFromCodeCoverage]
        public async Task<IActionResult> AddProductsAsync(AddProductCommand request)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(request), HttpStatusCode.Created);
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/v2/products")]
        [ProducesResponseType(typeof(GetProductsByIdResponse), 200)]
        public async Task<IActionResult> GetProducts()
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(new GetProductsQuery()));
        }

        /// <summary>
        /// Changes the product price.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        [HttpPut("api/v2/products/{productId}/price")]
        [ProducesResponseType(typeof(GetProductsByIdResponse), 200)]
        public async Task<IActionResult> ChangeProductPrice(string productId , string price)
        {
            var command = new ChangeProductPriceCommand {Id = productId, Amount = double.Parse(price)};
            return await GenerateResponseAsync(async () => await MediatorService.Send(command));
        }
    }
}