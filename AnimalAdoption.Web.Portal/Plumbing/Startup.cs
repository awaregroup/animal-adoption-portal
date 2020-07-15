using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAdoption.Common.Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalAdoption.Web.Portal.Plumbing
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
            services.Configure<Configuration>(Configuration);
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddTransient<CartService>();
            services.AddTransient<AnimalService>();
            services.AddTransient<LoginService>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHttpsRedirection();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            var failurePercentage = Configuration.GetValue<int?>("SimulatedFailureChance");
            if (failurePercentage != null)
            {
                var rand = new Random();
                app.Use(async (context, next) =>
                {
                    if (failurePercentage <= rand.Next(0, 100))
                    {
                        await next.Invoke();
                    }
                    else
                    {
                        throw new Exception($"A simulated failure occured - there is a {failurePercentage}% chance of this occuring");
                    }
                });
            }

            var examplePassword = Configuration.GetValue<string>("GlobalPassword");
            // This example connection string is used for testing that variables have been passed in correctly.

            if (string.IsNullOrWhiteSpace(examplePassword))
            {
                app.Use(async (context, next) =>
                {
                    var url = context.Request.Path.Value;
                    if (!url.ToLowerInvariant().Contains("/missingenvironmentvariable"))
                    {
                        // rewrite and continue processing
                        context.Request.Path = "/missingenvironmentvariable";
                    }

                    await next();
                });
            }


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });         
        }
    }

}
