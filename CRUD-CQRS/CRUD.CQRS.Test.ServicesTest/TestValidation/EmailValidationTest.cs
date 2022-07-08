using CRUD.CQRS.ApplicationService.Validation;
using Xunit;

namespace CRUD.CQRS.Test.ServicesTest.TestValidation
{

    public class EmailValidationTest
    {
        readonly EmailValidator validator;
        public EmailValidationTest()
        {
            validator = new EmailValidator();
        }

        [Fact]
        public void ShouldBeInvalid_Null()
        {
            bool result = validator.IsEmailValid(null);
            Assert.False(result);
        }

        [Fact]
        public void ShouldBeInvalid_Empty()
        {
            bool result = validator.IsEmailValid(string.Empty);
            Assert.False(result);
        }

        [Theory]
        [InlineData("a@@a.com")]
        [InlineData("a@a@.com")]
        [InlineData( "    .com")]
        [InlineData("@x.com")]
        [InlineData("   @x")]
        [InlineData("xyz")]
        [InlineData("@xyz@")]
        [InlineData("@xyz@gmail.com")]
        [InlineData("xyz@gmail..com")]
        [InlineData("xy..z@gmailcom")]
        [InlineData("xyz@gmailcom")]
        [InlineData("xyz.gmail.com")]
        public void ShouldBeInvalid_InvalidEmails(string value)
        {
            Assert.False(validator.IsEmailValid(value));    
        }

        [Theory]
        [InlineData("m.darghayedi@gmail.com")]
        [InlineData("m.darghayedi@xyz.com")]
        [InlineData("m.darghayedi@sazeh.ir")]
        [InlineData("m_darghayedi@yahoo.com")]
        public void ShouldBeValid(string value)
        {
            Assert.True(validator.IsEmailValid(value)); 
        }
    }
}

