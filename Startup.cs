using API_Workshop.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Workshop.DI;

namespace API_Workshop
{
      public class Startup
      {
            public Startup(IConfiguration configuration)
            {
                  Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {

                  services.AddTransient<ITransientService, DependencyInjection>();
                  services.AddScoped<IScopedService, DependencyInjection>();
                  services.AddSingleton<ISingletonService, DependencyInjection>();

                  services.AddDbContext<DbxContext>(o => o.UseSqlServer(Configuration.GetConnectionString("API")));
                  services.AddCors();
                  services.AddControllers();
                  services.AddSwaggerGen(c =>
                  {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Workshop", Version = "v1" });
                  });
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                  // app.Use method adds the middleware, which may 
                  // call the next middleware in the pipeline

                  app.Use(async (context, next) =>
                  {
                        System.Console.WriteLine("Hello World");
                        System.Console.WriteLine("Hello World2");
                        await next.Invoke();
                        System.Console.WriteLine("Hello World3 \n");

                  });

                  if (env.IsDevelopment())
                  {
                        app.UseDeveloperExceptionPage();
                        app.UseSwagger();
                        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Workshop v1"));
                  }

                  app.UseHttpsRedirection();

                  app.UseRouting();

                  app.UseAuthorization();

                  app.UseEndpoints(endpoints =>
                  {
                        endpoints.MapControllers();
                  });

                  // app.Run() Terminating Middleware Statement
                  app.Run(async (context) =>
                  {
                        await Task.Run(() =>
                        {
                              context.Response.Redirect("https://localhost:5001/swagger/index.html");
                        });
                  });
            }
      }
}
