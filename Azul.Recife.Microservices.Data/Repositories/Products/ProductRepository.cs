using Azul.Framework.Data.MongoDb;
using Azul.Recife.Microservices.Data.Repositories.Products.Entities;
using MongoDB.Bson;

namespace Azul.Recife.Microservices.Data.Repositories.Products
{
    /// <summary>
    /// ProductRepository Class.
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Azul.Framework.Data.MongoDb.MongoDbRepository{Azul.Recife.Microservices.Data.Repositories.Products.Entities.Product,
    ///         MongoDB.Bson.ObjectId}
    ///     </cref>
    /// </seealso>
    public class ProductRepository : MongoDbRepository<Product, ObjectId>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="collection">The name of collection.</param>
        /// <param name="connectionName">Name of the database connection.</param>
        /// <param name="serverUrl">The server URL.</param>
        public ProductRepository(string collection, 
                                 string connectionName, 
                                 string serverUrl = null) : base(collection, connectionName, serverUrl)
        {
        }
    }
}