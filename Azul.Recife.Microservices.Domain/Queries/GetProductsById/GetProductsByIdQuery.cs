using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Queries.GetProductsById
{
    /// <summary>
    /// GetProductsByIdQuery Class.
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Azul.Recife.Microservices.Domain.Queries.GetProductsById.GetProductsByIdResponse}" />
    public class GetProductsByIdQuery : IRequest<GetProductsByIdResponse>
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        [JsonProperty("productId")]
        public int ProductId { get; set; }
    }
}
