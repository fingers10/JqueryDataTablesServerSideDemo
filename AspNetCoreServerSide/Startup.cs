using AspNetCoreServerSide.Contracts;
using AspNetCoreServerSide.Services;
using AutoMapper;
using JqueryDataTables.ServerSide.AspNetCoreWeb.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                    options.UseInMemoryDatabase("fingers10db");
                });

            services.AddControllersWithViews()
                    .AddJqueryDataTables();
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
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
