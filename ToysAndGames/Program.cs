using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Data;

namespace ToysAndGames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();



            using (var scope = host.Services.CreateScope())
            {



                var services = scope.ServiceProvider;
                var logging = services.GetService<ILogger<Program>>();
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();



                try
                {
                    logging.LogInformation("Started Migration");
                    db.Database.Migrate();
                    logging.LogInformation("Migration Appplied");



                }
                catch (Exception e)
                {
                    logging.LogError(e.Message);
                }



            }



            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
