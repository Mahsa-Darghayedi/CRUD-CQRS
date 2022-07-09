using CRUD.CQRS.Domain.Models;
using CRUD.CQRS.Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.CQRS.Test.ServicesTest.Base
{
    public class CustomerTestDBContext : IDisposable
    {
        protected readonly CustomerDBContext _context;
        public CustomerTestDBContext()
        {
            _context = Create();
        }

        public void Dispose()
        {
            Destroy(_context);
        }
        private static CustomerDBContext Create()
        {
            var options = new DbContextOptionsBuilder<CustomerDBContext>()
                .UseInMemoryDatabase("CustomerDBTest")
                .Options;
            var context = new CustomerDBContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        private static void Destroy(CustomerDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
        
    }
}
