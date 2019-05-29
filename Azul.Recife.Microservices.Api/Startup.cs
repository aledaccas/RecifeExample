using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azul.Framework.Api.Startup;
using Azul.Recife.Microservice.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Azul.Recife.Microservice
{
    /// <summary>
    /// Startup class.
    /// </summary>
    /// <seealso cref="Azul.Framework.Api.Startup.ApiStartupBase" />
    public class Startup : ApiStartupBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        public Startup()
        {
            SetDependencyInjectionBootstrap(new Bootstrapper());
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddMvc();
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.Configure(app, env);
            app.UseMvc();
        }
    }
}
