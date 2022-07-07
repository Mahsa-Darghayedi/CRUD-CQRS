using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.CQRS.Test.Application.TestValidation
{

    [TestClass]
    public class EmailValidationTest
    {
        private readonly EmailValidator validator;
        public EmailValidationTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        [TestMethod]
        public void ShouldBeInvalid_Null()
        {
           // bool result = new IsValidEmail(null);
        }
        
    }
}
