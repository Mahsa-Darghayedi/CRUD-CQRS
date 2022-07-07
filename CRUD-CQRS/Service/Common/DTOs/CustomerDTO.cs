using CRUD.CQRS.ApplicationService.Utility;
using System.ComponentModel.DataAnnotations;

namespace CRUD.CQRS.ApplicationService.Common.DTOs
{
    public class CustomerDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyFirstName)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyLastName)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyDateOfBirth)]
        public DateOnly DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyPhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyEmail)]
        [RegularExpression(pattern: Patterns.EmailExpression, ErrorMessage = Statics.InvalidEmailAddress)]
        [EmailValidator]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = Statics.EmptyBankAccount)]
        [RegularExpression(pattern: Patterns.BankAccountNumberExpression, ErrorMessage = Statics.InvalidBankAccount)]
        public string BankAccountNumber { get; set; }
    }
}
