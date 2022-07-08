using CRUD.CQRS.Domain.Interfaces;

namespace CRUD.CQRS.ApplicationService.Services
{
    public class CustomerService : ICustomerService 
    {
        private readonly ICustomerDbContext _context;
        public CustomerService(ICustomerDbContext context)
        {
            _context = context; 
        }

        public bool IsEmailUniqe(string email)
        {
            return _context.Customers.Count(c=> c.Email.Trim().ToLower().Equals(email.Trim().ToLower())) == 0;
        }
    }
}
