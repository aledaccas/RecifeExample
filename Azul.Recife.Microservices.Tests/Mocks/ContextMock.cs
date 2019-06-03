using Azul.Framework.Context;
using Azul.Framework.Test.Mock;
using NSubstitute;

namespace Azul.Recife.Microservices.Tests.Mocks
{
    /// <summary>
    /// ContextMock Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Test.Mock.MockBase{Azul.Framework.Context.IContext}</cref>
    /// </seealso>
    public class ContextMock : MockBase<IContext>
    {
        /// <summary>
        /// Gets the mock.
        /// </summary>
        /// <returns></returns>
        public override IContext GetMock()
        {
            return Substitute.For<IContext>();
        }
    }
}