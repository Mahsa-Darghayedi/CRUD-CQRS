using CRUD.CQRS.ApplicationService.Common.DTOs;
using CRUD.CQRS.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRUD.CQRS.ApplicationService.Services.Customer.Queries.Handlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDTO>>
    {
        private readonly ICustomerDbContext _context;
        public GetAllCustomersQueryHandler(ICustomerDbContext context)
        {
            _context = context;
        }
        public async Task<List<CustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await (_context.Customers.AsNoTracking().Select(customer => new CustomerDTO()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email,
                BankAccountNumber = customer.BankAccountNumber,
                PhoneNumber = customer.PhoneNumber

            }).ToListAsync());

        }
    }
}
