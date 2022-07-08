using CRUD.CQRS.ApplicationService.Common.DTOs;
using CRUD.CQRS.Domain.Interfaces;
using CRUD.CQRS.Domain.Models;
using MediatR;

namespace CRUD.CQRS.ApplicationService.Commands.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly ICustomerDbContext _context;
        public CreateCustomerCommandHandler(ICustomerDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new()
            { 
                    FirstName = request.FirstName,      
                    LastName = request.LastName,        
                    PhoneNumber = request.PhoneNumber,  
                    Email = request.Email,
                    BankAccountNumber = request.BankAccountNumber,
                    DateOfBirth = request.DateOfBirth,
            };

            _context.Customers.Add(customer);
            return await _context.SaveChangsAsync();

        }
    }
}
