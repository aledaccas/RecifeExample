using System.Collections.Generic;
using System.Threading.Tasks;
using Azul.Framework.Data.Interfaces;
using Azul.Recife.Microservices.Data.Repositories.Products.Entities;
using MongoDB.Bson;

namespace Azul.Recife.Microservices.Data.Repositories.Products
{
    /// <summary>
    /// IProductRepository interface.
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Azul.Framework.Data.Interfaces.IRepository{Azul.Recife.Microservices.Data.Repositories.Products.Entities.Product,
    ///         MongoDB.Bson.ObjectId}
    ///     </cref>
    /// </seealso>
    public interface IProductRepository : IRepository<Product, ObjectId>
    {
    }
}