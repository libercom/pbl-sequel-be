using FAFscord.Application.Common.Interfaces.Repositories;
using FAFscord.Application.Common.Interfaces.Services;
using FAFscord.Infrastructure.External.Services;
using FAFscord.Infrastructure.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FAFscord.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IGraphApiService, GraphApiService>();
            services.AddScoped<IRepository, EFCoreRepository>();

            return services;
        }
    }
}
