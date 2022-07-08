using CRUD.CQRS.Domain.Interfaces;
using CRUD.CQRS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CQRS.Domain
{
    public class CustomerDBContext : DbContext, ICustomerDbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)
        { }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasKey(p => new { p.FirstName, p.LastName, p.DateOfBirth });        
            builder.Entity<Customer>().HasIndex(p => new { p.Email }).IsUnique();

            base.OnModelCreating(builder);
        }

        public async Task<bool> SaveChangsAsync()
        {
            try
            {
                await base.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
