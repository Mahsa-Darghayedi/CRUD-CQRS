using CRUD.CQRS.ApplicationService.Common.DTOs;
using MediatR;

namespace CRUD.CQRS.ApplicationService.Services.Customer.Queries
{
    public class GetAllCustomersQuery :IRequest<List<CustomerDTO>>
    {
        public GetAllCustomersQuery()
        {

        }
    }
}
