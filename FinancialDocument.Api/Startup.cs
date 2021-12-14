using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using FinancialDocument.Data.Context;
using FinancialDocument.Data.Repositories;
using FinancialDocument.Domain.Core.Interfaces.Services;
using FinancialDocument.Domain.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

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
                .AddJsonOptions(x => {
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    //x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    x.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    x.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddXmlSerializerFormatters();

            services.AddMediatR(typeof(Startup));

            // Add Context
            services.AddScoped<AppDbContext>();

            //Repositories
            services.AddTransient<IRepository<PaymentMethod>, PaymentMethodRepository>();
            services.AddTransient<IRepository<ReceivingLocation>, ReceivingLocationRepository>();
            services.AddTransient<IRepository<BusinessPartner>, BusinessPartnerRepository>();
            services.AddTransient<IRepository<Document>, DocumentRepository>();
            services.AddTransient<IRepository<DocumentDetail>, DocumentDetailRepository>();

            //Services
            services.AddTransient<IPaymentMethodService, PaymentMethodService>();
            services.AddTransient<IReceivingLocationService, ReceivingLocationService>();
            services.AddTransient<IBusinessPartnerService, BusinessPartnerService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IDocumentDetailService, DocumentDetailService>();

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
