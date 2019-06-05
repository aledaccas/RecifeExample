using System.Linq;
using Azul.Framework.Api.Ioc;
using Azul.Framework.Api.Pipelines;
using Azul.Framework.Cache;
using Azul.Framework.Cache.Memory;
using Azul.Framework.Events;
using Azul.Framework.Events.Extensions;
using Azul.Framework.Resource.File;
using Azul.Framework.Resource.Interfaces;
using Azul.Recife.Microservices.Data.Repositories.Products;
using Azul.Recife.Microservices.Domain.Queries.v1.GetProductsById;
using Azul.Recife.Microservices.Publishers.ProductPriceChanged;
using Azul.Recife.Microservices.Services.PostService;
using Azul.Recife.Microservices.Subscribers.ProductCommentAdded;
using FluentValidation;
using MediatR;
using SimpleInjector;

namespace Azul.Recife.Microservices.Api.Ioc
{
    /// <summary>
    /// Bootstrapper Class.
    /// </summary>
    /// <seealso cref="Azul.Framework.Api.Ioc.BaseDependencyInjectionBootstrap" />
    public class Bootstrapper : BaseDependencyInjectionBootstrap
    {
        /// <summary>
        /// Injects the dependencies into application.
        /// </summary>
        /// <param name="container">The dependency injection container.</param>
        public override void Inject(Container container)
        {
            base.Inject(container);
            container.Register(typeof(ICache), typeof(MemoryCache), Lifestyle.Singleton);
            container.Register<ICache, MemoryCache>(Lifestyle.Singleton);
            container.RegisterInstance<IResourceCatalog>(new ResourceFileCatalog(new MemoryCache()));
            container.Register(typeof(IValidator<>), typeof(GetProductsByIdQuery).Assembly, Lifestyle.Singleton);

            InjectAutoMapper(container, typeof(GetProductsByIdQuery).Assembly);
            InjectMediator(container, typeof(GetProductsByIdQuery).Assembly);
            InjectServices(container);
            InjectRepositories(container);

            container.RegisterPublishers(typeof(ProductPriceChangedPublisher).Assembly);
            container.RegisterSubscribers(typeof(ProductCommentAddedSubscriber).Assembly);
        }

        /// <summary>
        /// Injects the mediator pipelines.
        /// </summary>
        /// <param name="container">The container.</param>
        public override void InjectMediatorPipelines(Container container)
        {
            container.Collection.Register(typeof(IPipelineBehavior<,>), new[] { typeof(ValidatorRequestBehavior<,>) });
        }

        /// <summary>
        /// Injects the services.
        /// </summary>
        /// <param name="container">The container.</param>
        private void InjectServices(Container container)
        {
            container.Register<IPostService, PostService>(Lifestyle.Singleton);
        }

        /// <summary>
        /// Injects the repositories.
        /// </summary>
        /// <param name="container">The container.</param>
        private void InjectRepositories(Container container)
        {
            container.Register<IProductRepository>(() => new ProductRepository("Products", "recconnection"), Lifestyle.Singleton);
        }
    }
}
