using CRUD.CQRS.ApplicationService.Validation;
using Xunit;

namespace CRUD.CQRS.Test.ServicesTest.TestValidation
{
    public class BankAccountNumberValidationTest
    {
        private readonly BankAccountNumberValidator validator;
        public BankAccountNumberValidationTest()
        {
            validator = new BankAccountNumberValidator();
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("x")]
        [InlineData("xxxx")]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("123")]
        [InlineData("1234")]
        [InlineData("12345")]
        [InlineData("123456")]
        [InlineData("1234567")]
        [InlineData("12345678")]
        [InlineData("123456789101112131415160")] //more than 18
        [InlineData("123456789x")] // 9-18 include letters
        [InlineData("abcdefghjklmno")]
        [InlineData("000000000")]
        [InlineData("0000000000000000000")]
        public void ShouldBeInValid_InvalidInputs(string value)
        {
            Assert.False(validator.IsValidBankAccountNumber(value));
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("1234567891234")]
        [InlineData("123456789123456789")]
        [InlineData("1111111111111")]
        [InlineData("000000000000000001")]
        public void ShouldBeValid(string value)
        {
            Assert.True(validator.IsValidBankAccountNumber(value));
        }


    }
}
