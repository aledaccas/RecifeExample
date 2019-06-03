using Azul.Framework.Api.Exceptions;
using System.Net;

namespace Azul.Recife.Microservices.Exceptions
{
    public class ProductDoesNotExistException : ApiHttpCustomException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDoesNotExistException" /> class.
        /// </summary>
        public ProductDoesNotExistException() : base("ProductDoesNotExist", HttpStatusCode.NotFound) { }
    }
}