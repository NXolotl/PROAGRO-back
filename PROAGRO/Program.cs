using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PROAGRO.Data;
using PROAGRO.Data.Seeders;
using System;

namespace PROAGRO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            CreateDBIfNotExist(host);
            host.Run();
        }

        private static void CreateDBIfNotExist(IHost host)
        {
            using var scope = host.Services.CreateScope();
            IServiceProvider services = scope.ServiceProvider;

            try
            {
                Context context = services.GetRequiredService<Context>();
                InitialCharge.Initialize(context);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
