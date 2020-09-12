using AspNetCoreServerSide.Contracts;
using AspNetCoreServerSide.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace AspNetCoreServerSide
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDemoService, DefaultDemoService>();

            // Use in-memory database for quick dev and testing
            services.AddDbContext<Fingers10DbContext>(
                options =>
                {
                    //options.UseInMemoryDatabase("fingers10db");
                    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JqueryDataTablesAspNetServerSide;Trusted_Connection=True;MultipleActiveResultSets=true");
                });

            // Set the languages you want to support in your app.
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var ciEn = new CultureInfo("en");
                var ciFr = new CultureInfo("fr");
                var supportedCultures = new List<CultureInfo>
                {
                    ciEn,
                    ciFr
                };

                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.AddPortableObjectLocalization(options => options.ResourcesPath = "wwwroot/lang");

            services.AddControllersWithViews()
                    //.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    })
                    // Add those 2 functions to support localization
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization();;
                    
            services.AddSession();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();
            //To use the localization in your app
            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
