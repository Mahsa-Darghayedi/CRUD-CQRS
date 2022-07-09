using CRUD.CQRS.ApplicationService.Commands.Handlers;
using CRUD.CQRS.ApplicationService.Services.Customer.Commands.Handlers;
using CRUD.CQRS.ApplicationService.Services.Customer.Commands.Validators;
using CRUD.CQRS.ApplicationService.Services.Customer.Queries.Handlers;
using MediatR;
using System.Reflection;

namespace Web_API.Extensions
{
    public static class MediatRDependencies
    {
        public static IServiceCollection MediatRDependenciesHandlers(
            this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCustomerCommandHandler).Assembly);
            services.AddMediatR(typeof(UpdateCustomerCommandHandler).Assembly);
            services.AddMediatR(typeof(GetCustomerByIdQueryHandler).Assembly);
            services.AddMediatR(typeof(GetAllCustomersQueryHandler).Assembly);
            services.AddMediatR(typeof(DeleteCustomerByIDCommandHandler).Assembly);
            return services;
                
        }
    }
}
