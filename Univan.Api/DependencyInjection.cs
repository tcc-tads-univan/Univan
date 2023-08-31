using Mapster;
using MapsterMapper;
using System.Reflection;
using Univan.Api.Middleware;

namespace Univan.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            AddMapping(services);
            AddMiddleware(services);

            return services;
        }

        private static void AddMapping(IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);

            services.AddScoped<IMapper, ServiceMapper>();
        }

        private static void AddMiddleware(IServiceCollection services)
        {
            services.AddTransient<ErrorHandlingMiddleware>();
        }
    }
}
