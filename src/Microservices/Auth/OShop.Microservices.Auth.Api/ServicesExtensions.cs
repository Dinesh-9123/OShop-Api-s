using OShop.Microservices.Auth.Api.Controllers;
using OShop.Microservices.Auth.Api.Infrastructure.Handlers.Interfaces;
using OShop.Microservices.Auth.Api.Infrastructure.Handlers;
using OShop.Microservices.Auth.ServiceInterfaces;
using Scrutor;
using OShop.Microservices.Auth.DataInterfaces;
using OShop.Microservices.Auth.Data;
using OShop.Microservices.Auth.Services;
using OShop.Microservices.Auth.Services.Infrastructure.Builders.MapperProfiles;

namespace OShop.Microservices.Auth.Api
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
                typeof(ISignInHandler),
                typeof(SignInHandler),
                typeof(ISignInService),
                typeof(SignInService),
                typeof(SignInController)
            };

            services.Scan(scan => scan
                .FromAssembliesOf(types)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
            //  services.AddScoped<ApplicationUser>();
            return services;
        }

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoToModelMappingProfile));
            services.AddAutoMapper(typeof(ModelToDtoMappingProfile));
            return services;
        }
    }
}
