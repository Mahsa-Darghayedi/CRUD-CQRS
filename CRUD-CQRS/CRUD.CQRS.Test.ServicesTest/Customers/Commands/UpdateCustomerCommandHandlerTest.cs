using CRUD.CQRS.ApplicationService.Commands;
using CRUD.CQRS.ApplicationService.Commands.Handlers;
using CRUD.CQRS.ApplicationService.Common;
using CRUD.CQRS.ApplicationService.Common.DTOs;
using CRUD.CQRS.Test.ServicesTest.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CRUD.CQRS.Test.ServicesTest.Customers.Commands
{
    public class UpdateCustomerCommandHandlerTest : CustomerTestDBContext
    {


        [Fact]
        public async Task CreateCustomerCommand_ShouldBeFailed_EmptyCustomerDTO()
        {
            CustomerDTO customerDTO = new();
            UpdateCustomerCommandHandler handler = new UpdateCustomerCommandHandler(_context);
            var result = await handler.Handle(new UpdateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.NotEqual(result, Statics.OpersationSuccessful);
        }

        [Fact]
        public async Task CreateCustomerCommand_ShouldBeFailed_IdIsZero()
        {
            CustomerDTO customerDTO = new() { Id = 0 };
            UpdateCustomerCommandHandler handler = new UpdateCustomerCommandHandler(_context);
            var result = await handler.Handle(new UpdateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.NotEqual(result, Statics.OpersationSuccessful);
        }

        [Fact]
        public async Task CreateCustomerCommand_ShouldBeFailed_CustomerDoesNotFound()
        {
            CustomerDTO customerDTO = new() { Id = 5 };
            UpdateCustomerCommandHandler handler = new UpdateCustomerCommandHandler(_context);
            var result = await handler.Handle(new UpdateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.NotEqual(result, Statics.OpersationSuccessful);
        }


        [Fact]
        public async Task CreateCustomerCommand_ShouldBeFailed_DuplicateEmail()
        {

            CustomerDTO customerDTO = new()
            {
                FirstName = "Mahsa",
                LastName = "Darghayed",
                Email = "m.darghayedi@gmail.com",
                BankAccountNumber = "6532145285698",
                PhoneNumber = "+989392106186",
                DateOfBirth = new DateTime(2022, 1, 2, 4, 0, 0),
            };
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(_context);
            var saveResult = await handler.Handle(new CreateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.Equal(saveResult, Statics.OpersationSuccessful);

            CustomerDTO customerDTO2 = new()
            {
                FirstName = "Mahsa2",
                LastName = "Darghayed",
                Email = "m.darghayedi2@gmail.com",
                BankAccountNumber = "6532145285698",
                PhoneNumber = "+989392106186",
                DateOfBirth = new DateTime(2022, 1, 2, 4, 0, 0),
            };
            var saveResult2 = await handler.Handle(new CreateCustomerCommand(customerDTO2), CancellationToken.None);
            Assert.Equal(saveResult2, Statics.OpersationSuccessful);

            customerDTO2.Id = 2;
            customerDTO2.Email = "m.darghayedi@gmail.com";


            UpdateCustomerCommandHandler handler2 = new UpdateCustomerCommandHandler(_context);
            var result = await handler2.Handle(new UpdateCustomerCommand(customerDTO2), CancellationToken.None);
            Assert.NotEqual(result, Statics.OpersationSuccessful);
        }



        [Fact]
        public async Task CreateCustomerCommand_ShouldBeFailed_DuplicateCustomer()
        {

            CustomerDTO customerDTO = new()
            {
                FirstName = "Mahsa",
                LastName = "Darghayed",
                Email = "m.darghayedi@gmail.com",
                BankAccountNumber = "6532145285698",
                PhoneNumber = "+989392106186",
                DateOfBirth = new DateTime(2022, 1, 2, 4, 0, 0),
            };
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(_context);
            var saveResult = await handler.Handle(new CreateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.Equal(saveResult, Statics.OpersationSuccessful);


            CustomerDTO customerDTO2 = new()
            {
                FirstName = "Mahsa2",
                LastName = "Darghayed",
                Email = "m.darghayedi2@gmail.com",
                BankAccountNumber = "6532145285698",
                PhoneNumber = "+989392106186",
                DateOfBirth = new DateTime(2022, 1, 2, 4, 0, 0),
            };
            var saveResult2 = await handler.Handle(new CreateCustomerCommand(customerDTO2), CancellationToken.None);
            Assert.Equal(saveResult2, Statics.OpersationSuccessful);


            customerDTO2.Id = 2;
            customerDTO2.FirstName = "Mahsa";


            UpdateCustomerCommandHandler handler2 = new UpdateCustomerCommandHandler(_context);
            var result = await handler2.Handle(new UpdateCustomerCommand(customerDTO2), CancellationToken.None);
            Assert.NotEqual(result, Statics.OpersationSuccessful);
        }


        [Fact]
        public async Task CreateCustomerCommand_ShouldBeSuccess()
        {

            CustomerDTO customerDTO = new()
            {
                FirstName = "Mahsa",
                LastName = "Darghayed",
                Email = "m.darghayedi@gmail.com",
                BankAccountNumber = "6532145285698",
                PhoneNumber = "+989392106186",
                DateOfBirth = new DateTime(2022, 1, 2, 4, 0, 0),
            };
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(_context);
            var resultt = await handler.Handle(new CreateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.Equal(resultt, Statics.OpersationSuccessful);

            if (resultt.Equals(Statics.OpersationSuccessful))
            {
                customerDTO.Id = 1;
                customerDTO.FirstName = "Mahsa2";
                customerDTO.BankAccountNumber = "65321452856955";


                UpdateCustomerCommandHandler handler2 = new UpdateCustomerCommandHandler(_context);
                var result = await handler2.Handle(new UpdateCustomerCommand(customerDTO), CancellationToken.None);
                Assert.Equal(result, Statics.OpersationSuccessful);
            }
        }
    }
}
