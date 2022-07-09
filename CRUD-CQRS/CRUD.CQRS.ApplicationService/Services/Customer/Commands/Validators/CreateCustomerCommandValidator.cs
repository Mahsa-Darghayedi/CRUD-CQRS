using CRUD.CQRS.ApplicationService.Commands;
using CRUD.CQRS.ApplicationService.Common;
using CRUD.CQRS.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace CRUD.CQRS.ApplicationService.Services.Customer.Commands.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly ICustomerDbContext _context;
        public CreateCustomerCommandValidator(ICustomerDbContext context)
        {
            _context = context;

            RuleFor(c => c.Email)
                .NotNull().WithMessage(Statics.EmptyEmail)
                .NotEmpty().WithMessage(Statics.EmptyEmail)
                .Must(IsUniqueEmailAddress)
                .WithMessage(Statics.DuplicateEmailAddress);

            RuleFor(c => c.FirstName)
                .NotNull().WithMessage(Statics.EmptyFirstName)
                .NotEmpty().WithMessage(Statics.EmptyFirstName);


            RuleFor(c => c.LastName)
                .NotNull().WithMessage(Statics.EmptyLastName)
                .NotEmpty().WithMessage(Statics.EmptyLastName);

            RuleFor(c => c.DateOfBirth)
                .NotNull().WithMessage(Statics.EmptyDateOfBirth)
                .NotEmpty().WithMessage(Statics.EmptyDateOfBirth);

            RuleFor(c => c).Must(IsCustomerUnique).WithMessage(Statics.DuplicateCustomer);


        }
        private bool IsUniqueEmailAddress(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return !_context.Customers.Any(c => c.Email.ToLower().Trim().Equals(email.ToLower().Trim()));
        }
        private bool IsCustomerUnique(CreateCustomerCommand customer)
        {
            if(string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.LastName) || customer.DateOfBirth==(DateTime?) null)
                return false;

            return !_context.Customers.Any(c => c.FirstName.ToLower().Trim().Equals(customer.FirstName.ToLower().Trim())
                                            && c.LastName.ToLower().Trim().Equals(customer.LastName.ToLower().Trim())
                                            && c.DateOfBirth.Date.Equals(customer.DateOfBirth.Date)
                                            );

        }

    }
}
