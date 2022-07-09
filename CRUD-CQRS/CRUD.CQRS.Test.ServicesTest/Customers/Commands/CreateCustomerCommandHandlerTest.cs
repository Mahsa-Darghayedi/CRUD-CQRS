using CRUD.CQRS.ApplicationService.Commands;
using CRUD.CQRS.ApplicationService.Commands.Handlers;
using CRUD.CQRS.ApplicationService.Common;
using CRUD.CQRS.ApplicationService.Common.DTOs;
using CRUD.CQRS.Test.ServicesTest.Base;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace CRUD.CQRS.Test.ServicesTest.Customers.Commands
{
    public class CreateCustomerCommandHandlerTest : CustomerTestDBContext
    {
        [Fact]
        public async Task CreateCustomerCommand_ShouldBeFailed_EmptyCustomerDTO()
        {
            CustomerDTO customerDTO = new();
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(_context);
            var result = await handler.Handle(new CreateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.NotEqual(result, Statics.OpersationSuccessful);
        }


        [Fact]
        public async Task CreateCustomerCommand_ShouldBeFailed_NullCustomerDTO()
        {
            CustomerDTO customerDTO = null;
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(_context);
            var result = await handler.Handle(new CreateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.NotEqual(result, Statics.OpersationSuccessful);
        }


        [Fact]
        public async Task CreateCustomerCommand_ShouldBeFailed_CustomerDTOWithEmptyDate()
        {
            CustomerDTO customerDTO = new()
            {
                FirstName = string.Empty,
                LastName = string.Empty,    
                Email = string.Empty,   
                BankAccountNumber = string.Empty,   
                PhoneNumber = string.Empty,                

            };
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(_context);
            var result = await handler.Handle(new CreateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.NotEqual(result, Statics.OpersationSuccessful);
        }
        [Fact]
        public async Task CreateCustomerCommand_ShouldBeFailed_CustomerDTOWithBadDate()
        {
            CustomerDTO customerDTO = new()
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Email = "resultx",
                BankAccountNumber = "5sx1sx5s1x5s1x",
                PhoneNumber = "+98xsxs6622222",
            };
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(_context);
            var result = await handler.Handle(new CreateCustomerCommand(customerDTO), CancellationToken.None);
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
                DateOfBirth = DateTime.Now,
            };
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(_context);
            var result = await handler.Handle(new CreateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.Equal(result, Statics.OpersationSuccessful);
        }


        [Fact]
        public async Task CreateCustomerCommand_ShouldBeFaeild_DuplicateEmail()
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
            var result = await handler.Handle(new CreateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.Equal(result, Statics.OpersationSuccessful);

            CustomerDTO customerDTO2 = new()
            {
                FirstName = "Mahsa2",
                LastName = "Darghayed",
                Email = "m.darghayedi@gmail.com",
                BankAccountNumber = "6532145285698",
                PhoneNumber = "+989392106186",
                DateOfBirth = new DateTime(2022, 1, 2, 4, 0, 0),
            };
            CreateCustomerCommandHandler handler2 = new CreateCustomerCommandHandler(_context);
            var result2 = await handler2.Handle(new CreateCustomerCommand(customerDTO2), CancellationToken.None);
            Assert.NotEqual(result2, Statics.OpersationSuccessful);
        }


        [Fact]
        public async Task CreateCustomerCommand_ShouldBeFaeild_DuplicateCustomer()
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
            var result = await handler.Handle(new CreateCustomerCommand(customerDTO), CancellationToken.None);
            Assert.Equal(result, Statics.OpersationSuccessful);

            CustomerDTO customerDTO2 = new()
            {
                FirstName = "Mahsa",
                LastName = "Darghayed",
                Email = "m.darghayedi2@gmail.com",
                BankAccountNumber = "6532145285698",
                PhoneNumber = "+989392106186",
                DateOfBirth = new DateTime(2022, 1, 2, 4, 0, 0),
            };
            CreateCustomerCommandHandler handler2 = new CreateCustomerCommandHandler(_context);
            var result2 = await handler2.Handle(new CreateCustomerCommand(customerDTO2), CancellationToken.None);
            Assert.NotEqual(result2, Statics.OpersationSuccessful);
        }
    }
}
