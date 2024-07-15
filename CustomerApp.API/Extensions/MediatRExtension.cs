namespace CustomerApp.API.Extensions
{
    public static class MediatRExtension
    {
        public static IServiceCollection MediatRConfig(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("CustomerApp.Core"));
            });
            return services;
        }
    }
}
