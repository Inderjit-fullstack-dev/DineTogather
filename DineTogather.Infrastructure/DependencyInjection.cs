using DineTogather.Application.Common.Interfaces;
using DineTogather.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace DineTogather.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}
