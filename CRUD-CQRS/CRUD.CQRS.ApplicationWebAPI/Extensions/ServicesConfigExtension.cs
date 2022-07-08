using MediatR;

namespace Web_API.Extensions
{
    public static class ServicesConfigExtension
    {
        public static IServiceCollection AddServicesConfig(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMediatR(typeof(ServicesConfigExtension));
            return services;
        }

    }
}
