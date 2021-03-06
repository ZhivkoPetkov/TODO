using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TODO.Domains.Data;
using AutoMapper;
using TODO.Utilities;
using TODO.Services.Contracts;
using TODO.Services;
using System;
using TODO.Domains;

namespace TODO
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(opts =>
                                 opts.UseInMemoryDatabase(Constants.databaseName).UseLazyLoadingProxies());
            services.AddScoped<ApplicationDbContext>();

            services.AddAutoMapper(c => c.AddProfile<AutoMapperConfig>(), typeof(Startup));

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITaskService, TaskService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Seeder.SeedCategories(dbContext);

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

         
        }

    }
}
