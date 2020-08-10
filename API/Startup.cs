using API.Filters;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Logic;
using Logic.Interfaces;
using Logic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Repository;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();

            // ADD CONTROLLERS
            // This method configures the MVC services for the commonly used features with controllers for an API.
            services.AddControllers(config => config.Filters.Add(typeof(GlobalExceptionFilter)))
                .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                // CONTRACT RESOLVER
                // CamelCasePropertyNamesContractResolver - this is to allow for serializing/deserializing camelcase properties
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.UseCamelCasing(true);
            });

            services.AddApiVersioning();

            AddDatabaseContextAndMigrate(services, Configuration);

            // ADD CORS
            // Determines Access-Control-Allow headers.  We may be able to tighten this down once the deployed versions are locked down
            // to only routing through the API Gateway.
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Extension Property Service",
                });

                // ADD SECURITY DEFINITION & ADD SECURITY REQUIREMENT
                // These 2 extensions enable the Swagger UI to include the Authorization header in its requests
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Added \"Bearer\" + [space].\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"

                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

                // For basic functionality, above is all that's required, however for summary, remarks, and other comment
                // based swagger and xml file must be generated (in the csproj, the GenerateDocumentationFile tag = true)
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            services.AddAutoMapper(typeof(ExtensionProfile));
            AddLocalServices(services);
        }
        private void AddLocalServices(IServiceCollection services)
        {
            services.AddTransient<IExtensionPropertyService, ExtensionPropertyService>();
            services.AddTransient<IExtensionDomainService, ExtensionDomainService>();
            services.AddTransient<IExtensionPropertyRepo, ExtensionPropertyRepo>();
            services.AddTransient<IExtensionDomainRepo, ExtensionDomainRepo>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // USE CORS
            // This applies the CORS policies as defined during the Startup.ConfigureServices method
            app.UseCors("ApiCorsPolicy");


            // USE PATH BASE
            // This sets the first piece of the request path for anything that would hit this service 
            // (so that all calls to this service must start with what's defined here)
            app.UsePathBase(new PathString("/extensionproperty"));


            // SWAGGER
            // Enable middleware to serve generated Swagger as a JSON endpoint but customize the pathbase.
            app.Use((context, next) =>
            {
                context.Request.PathBase = new PathString("/extensionproperty");
                return next();
            }).UseSwagger();


            // SWAGGER UI
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/extensionproperty/swagger/v1/swagger.json", "Kona Extension Property Endpoints");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void AddDatabaseContextAndMigrate(IServiceCollection services, IConfiguration _configuration)
        {
            // ADD THE CONTEXT TO THE DI CONTAINER

            var connectionStringOriginal = Environment.GetEnvironmentVariable("ConnectionStrings__ExtensionPropertyDBConnection");
            connectionStringOriginal = "Host=localhost;Username=postgres;Password=password;Database=ExtensionProperties;Port=5432";
            string schemaName = _configuration.GetConnectionString("SchemaName");

            services.AddDbContext<ExtensionPropertyDbContext>(opt =>
                opt.UseLazyLoadingProxies()
                    .UseNpgsql(connectionStringOriginal, option =>
                        option.MigrationsHistoryTable("__EFMigrationHistory", schemaName)
                        ), ServiceLifetime.Transient
            );
        }
    }
}
