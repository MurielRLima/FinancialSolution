using FinancialDocument.Data.Context;
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
using FinancialDocument.Api.Filters;
using System.Reflection;
using System.IO;
using System;
using Swashbuckle.AspNetCore.Filters;
using FinancialDocument.Api.Examples.JsonResponse;
using FinancialDocument.Api.Examples.BusinessPartner;
using FinancialDocument.Api.Examples.PaymentMethod;
using FinancialDocument.Api.Examples.ReceivingLocation;
using FinancialDocument.Api.Examples.Document;

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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((host) => true);
                    });
            });
            //services.AddCors();


            #region connection
            var server = Configuration["mysql_server"] ?? "localhost";
            var port = Configuration["mysql_port"] ?? "3306";
            var user = Configuration["mysql_user"] ?? "root";
            var password = Configuration["mysql_pass"] ?? "";
            var database = Configuration["mysql_database"] ?? "app";

            var mySqlConn = $"Data Source={server},{port};Initial Catalog={database};Persist Security Info=True;User ID={user};Password={password}";
            #endregion
            services.AddDbContextPool<AppDbContext>(options => options.UseMySql(mySqlConn, ServerVersion.AutoDetect(mySqlConn)));

            services.AddControllers(options =>
                {
                    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                    options.RespectBrowserAcceptHeader = true; // false by default
                })
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
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.SchemaFilter<SwaggerExcludeFilter>();
                c.IncludeXmlComments(xmlPath);
                c.ExampleFilters(); // This is mandatory for examples in swagger

                //c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "basic",
                //    In = ParameterLocation.Header,
                //    Description = "Basic Authorization header using the Bearer scheme."
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "basic"
                //            }
                //        },
                //        new string[] {}
                //    }
                //});

                c.EnableAnnotations();
            })
            .AddSwaggerGenNewtonsoftSupport();

            // Add swagger request and response examples
            services.AddSwaggerExamplesFromAssemblyOf<JsonAppResponseErrosExample>();

            // BusinessPartner
            services.AddSwaggerExamplesFromAssemblyOf<BusinessPartnerAddCommandExample>();
            services.AddSwaggerExamplesFromAssemblyOf<BusinessPartnerUpdateCommandExample>();
            services.AddSwaggerExamplesFromAssemblyOf<BusinessPartnerResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<BusinessPartnerGetAllResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<BusinessPartnerGetResponseExample>();

            // PaymentMethod
            services.AddSwaggerExamplesFromAssemblyOf<PaymentMethodGetAllResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<PaymentMethodAddCommandExample>();
            services.AddSwaggerExamplesFromAssemblyOf<PaymentMethodAddResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<PaymentMethodGetResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<PaymentMethodUpdateCommandExample>();
            services.AddSwaggerExamplesFromAssemblyOf<PaymentMethodUpdateResponseExample>();

            // ReceivingLocation
            services.AddSwaggerExamplesFromAssemblyOf<ReceivingLocationGetAllResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<ReceivingLocationAddCommandExample>();
            services.AddSwaggerExamplesFromAssemblyOf<ReceivingLocationAddResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<ReceivingLocationGetResponseExample>();
            services.AddSwaggerExamplesFromAssemblyOf<ReceivingLocationUpdateCommandExample>();
            services.AddSwaggerExamplesFromAssemblyOf<ReceivingLocationUpdateResponseExample>();

            // Financial document
            services.AddSwaggerExamplesFromAssemblyOf<DocumentAddCommandExample>();


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

            app.UseCors(builder => builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed((host) => true)
                            .AllowCredentials()
                        );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
