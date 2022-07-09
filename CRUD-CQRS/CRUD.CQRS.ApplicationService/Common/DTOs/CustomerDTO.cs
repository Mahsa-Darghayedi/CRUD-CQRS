using CRUD.CQRS.ApplicationService.Validation;
using System.ComponentModel.DataAnnotations;

namespace CRUD.CQRS.ApplicationService.Common.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; } 
        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyFirstName)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyLastName)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyDateOfBirth)]
        public DateTime DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyPhoneNumber)]
        [PhoneNumberValidator]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyEmail)]
        [RegularExpression(pattern: Patterns.EmailExpression, ErrorMessage = Statics.InvalidEmailAddress)]
        [EmailValidator]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyBankAccount)]
        [RegularExpression(pattern: Patterns.BankAccountNumberExpression, ErrorMessage = Statics.InvalidBankAccount)]
        [BankAccountNumberValidator]
        public string BankAccountNumber { get; set; }
    }
}
