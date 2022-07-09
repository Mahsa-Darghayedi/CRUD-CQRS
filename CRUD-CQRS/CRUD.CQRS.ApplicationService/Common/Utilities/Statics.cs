using System.Runtime.Serialization;

namespace CRUD.CQRS.ApplicationService.Common
{
    public static class Statics
    {
        #region Messages
        public const string EmptyFirstName = "Please Enter First Name";
        public const string EmptyLastName = "Please Enter Last Name";
        public const string EmptyEmail = "Please Enter Email Address";
        public const string EmptyPhoneNumber = "Please Enter Phone Number";
        public const string EmptyDateOfBirth = "Please Enter Date of Birth";
        public const string EmptyBankAccount = "Please Enter Bank Account Number";


        public const string InvalidEmailAddress = "Please Enter a Valid Email Address";
        public const string InvalidBankAccount = "Please Enter a Valid Bank Account Number";
        public const string InvalidPhoneNumber = "Please Enter a Valid Phone Number";


        public const string DuplicateEmailAddress = "The entered Email Address already exists.";
        public const string DuplicateCustomer = "Duplicate customer.";

        public const string OpersationSuccessful = "Operation successfuly done.";
        public const string InvalidRequest = "Invalid Request.";
        public const string CustomerNotFound = "Customer Not Found.";


        #endregion Messages
    }
}
