using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azul.Framework.Api.Ioc;
using Azul.Framework.Api.Pipelines;
using Azul.Framework.Cache.Memory;
using Azul.Framework.Resource.File;
using Azul.Framework.Resource.Interfaces;
using Azul.Recife.Microservices.Domain.Commands;
using Azul.Recife.Microservices.Domain.Queries.GetProductsById;
using FluentValidation;
using MediatR;
using SimpleInjector;

namespace Azul.Recife.Microservice.Ioc
{
    public class Bootstrapper : BaseDependencyInjectionBootstrap
    {
        public override void Inject(Container container)
        {
            base.Inject(container);
            InjectMediator(container, typeof(GetProductsByIdQuery).Assembly);
            container.Register(typeof(IValidator<>), typeof(GetProductsByIdQuery).Assembly, Lifestyle.Scoped);
            
            container.RegisterInstance<IResourceCatalog>(new ResourceFileCatalog(new MemoryCache()));
        }

        public override void InjectMediatorRequestHandlers(Container container)
        {
        }

        public override void InjectMediatorPipelines(Container container)
        {
            container.Collection.Register(typeof(IPipelineBehavior<,>), new[] { typeof(ValidatorRequestBehavior<,>) });
        }
    }
}
