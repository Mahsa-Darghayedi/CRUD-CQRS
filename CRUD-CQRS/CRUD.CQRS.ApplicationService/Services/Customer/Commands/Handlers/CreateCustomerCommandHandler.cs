using CRUD.CQRS.ApplicationService.Common;
using CRUD.CQRS.ApplicationService.Common.DTOs;
using CRUD.CQRS.ApplicationService.Services.Customer.Commands.Validators;
using CRUD.CQRS.Domain.Interfaces;
using CRUD.CQRS.Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Text;

namespace CRUD.CQRS.ApplicationService.Commands.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, string>
    {
        private readonly ICustomerDbContext _context;
        public CreateCustomerCommandHandler(ICustomerDbContext context)
        {
            _context = context;
        }


      public  async Task<string> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerCommandValidator(_context);
            ValidationResult results = validator.Validate(request);
            if (results.IsValid)
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
                await _context.AddAsync(customer);
                await _context.SaveChangsAsync();    
                return Statics.OpersationSuccessful;    
            }
            StringBuilder errors = new StringBuilder();
            results.Errors.ForEach(err => errors.Append( err.ErrorMessage));
            return errors.ToString();
        }
    }
}
