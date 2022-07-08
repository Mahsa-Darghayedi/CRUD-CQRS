using CRUD.CQRS.ApplicationService.Common.DTOs;
using MediatR;

namespace CRUD.CQRS.ApplicationService.Commands
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public CreateCustomerCommand(CustomerDTO customer)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            DateOfBirth = customer.DateOfBirth; 
            Email = customer.Email; 
            BankAccountNumber = customer.BankAccountNumber; 
            PhoneNumber = customer.PhoneNumber; 
        }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }
        public string PhoneNumber { get; set; }
        public string Email { get; }
        public string BankAccountNumber { get; }

    }
}
