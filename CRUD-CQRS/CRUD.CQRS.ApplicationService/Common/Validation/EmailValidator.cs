using CRUD.CQRS.ApplicationService.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace CRUD.CQRS.ApplicationService.Validation
{
    public class EmailValidator : ValidationAttribute
    {

        public bool IsEmailValid(string email)
        {
            return email != null && Regex.IsMatch(email, Patterns.EmailExpression);
        }


        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            return !IsEmailValid((string)value) ? new ValidationResult(Statics.InvalidEmailAddress) : ValidationResult.Success;
        }


    }
}