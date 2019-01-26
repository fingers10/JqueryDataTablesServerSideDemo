using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using ServerSideMultiColumnSortingAndSearching.Contracts;
using ServerSideMultiColumnSortingAndSearching.Infrastructure;
using ServerSideMultiColumnSortingAndSearching.Services;

namespace ServerSideMultiColumnSortingAndSearching
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

            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddAutoMapper(options => options.AddProfile<MappingProfile>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
