using FluentValidation.AspNetCore;
using FluentValidation;

namespace CustomerApp.API.Extensions
{
    public static class ValidatorExtension
    {
        public static IServiceCollection ValidatorConfig(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("CustomerApp.Core"));
            services.AddFluentValidationAutoValidation();
            return services;
        }
    }
}
