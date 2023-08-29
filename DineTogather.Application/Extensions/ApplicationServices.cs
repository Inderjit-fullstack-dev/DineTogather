using DineTogather.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace DineTogather.Application.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
