using CRUD.CQRS.ApplicationService.Commands;
using CRUD.CQRS.ApplicationService.Common;
using CRUD.CQRS.Domain.Interfaces;
using FluentValidation;

namespace CRUD.CQRS.ApplicationService.Services.Customer.Commands.Validators
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        private readonly ICustomerDbContext _context;
        public UpdateCustomerCommandValidator(ICustomerDbContext context)
        {
            _context = context;
            RuleFor(c => c.Id)
                .NotNull().WithMessage(Statics.InvalidRequest)
                .NotEmpty().WithMessage(Statics.InvalidRequest)
                .NotEqual(0).WithMessage(Statics.InvalidRequest);

            RuleFor(c => c.FirstName)
             .NotNull().WithMessage(Statics.EmptyFirstName)
             .NotEmpty().WithMessage(Statics.EmptyFirstName);


            RuleFor(c => c.LastName)
                .NotNull().WithMessage(Statics.EmptyLastName)
                .NotEmpty().WithMessage(Statics.EmptyLastName);

            RuleFor(c => c.DateOfBirth)
                .NotNull().WithMessage(Statics.EmptyDateOfBirth)
                .NotEmpty().WithMessage(Statics.EmptyDateOfBirth);

            RuleFor(c => c)
                .Must(IsEmailUnique).WithMessage(Statics.DuplicateEmailAddress)
                .Must(IsCustomerUnique).WithMessage(Statics.DuplicateCustomer);


        }

        private bool IsEmailUnique(UpdateCustomerCommand updateCustomer)
        {
            if (string.IsNullOrEmpty(updateCustomer?.Email))
                return false;

            return !_context.Customers.Any(c => c.Email.ToLower().Trim().Equals(updateCustomer.Email.ToLower().Trim()) && !c.Id.Equals(updateCustomer.Id));
        }

        private bool IsCustomerUnique(UpdateCustomerCommand updateCustomer)
        {
            if (string.IsNullOrEmpty(updateCustomer?.FirstName) || string.IsNullOrEmpty(updateCustomer?.LastName))
                return false;

            return !_context.Customers.Any(c => c.FirstName.ToLower().Trim().Equals(updateCustomer.FirstName.ToLower().Trim())
                                            && c.LastName.ToLower().Trim().Equals(updateCustomer.LastName.ToLower().Trim())
                                            && c.DateOfBirth.Date.Equals(updateCustomer.DateOfBirth.Date)
                                            && !c.Id.Equals(updateCustomer.Id)
                                            );
        }
    }
}
