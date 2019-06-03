using Azul.Framework.Notifications;
using Azul.Framework.Test.Mock;
using NSubstitute;

namespace Azul.Recife.Microservices.Tests.Mocks
{
    /// <summary>
    /// NotificationHandlerMock Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Test.Mock.MockBase{Azul.Framework.Notifications.INotificationHandler}</cref>
    /// </seealso>
    public class NotificationHandlerMock : MockBase<INotificationHandler>
    {
        /// <summary>
        /// Gets the mock.
        /// </summary>
        /// <returns></returns>
        public override INotificationHandler GetMock()
        {
            return Substitute.For<INotificationHandler>();
        }
    }
}