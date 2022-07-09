using CRUD.CQRS.ApplicationService.Services;
using CRUD.CQRS.Domain.Interfaces;
using CRUD.CQRS.Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace CRUD.CQRS.Test.ServicesTest
{
    public class CustomerServiceTest
    {
        private ICustomerService _customerService;
        public CustomerDBContext GetMemoryContext()
        {

            DbContextOptions<CustomerDBContext> options = new DbContextOptionsBuilder<CustomerDBContext>()
                        .UseInMemoryDatabase(databaseName: "CustomerDBTest")
                        .Options;
            var context = new CustomerDBContext(options);
            _customerService = new CustomerService(context);
            return context;
        }

        [Fact]
        public void ShouldBeInvalid_StringEmpty()
        {
            GetMemoryContext();
            Assert.False(_customerService.IsEmailUniqe(string.Empty));
        }

        [Fact]
        public void ShouldBeInvalid_NULL()
        {
            GetMemoryContext();
            Assert.False(_customerService.IsEmailUniqe(null));
        }


    }
}
