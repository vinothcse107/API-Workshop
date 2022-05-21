using API_Workshop.Data;
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

namespace API_Workshop
{
      public class Program
      {
            public static async Task Main(string[] args)
            {
                  var build = CreateHostBuilder(args).Build();
                  using var scope = build.Services.CreateScope();
                  var services = scope.ServiceProvider;
                  try
                  {
                        var con = services.GetRequiredService<DbxContext>();
                        con.Database.Migrate();
                        // Run Once Only On Start

                        await Seed.SeedLocationAsync(con);
                        await Seed.SeedDepartment(con);
                        await Seed.SeedJobs(con);
                        await Seed.SeedEmployees(con);
                  }
                  catch (Exception ex)
                  {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred during migration");
                  }

                  await build.RunAsync();
            }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                          webBuilder.UseStartup<Startup>();
                    });
      }
}
