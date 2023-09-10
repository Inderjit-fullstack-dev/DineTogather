using Microsoft.Extensions.DependencyInjection;

namespace DineTogather.Application.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(ApplicationServices).Assembly));
            return services;
        }
    }
}
