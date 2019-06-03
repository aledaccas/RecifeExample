using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using Azul.Framework.Test.Mock;
using Azul.Recife.Microservices.Domain.Commands.v1.AddProduct;

namespace Azul.Recife.Microservices.Tests.Mocks
{
    /// <summary>
    /// AutoMapper Class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Test.Mock.MockBase{AutoMapper.IMapper}</cref>
    /// </seealso>
    public class MapperMock : MockBase<IMapper>
    {
        /// <summary>
        /// Gets the mock.
        /// </summary>
        /// <returns></returns>
        public override IMapper GetMock()
        {
            var mapperConfigurationExpression = new MapperConfigurationExpression();
            mapperConfigurationExpression.Advanced.AllowAdditiveTypeMapCreation = true;

            //Add Profiles to AutoMapper.
            var profiles = typeof(AddProductCommand).Assembly.GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t)).ToList();
            mapperConfigurationExpression.AddProfiles(profiles);

            var mapperConfiguration = new MapperConfiguration(mapperConfigurationExpression);
            mapperConfiguration.AssertConfigurationIsValid();
            return new Mapper(mapperConfiguration);
        }
    }

    
}