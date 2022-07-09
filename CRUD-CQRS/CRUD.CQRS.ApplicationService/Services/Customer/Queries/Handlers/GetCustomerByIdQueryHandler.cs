using CRUD.CQRS.ApplicationService.Common;
using CRUD.CQRS.ApplicationService.Common.DTOs;
using CRUD.CQRS.Domain.Interfaces;
using MediatR;

namespace CRUD.CQRS.ApplicationService.Services.Customer.Queries.Handlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
    {
        private readonly ICustomerDbContext _context;
        public GetCustomerByIdQueryHandler(ICustomerDbContext context)
        {
            _context = context;
        }
        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            if (request?.Id == null || request?.Id == 0)
                throw new ArgumentNullException(Statics.InvalidRequest);

            var customer = await _context.Customers.FindAsync(request.Id);
            if (customer == null)
                throw new Exception(Statics.CustomerNotFound);

            var x = new CustomerDTO()
            {
                Id = customer.Id,   
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email,
                BankAccountNumber = customer.BankAccountNumber,
                PhoneNumber = customer.PhoneNumber
            };
            return x;
        }
    }
}
