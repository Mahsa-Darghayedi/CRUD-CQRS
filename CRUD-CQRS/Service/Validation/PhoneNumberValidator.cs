using PhoneNumbers;

namespace CRUD.CQRS.ApplicationService.Validation
{
    public class PhoneNumberValidator
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
    }
}
