using System.Threading;
using System.Threading.Tasks;
using Azul.Framework.Test.Mock;
using MediatR;
using NSubstitute;

namespace Azul.Recife.Microservices.Tests.Mocks
{
    /// <summary>
    /// MediatorMock Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Test.Mock.MockBase{MediatR.IMediator}</cref>
    /// </seealso>
    public class MediatorMock : MockBase<IMediator>
    {
        public override IMediator GetMock()
        {
            return Substitute.For<IMediator>();
        }
    }
}