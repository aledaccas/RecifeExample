using System;
using Azul.Framework.Api;
using Azul.Framework.Api.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Azul.Recife.Microservices.Api
{
    /// <summary>
    /// Program Class.
    /// </summary>
    /// <seealso cref="Azul.Framework.Api.BaseProgram" />
    public class Program : BaseProgram
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Logger.LogCritical(e, "Host terminated unexpectally.");
            }
        }

        /// <summary>
        /// Creates the web host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseCustomLog();
    }
}
