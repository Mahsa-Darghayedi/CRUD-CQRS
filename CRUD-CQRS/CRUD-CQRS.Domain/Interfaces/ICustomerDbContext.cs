using CRUD.CQRS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.CQRS.Domain.Interfaces
{
    public interface ICustomerDbContext
    {
        DbSet<Customer> Customers { get; }
        Task<int> SaveChangsAsync();
        Task<bool> AddAsync(Customer entity);
    }
}
