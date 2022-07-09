using CRUD.CQRS.ApplicationService.Commands.Handlers;
using CRUD.CQRS.ApplicationService.Services;
using CRUD.CQRS.Domain.Interfaces;
using CRUD.CQRS.Domain.Persistence;
using FluentValidation.AspNetCore;
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
            var assemblies = Assembly.GetExecutingAssembly();
            services.AddFluentValidation();
            services.AddControllers().AddFluentValidation(cnfg => cnfg.RegisterValidatorsFromAssemblyContaining<Program>());
            services.AddDbContext<CustomerDBContext>(options => options.UseInMemoryDatabase(databaseName: "CustomersDB"));
            services.AddScoped<ICustomerDbContext, CustomerDBContext>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.MediatRDependenciesHandlers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD.CQRS.ApplicationWebAPI", Version = "v2" });
            });

            return services;
        }

    }
}
