using CRUD.CQRS.ApplicationService.Common;
using System.Text.RegularExpressions;

namespace CRUD.CQRS.ApplicationService.Utility
{
    public class BankAccountNumberValidator
    {
        public bool IsValidBankAccountNumber(string accountNumber)
        {

            return accountNumber != null && Regex.IsMatch(accountNumber, Patterns.BankAccountNumberExpression); 
        }
    }
}
