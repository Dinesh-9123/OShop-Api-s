using IdentityServer4.AccessTokenValidation;
using Microsoft.OpenApi.Models;
using OShop.Microservices.Auth.Services.Infrastructure.Builders.MapperProfiles;
using OShop.Microservices.Shopping.Api.Controllers;
using OShop.Microservices.Shopping.Api.Infrastructure.Handlers;
using OShop.Microservices.Shopping.Api.Infrastructure.Handlers.Interfaces;
using OShop.Microservices.Shopping.Data;
using OShop.Microservices.Shopping.DataInterfaces;
using OShop.Microservices.Shopping.Model;
using OShop.Microservices.Shopping.ServiceInterfaces;
using OShop.Microservices.Shopping.Services;
using Scrutor;

namespace OShop.Microservices.Shopping.Api
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                  builder => builder
                                             .SetIsOriginAllowed((host) => true)
                                             .AllowAnyMethod()
                                             .AllowAnyHeader()
                                             .AllowCredentials());
            });
            services.AddHttpContextAccessor();

            return services;
        }

        public static IServiceCollection AddCustomAssemblies(this IServiceCollection services)
        {
            var types = new List<Type>() {
                typeof(IDatabaseFactory),
                typeof(DatabaseFactory),
                typeof(ICartHandler),
                typeof(CartHandler),
                typeof(ICartService),
                typeof(CartService),
                typeof(CartController)
            };

            services.Scan(scan => scan
                .FromAssembliesOf(types)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
            services.AddScoped<TokenManager>();
            return services;
        }

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoToModelMappingProfile));
            services.AddAutoMapper(typeof(ModelToDtoMappingProfile));
            return services;
        }
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopping Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' token in the text input below.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = IdentityServerAuthenticationDefaults.AuthenticationScheme
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }
    }
}
