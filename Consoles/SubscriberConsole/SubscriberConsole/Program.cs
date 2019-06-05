using System;
using AutoMapper;
using Azul.Framework.Events.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using SimpleInjector;

namespace SubscriberConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for price change in products.");
            var container = new Container();
            container.Register(() => Substitute.For<IMediator>(), Lifestyle.Singleton);
            container.Register(() => Substitute.For<ILoggerFactory>(), Lifestyle.Singleton);
            container.Register(() => Substitute.For<IMapper>(), Lifestyle.Singleton);

            container.RegisterSubscribers(typeof(Program).Assembly);

            container.StartSubscribers();
            Console.ReadKey();
        }
    }
}
