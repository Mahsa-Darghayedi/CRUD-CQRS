using CRUD.CQRS.ApplicationService.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CRUD.CQRS.ApplicationService.Validation
{
    public class BankAccountNumberValidator : ValidationAttribute
    {
        public bool IsValidBankAccountNumber(string accountNumber)
        {
            return accountNumber != null && Regex.IsMatch(accountNumber, Patterns.BankAccountNumberExpression) && !(Int64.Parse(accountNumber).Equals(0));
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            return IsValidBankAccountNumber((string)value) ? new ValidationResult(ErrorMessage = Statics.InvalidBankAccount) : ValidationResult.Success;
        }


    }
}
