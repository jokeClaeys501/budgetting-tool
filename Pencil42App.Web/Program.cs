// using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
// using Utilities;
// using Utilities.Mvc;

namespace Pencil42App.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
            builder.ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                });
            // certificate for Web TODO: remove
            /* X509Certificate2 cert = Certificate.FromFile("local.pfx", "pencil");
            {
                builder.UseKestrel(options =>
                {
                    options.ConfigureHttpsDefaults(httpsOptions =>
                    {
                        httpsOptions.ServerCertificate = cert;
                    });
                });
             } */
            return builder;
        }
    }
}
