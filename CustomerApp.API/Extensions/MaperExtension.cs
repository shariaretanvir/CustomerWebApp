using Mapster;
using MapsterMapper;

namespace CustomerApp.API.Extensions
{
    public static class MaperExtension
    {
        public static IServiceCollection MapperConfig(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(AppDomain.CurrentDomain.Load("CustomerApp.Core"));
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
    }
}
