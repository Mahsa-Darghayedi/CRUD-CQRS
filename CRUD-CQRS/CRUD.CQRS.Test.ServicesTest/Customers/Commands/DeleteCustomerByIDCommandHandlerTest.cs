using CRUD.CQRS.ApplicationService.Commands;
using CRUD.CQRS.ApplicationService.Commands.Handlers;
using CRUD.CQRS.ApplicationService.Common;
using CRUD.CQRS.ApplicationService.Common.DTOs;
using CRUD.CQRS.ApplicationService.Services.Customer.Commands.Handlers;
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
    public class DeleteCustomerByIDCommandHandlerTest : CustomerTestDBContext
    {
        [Fact]
        public async Task DeleteCustomerCommand_ShouldBeFailed_IdIsZero()
        {
            int id = 0;
            DeleteCustomerByIDCommandHandler handler = new DeleteCustomerByIDCommandHandler(_context);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await handler.Handle(new DeleteCustomerByIDCommand(id), CancellationToken.None));
        }

        [Fact]
        public async Task DeleteCustomerCommand_ShouldBeFailed_NoCustomer()
        {
            int id = 5;
            DeleteCustomerByIDCommandHandler handler = new DeleteCustomerByIDCommandHandler(_context);
            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(new DeleteCustomerByIDCommand(id), CancellationToken.None));
        }


        [Fact]
        public async Task DeleteCustomerCommand_ShouldBeSuccess()
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

            if (result.Equals(Statics.OpersationSuccessful))
            {
                int id = 1;
                DeleteCustomerByIDCommandHandler handler2 = new DeleteCustomerByIDCommandHandler(_context);
                var result2 = await handler2.Handle(new DeleteCustomerByIDCommand(id), CancellationToken.None);
                Assert.Equal(result2, Statics.OpersationSuccessful);
            }
        }

    }
}
