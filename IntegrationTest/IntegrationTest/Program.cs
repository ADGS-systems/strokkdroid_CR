using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IntegrationTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                   

                    var config = new ConfigurationBuilder()
                                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                   .AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true)
                                   .AddEnvironmentVariables()
                                   .Build();

                    webBuilder.UseConfiguration(config);
                    webBuilder.ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();

                    });

                    webBuilder.UseNLog(NLogAspNetCoreOptions.Default);


                    webBuilder.ConfigureKestrel(o =>
                    {
                        Console.WriteLine("Using HTTP");
                        o.Listen(IPAddress.Parse(config["BindAddress"]), int.Parse(config["ListenPort"]));
                    });
                    webBuilder.UseStartup<Startup>();
                });



        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //  Host.CreateDefaultBuilder(args)
        //      .ConfigureWebHostDefaults(webBuilder =>
        //      {                   
        //          webBuilder.UseStartup<Startup>();
        //      });

    }
}
