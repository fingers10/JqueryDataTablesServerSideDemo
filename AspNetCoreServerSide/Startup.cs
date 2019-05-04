using AspNetCoreServerSide.Binders;
using AspNetCoreServerSide.Contracts;
using AspNetCoreServerSide.Infrastructure;
using AspNetCoreServerSide.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace AspNetCoreServerSide
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDemoService,DefaultDemoService>();

            // Use in-memory database for quick dev and testing
            services.AddDbContext<Fingers10DbContext>(
                options => {
                    options.UseInMemoryDatabase("fingers10db");
                });

            services
                .AddAntiforgery(options => options.HeaderName = "XSRF-TOKEN")
                .AddMvc(options => {
                    options.ModelBinderProviders.Insert(0,new JqueryDataTableBinderProvider());
                })
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddAutoMapper(options => options.AddProfile<MappingProfile>());

            //services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //app.UseSession();
            app.UseMvcWithDefaultRoute();
        }
    }
}
