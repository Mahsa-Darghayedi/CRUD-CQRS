using CRUD.CQRS.ApplicationService.Validation;
using Xunit;

namespace CRUD.CQRS.Test.ServicesTest.TestValidation
{
    public class PhoneNumberValidationTest
    {
        private readonly PhoneNumberValidator validator;
        public PhoneNumberValidationTest()
        {
            validator = new PhoneNumberValidator();
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(" 00 11 00  ")]
        [InlineData(" 00x11xx00c ")]
        [InlineData(" xxxxxxx ")]
        [InlineData("98933225")] // No Plus
        public void ShouldBeInvalid_BadData(string value)
        {
            Assert.False(validator.isPhoneNumberValid(value));
        }


        [Theory]
        [InlineData("+989392106186")]
        [InlineData("+31 6 16833033")]
        [InlineData("+31 6 33300635")]
        public void ShouldBeValid_ValidData(string value)
        {
            Assert.True(validator.isPhoneNumberValid(value));
        }
    }
}
