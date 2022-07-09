using CRUD.CQRS.ApplicationService.Common.DTOs;
using MediatR;

namespace CRUD.CQRS.ApplicationService.Services.Customer.Events
{
    public record CustomerCreatedEventcs(CustomerDTO customer) : INotification;
   
}
