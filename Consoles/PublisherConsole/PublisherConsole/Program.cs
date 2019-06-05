using System;
using Azul.Framework.Events;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace PublisherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add a comment to product.");
            Console.WriteLine("ProductId: ");
            var productId = Console.ReadLine();
            Console.WriteLine("Author: ");
            var author = Console.ReadLine();
            Console.WriteLine("Comment: ");
            var comment = Console.ReadLine();

            IPublisher<ProductCommentAddedMessage> publisher = new ProductCommentAddedPublisher(Substitute.For<ILoggerFactory>());
            publisher.PublishAsync(new ProductCommentAddedMessage {Id = productId, Author = author, CommentText = comment});

            Console.WriteLine("Comment published.");
            Console.ReadKey();
        }
    }
}
