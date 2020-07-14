using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContosoUniversity.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExist(host);                                       //#1)
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void CreateDbIfNotExist(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var db = services.GetRequiredService<AcademicsDbContext>();
                    AcademicsDbInitializer.Initialize(db);
                }
                catch (Exception ex)
                {
                    var db = services.GetRequiredService<AcademicsDbContext>();
                    var dbo = new DbContextOptionsBuilder<AcademicsDbContext>();
                    dbo.EnableSensitiveDataLogging(true);

                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "ERR: cannot seed database");
                }
            }
        }
     }
}


/* Annotations
 * #1) This static method adds code to populate the database with initial data.
 * It is based on a Microsoft tutorial on EF Core.  
 * "Razor Pages with Entity Framework Core in ASP.NET Core - Tutorial 1 of 8"
 * Scroll to Create the database and Seed the database section.
 * https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-3.1&tabs=visual-studio#create-the-database
 * 
 */
