using CRUD.CQRS.ApplicationService.Commands.Handlers;
using CRUD.CQRS.ApplicationService.Services;
using CRUD.CQRS.Domain.Interfaces;
using CRUD_CQRS.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Web_API.Extensions
{
    public static class ServicesConfigExtension
    {
        public static IServiceCollection AddServicesConfig(this IServiceCollection services)
        {
            services.AddDbContext<CustomerDBContext>(options => options.UseInMemoryDatabase(databaseName: "CustomersDB"));            
            services.AddScoped<ICustomerDbContext, CustomerDBContext>();
            services.AddMediatR(typeof(CreateCustomerCommandHandler).Assembly);
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD.CQRS.ApplicationWebAPI", Version = "v1" });
            }); 

           // services.RegisterRequestHandlers();
            return services;
        }

    }
}
