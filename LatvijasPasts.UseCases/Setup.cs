using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LatvijasPasts.UseCases
{
    public static class Setup
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            //MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
