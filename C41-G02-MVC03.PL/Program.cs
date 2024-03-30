using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C41_G02_MVC03.PL
{
    public class Program
    {
        //Entry Point
        public static void Main(string[] args)
        {
            var hostBuilder =  CreateHostBuilder(args).Build();
            //Data Seeding [Insert some data]
            // Apply Migrations

            hostBuilder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
