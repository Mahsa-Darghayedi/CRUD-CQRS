using CRUD.CQRS.ApplicationService.Commands;
using CRUD.CQRS.ApplicationService.Common;
using CRUD.CQRS.ApplicationService.Services.Customer.Commands.Validators;
using CRUD.CQRS.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System.Text;

namespace CRUD.CQRS.ApplicationService.Commands.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, string>
    {
        private readonly ICustomerDbContext _context;
        public UpdateCustomerCommandHandler(ICustomerDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateCustomerCommandValidator(_context);
            ValidationResult results = validator.Validate(request);
            if (results.IsValid)
            {
                var existModel = await _context.Customers.FindAsync(request.Id).ConfigureAwait(false);
                if (existModel == null)
                    throw new Exception($"Customer with Name :{ request.FirstName} {request.LastName} and DateOfBirth {request.DateOfBirth} does not found.");


                existModel.DateOfBirth = request.DateOfBirth;
                existModel.FirstName = request.FirstName;
                existModel.LastName = request.LastName;
                existModel.PhoneNumber = request.PhoneNumber;
                existModel.Email = request.Email;
                existModel.BankAccountNumber = request.BankAccountNumber;
                await _context.SaveChangsAsync();
                return Statics.OpersationSuccessful;
            }
            StringBuilder errors = new StringBuilder();
            results.Errors.ForEach(err => errors.Append(err.ErrorMessage));
            return errors.ToString();
        }

    }
}
