using CRUD.CQRS.ApplicationService.Common.DTOs;
using MediatR;

namespace CRUD.CQRS.ApplicationService.Services.Customer.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDTO>
    {
        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
