using DineTogather.Application.Common.Interfaces;
using DineTogather.Application.Persistence;
using DineTogather.Infrastructure.Authentication;
using DineTogather.Infrastructure.Persistence;
using DineTogather.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DineTogather.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
                Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            return services;
        }
    }
}
