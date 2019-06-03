using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using Azul.Framework.Test.Mock;
using Azul.Recife.Microservices.Data.Repositories.Products;
using Azul.Recife.Microservices.Data.Repositories.Products.Entities;
using Azul.Recife.Microservices.Domain.Commands.v1.AddProduct;
using MongoDB.Bson;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Azul.Recife.Microservices.Tests.Mocks
{
    /// <summary>
    /// ProductRepositoryMock Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Test.Mock.MockBase{Azul.Recife.Microservices.Data.Repositories.Products.IProductRepository}</cref>
    /// </seealso>
    public class ProductRepositoryMock : MockBase<IProductRepository>
    {
        /// <summary>
        /// Gets the mock.
        /// </summary>
        /// <returns></returns>
        public override IProductRepository GetMock()
        {
            var mock = Substitute.For<IProductRepository>();

            mock.AddAsync(new Product()).Returns(x =>
            {
                ((Product)x[0]).Id = ObjectId.GenerateNewId();
                return Task.CompletedTask;
            });

            return mock;
        }
    }
}