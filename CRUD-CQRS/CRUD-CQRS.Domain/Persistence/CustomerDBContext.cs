using CRUD.CQRS.Domain.Interfaces;
using CRUD.CQRS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CRUD.CQRS.Domain.Persistence
{
    public class CustomerDBContext : DbContext, ICustomerDbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)
        {       
        
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public async Task<int> SaveChangsAsync()
        {
            try
            {
                return await base.SaveChangesAsync(); ;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<bool> AddAsync(Customer entity)
        {
            try
            {
                await base.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
