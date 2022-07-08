using CRUD.CQRS.ApplicationService.Common;
using PhoneNumbers;
using System.ComponentModel.DataAnnotations;

namespace CRUD.CQRS.ApplicationService.Validation
{
    public class PhoneNumberValidator :ValidationAttribute
    {
        public bool isPhoneNumberValid(string phoneNumber)
        {
            var phoneNeumberInstance = PhoneNumberUtil.GetInstance();
            try
            {
                phoneNeumberInstance.Parse(phoneNumber, null);
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            return !isPhoneNumberValid((string)value) ? new ValidationResult(Statics.InvalidPhoneNumber) : ValidationResult.Success;
        }

    }
}
