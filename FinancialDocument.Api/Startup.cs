using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Data.Context;
using FinancialDocument.Data.Repositories;
using FinancialDocument.Domain.Interfaces.Services;
using FinancialDocument.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using FinancialDocument.IoC;

namespace FinancialDocument.Api
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
            #region connection
            var server = Configuration["mysql_server"] ?? "localhost";
            var port = Configuration["mysql_port"] ?? "3306";
            var user = Configuration["mysql_user"] ?? "root";
            var password = Configuration["mysql_pass"] ?? "";
            var database = Configuration["mysql_database"] ?? "app";

            var mySqlConn = $"Data Source={server},{port};Initial Catalog={database};Persist Security Info=True;User ID={user};Password={password}";
            #endregion
            services.AddDbContextPool<AppDbContext>(options => options.UseMySql(mySqlConn, ServerVersion.AutoDetect(mySqlConn)));

            services.AddControllers()
                .AddJsonOptions(x =>
                {
                    //    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    //    //x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    //    x.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    //    x.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                //.AddXmlSerializerFormatters()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });


            services.AddMediatR(typeof(Startup));

            // Add Context
            services.AddScoped<AppDbContext>();

            // Initialize the application container
            InitializeIoC.ConfigureServices(services);

            //Swagger configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinancialDocument.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinancialDocument.Api v1"));
            }

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
