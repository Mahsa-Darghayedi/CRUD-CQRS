using MediatR;
using System.Reflection;

namespace Web_API.Extensions
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return services
                .AddMediatR(assembly);
        }
    }
}
