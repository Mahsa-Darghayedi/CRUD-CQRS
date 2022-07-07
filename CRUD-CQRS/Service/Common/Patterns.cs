namespace CRUD.CQRS.ApplicationService.Common
{
    public static class Patterns
    {
        public const string EmailExpression = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                + "@"
                                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

        public const string BankAccountNumberExpression = @"^\d{9,18}$";
    }
}
