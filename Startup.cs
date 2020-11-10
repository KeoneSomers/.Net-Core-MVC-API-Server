using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using studentApi.Data;

namespace studentApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<Context>(option => 
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddSwaggerGen();
        }




        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Development
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI( option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "studentAPI Dashboard V1");
                option.RoutePrefix = string.Empty;
            });


            // dotNet
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
