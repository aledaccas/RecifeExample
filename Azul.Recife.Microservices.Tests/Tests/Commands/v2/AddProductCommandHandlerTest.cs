using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Azul.Framework.Test.Base;
using Azul.Recife.Microservices.Domain.Commands.v2.AddProduct;
using Azul.Recife.Microservices.Tests.Mocks;
using NUnit.Framework;

namespace Azul.Recife.Microservices.Tests.Tests.Commands.v2
{
    //1. Setup
    //2. Execute
    //3. Assert
    //4. Tear Down


    /// <summary>
    /// AddProductCommandHandlerTest Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Test.Base.TestTemplateContext{Azul.Recife.Microservices.Domain.Commands.v2.AddProduct.AddProductCommandHandler}</cref>
    /// </seealso>
    [TestFixture]
    public class AddProductCommandHandlerTest : TestTemplateContext<AddProductCommandHandler>
    {
        /// <summary>
        /// Establishes the context.
        /// </summary>
        /// <returns></returns>
        protected override AddProductCommandHandler EstablishContext()
        {
            return new AddProductCommandHandler(new MediatorMock().GetMock(),
                                                new ContextMock().GetMock(),
                                                new NotificationHandlerMock().GetMock(),
                                                new ProductRepositoryMock().GetMock(),
                                                new MapperMock().GetMock());
        }

        /// <summary>
        /// Tests the cleanup.
        /// </summary>
        protected override void TestCleanup()
        {
        }

        /// <summary>
        /// Asserts the that can add product.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Assert_That_Can_Add_Product()
        {
            var addProductCommand = new Fixture().Create<AddProductCommand>();
            var response = await SubjectUnderTest.Handle(addProductCommand, CancellationToken.None);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.ProductId);
            Assert.IsNotEmpty(response.ProductId);
            Assert.Greater(response.ProductId.Length, 3);
        }

        /// <summary>
        /// Asserts the that can add product without comment.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Assert_That_Can_Add_Product_Without_Comment()
        {
            var addProductCommand = new Fixture().Create<AddProductCommand>();
            addProductCommand.Comments.Clear();
            var response = await SubjectUnderTest.Handle(addProductCommand, CancellationToken.None);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.ProductId);
            Assert.IsEmpty(response.ProductId);
            Assert.Less(response.ProductId.Length, 1);
        }

        /// <summary>
        /// Asserts the that can add product without comment.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Assert_That_Can_Add_Product_With_one_Comment()
        {
            var addProductCommand = new Fixture().Create<AddProductCommand>();
            addProductCommand.Comments = new List<Comment> { new Comment() };
            await Task.Run(() => 
                Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => 
                    await SubjectUnderTest.Handle(addProductCommand, CancellationToken.None)));
        }
    }
}